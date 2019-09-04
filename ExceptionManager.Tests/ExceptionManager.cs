using ExceptionManager.Tests.Exceptions;
using System;
using System.Linq;

namespace ExceptionManager.Tests
{
    class ExceptionManager
    {
        public static Type[] CriticalExceptionTypes { get; private set; } = new Type[]
        {
            typeof(ArgumentNullException),
            typeof(MemoryOutException),
            typeof(IndexOutOfRangeException),
            typeof(NotImplementedException),
            typeof(LowBatteryLevelException),
            typeof(OutOfMemoryException)
        };

        public uint CriticalExceptionCounter { get; private set; }
        public uint NotCriticalExceptionCounter { get; private set; }

        internal bool IsCriticalException(Exception exception)
        {
            return CriticalExceptionTypes.Contains(exception?.GetType());
        }
        internal bool IsCriticalException(Type exceptionType)
        {
            if (typeof(Exception).IsAssignableFrom(exceptionType))
                return CriticalExceptionTypes.Contains(exceptionType);
            else
                throw new ArgumentException($"{exceptionType} is not exception!");
        }

        internal void HandleException(Exception exception)
        {
            if (IsCriticalException(exception))
                CriticalExceptionCounter++;
            else
                NotCriticalExceptionCounter++;
        }
        internal void HandleException(Type exceptionType)
        {
            if (IsCriticalException(exceptionType))
                CriticalExceptionCounter++;
            else
                NotCriticalExceptionCounter++;
        }
    }
}
