using System;
using System.Runtime.Serialization;

namespace AppServices
{
    [Serializable]
    internal class InvalidCSVFileExeption : Exception
    {
        public InvalidCSVFileExeption()
        {
        }

        public InvalidCSVFileExeption(string message) : base(message)
        {
        }

        public InvalidCSVFileExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCSVFileExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}