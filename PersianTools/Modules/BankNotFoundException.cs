using System;
using System.Runtime.Serialization;

namespace PersianTools.Modules
{
    [Serializable]
    public class BankNotFoundException : Exception
    {
        public BankNotFoundException(string message) : base(message)
        {
        }
    }
}