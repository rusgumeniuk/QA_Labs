using System;

namespace ExceptionManager.Tests
{
    class ExceptionManager
    {
        private readonly ISender sender;
        private readonly IExceptionTypeValidator typeValidator;
        public ICriticalVerifier ExceptionVerifyier { get; set; }

        public uint CriticalExceptionCounter { get; private set; }
        public uint NotCriticalExceptionCounter { get; private set; }

        public uint CounterOfWrongSending
        {
            get => sender.CounterOfWrongNotifying;
            private set => sender.CounterOfWrongNotifying = value;
        }

        public ExceptionManager(ISender sender1)
        {
            this.sender = sender1;
            typeValidator = StubExceptionTypeValidatorFactory.CreateValidator();
        }        

        internal bool IsCriticalException(Exception exception)
        {
            return ExceptionVerifyier.IsCriticalException(exception);
        }
        internal bool IsCriticalException(Type exceptionType)
        {
            if (typeValidator.IsExceptionType(exceptionType))
                return ExceptionVerifyier.IsCriticalException(exceptionType);
            else
                throw new ArgumentException($"{exceptionType} is not exception!");
        }

        internal void HandleException(Exception exception)
        {
            if (IsCriticalException(exception))
            {
                CriticalExceptionCounter++;
                if (!sender.NotifyServer(exception))
                    CounterOfWrongSending++;
            }
            else
                NotCriticalExceptionCounter++;
        }
        internal void HandleException(Type exceptionType)
        {
            if (IsCriticalException(exceptionType))
            {
                CriticalExceptionCounter++;
                if (!sender.NotifyServer(exceptionType))
                    CounterOfWrongSending++;
            }
            else
                NotCriticalExceptionCounter++;
        }
    }
}
