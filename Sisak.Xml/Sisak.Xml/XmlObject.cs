using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sisak.Xml
{
    public abstract class XmlObject<T>
    {
        /// <summary>
        /// Deserializes the XML string from a given file to object of type T.
        /// </summary>
        /// <param name="filePath">Filepath</param>
        /// <returns>Deserialized object</returns>
        public static T LoadXML(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                string fileContents = System.IO.File.ReadAllText(filePath);
                T to = Helper.Deserialize<T>(fileContents);
                return to;
            }

            return default(T);
        }

        /// <summary>
        /// Serializes object and saves XML string to given file.
        /// The file will be overwritten if it already exists.
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <param name="filePath">Filepath</param>
        public static void SaveXML(T obj, string filePath, Encoding enc)
        {
            string xmlContent = Helper.Serialize<T>(obj, enc);
            if (System.IO.File.Exists(filePath))
                File.Delete(filePath);
            File.WriteAllText(filePath, xmlContent, Encoding.UTF8);
        }

        /// <summary>
        /// Serializes object and saves XML string to given file.
        /// The file will be overwritten if it already exists.
        /// Uses UTF-8 encoding.
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <param name="filePath">Filepath</param>
        public static void SaveXML(T obj, string filePath)
        {
            SaveXML(obj, filePath, Encoding.UTF8);
        }
    }
}
