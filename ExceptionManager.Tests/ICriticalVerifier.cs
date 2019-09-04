using System;

namespace ExceptionManager.Tests
{
    interface ICriticalVerifier
    {
        bool IsCriticalException(Exception exception);
        bool IsCriticalException(Type exceptionType);
    }
}
