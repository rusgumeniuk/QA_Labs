using System;

namespace ExceptionManager.Tests
{
    class StubValidatorByMemoryWord : IExceptionTypeValidator
    {
        public bool IsExceptionType(Type type)
        {
            return !type.Name.ToUpperInvariant().Contains("MEMORY");
        }
    }
}
