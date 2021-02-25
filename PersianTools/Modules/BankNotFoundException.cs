using System;
using System.Runtime.Serialization;

namespace PersianTools.Modules
{
    [Serializable]
    public class BankNotFoundException : Exception
    {
        public BankNotFoundException()
        {
        }

        public BankNotFoundException(string message) : base(message)
        {
        }

        public BankNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BankNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}