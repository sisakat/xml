using System;
using System.Collections.Generic;
using System.Text;

namespace Sisak.Xml
{
    public class XmlException : Exception
    {
        public XmlException(string message) : base(message)
        {
        }

        public XmlException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
