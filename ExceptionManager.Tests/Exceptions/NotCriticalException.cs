using System;
using System.Runtime.Serialization;

namespace ExceptionManager.Tests.Exceptions
{
    abstract class NotCriticalException : Exception, ICustomException
    {
        public NotCriticalException()
        {
        }

        public NotCriticalException(string message) : base(message)
        {
        }

        public NotCriticalException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotCriticalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
