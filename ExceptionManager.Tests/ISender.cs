using System;

namespace ExceptionManager.Tests
{
    public interface ISender
    {
        uint CounterOfWrongNotifying { get; set; }
        bool NotifyServer(Exception exception);
        bool NotifyServer(Type exceptionType);
    }
}
