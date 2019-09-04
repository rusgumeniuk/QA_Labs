using System;

namespace ExceptionManager.Tests
{
    interface IExceptionTypeValidator
    {
        bool IsExceptionType(Type type);
    }
}
