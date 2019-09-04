using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ExceptionManager.Tests.Exceptions
{
    abstract class CriticalException : Exception, ICustomException
    {
        public CriticalException()
        {
        }

        public CriticalException(string message) : base(message)
        {
        }

        public CriticalException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CriticalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
