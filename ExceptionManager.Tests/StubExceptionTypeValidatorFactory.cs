namespace ExceptionManager.Tests
{
    class StubExceptionTypeValidatorFactory
    {
        private static IExceptionTypeValidator exceptionTypeValidator = null;

        internal static IExceptionTypeValidator CreateValidator()
        {
            return exceptionTypeValidator ?? (exceptionTypeValidator = new StubValidatorByMemoryWord());
        }

        internal static void SetValidator(IExceptionTypeValidator validator)
        {
            exceptionTypeValidator = validator;
        }
    }
}
