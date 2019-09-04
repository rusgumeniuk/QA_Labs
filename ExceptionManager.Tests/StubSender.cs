using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionManager.Tests
{
    class StubSender : ISender
    {
        public uint CounterOfWrongNotifying { get; set; } = 0;

        public bool NotifyServer(Exception exception)
        {
            return ContainsWordNull(exception.GetType().Name);
        }

        public bool NotifyServer(Type exceptionType)
        {
            return ContainsWordNull(exceptionType.Name);
            
        }

        private bool ContainsWordNull(string name)
        {
            return name.ToUpperInvariant().Contains("NULL");
        }
    }
}
