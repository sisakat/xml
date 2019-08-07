using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Sisak.Xml
{
    public class Helper
    {
        /// <summary>
        /// Serializes a given object of type T to a XML string (UTF-8 encoded).
        /// </summary>
        /// <typeparam name="T">Serialization type</typeparam>
        /// <param name="t">Object to perform serialization on</param>
        /// <returns>XML string</returns>
        public static String Serialize<T>(T t, Encoding enc)
        {
            using (StringWriter sw = new StringWriterWithEncoding(enc))
            {
                try
                {
                    XmlWriterSettings xws = new XmlWriterSettings
                    {
                        Indent = true,
                        Encoding = enc
                    };

                    using (XmlWriter xw = XmlWriter.Create(sw, xws))
                    {
                        new XmlSerializer(typeof(T)).Serialize(xw, t);
                        return sw.GetStringBuilder().ToString();
                    }
                } catch(Exception ex)
                {
                    throw new XmlException(ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Deserializes a XML string into the given object of type T.
        /// </summary>
        /// <typeparam name="T">Deserialized object type</typeparam>
        /// <param name="s_xml">XML string</param>
        /// <returns>Deserialized object</returns>
        public static T Deserialize<T>(string s_xml)
        {
            try
            {
                using (XmlReader xw = XmlReader.Create(new StringReader(s_xml)))
                {
                    var toRet = (T)new XmlSerializer(typeof(T)).Deserialize(xw);
                    return toRet;
                }

            } catch(Exception ex)
            {
                throw new XmlException(ex.Message, ex);
            }
        }
    }
}
