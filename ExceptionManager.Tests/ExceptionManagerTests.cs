using ExceptionManager.Tests.Exceptions;
using System;
using Xunit;

namespace ExceptionManager.Tests
{
    public class ExceptionManagerTests
    {
        ExceptionManager manager;
        public ExceptionManagerTests()
        {
            manager = new ExceptionManager();
        }

        [Theory]
        [InlineData(typeof(LowBatteryLevelException))]
        [InlineData(typeof(ArgumentNullException))]
        [InlineData(typeof(OutOfMemoryException))]
        [InlineData(typeof(IndexOutOfRangeException))]
        public void IsCriticalException_WhenCriticalException_ReturnsTrue(Type exceptionType)
        {
            //ExceptionManager manager = new ExceptionManager();

            Assert.True(manager.IsCriticalException(exceptionType));
        }

        [Theory]
        [InlineData(typeof(MediumBatteryLevelException))]
        [InlineData(typeof(ArgumentException))]
        [InlineData(typeof(ArithmeticException))]
        [InlineData(typeof(DuplicateWaitObjectException))]
        public void IsCriticalException_WhenNotCriticalException_ReturnsFalse(Type exceptionType)
        {
            //ExceptionManager manager = new ExceptionManager();

            Assert.False(manager.IsCriticalException(exceptionType));
        }

        [Theory]
        [InlineData(typeof(String))]
        [InlineData(typeof(OperatingSystem))]
        [InlineData(typeof(AppContext))]
        public void IsCriticalException_WhenTypeIsNotExceptionType_ThrowArgumentException(Type type)
        {
            //ExceptionManager manager = new ExceptionManager();

            Assert.Throws<ArgumentException>(() => manager.IsCriticalException(type));
        }

        [Fact]
        public void HandleException_WhenZeroBothCounters_ReturnsTrue()
        {

            Assert.True(manager.CriticalExceptionCounter == 0);
            Assert.True(manager.NotCriticalExceptionCounter == 0);
        }

        [Fact]
        public void HandleException_When3CriticalAnd4NotCriticalExceptions_ReturnsTrue()
        {
            Type[] array = new Type[]
            {
                typeof(ArgumentException),
                typeof(ArgumentNullException),
                typeof(EntryPointNotFoundException),
                typeof(MemoryOutException),
                typeof(FieldAccessException),
                typeof(NotImplementedException),
                typeof(FormatException)
            };

            foreach (var type in array)
            {
                manager.HandleException(type);
            }


            Assert.True(manager.CriticalExceptionCounter == 3);
            Assert.True(manager.NotCriticalExceptionCounter == 4);
        }
    }
}
