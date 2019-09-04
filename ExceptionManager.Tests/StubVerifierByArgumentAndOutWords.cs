using System;

namespace ExceptionManager.Tests
{
    class StubVerifierByArgumentAndOutWords : ICriticalVerifier
    {
        public bool IsCriticalException(Exception exception)
        {
            return IsContainsHelpWord(exception.GetType().Name);
        }

        public bool IsCriticalException(Type exceptionType)
        {
            return IsContainsHelpWord(exceptionType.Name);
        }
        private bool IsContainsHelpWord(string exceptionName)
        {
            return exceptionName.ToUpperInvariant().Contains("ARGUMENT") || exceptionName.ToUpperInvariant().Contains("OUT");
        }
    }
}
