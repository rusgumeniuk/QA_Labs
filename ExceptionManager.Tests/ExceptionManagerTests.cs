using ExceptionManager.Tests.Exceptions;
using NSubstitute;
using System;
using Xunit;

namespace ExceptionManager.Tests
{
    public class ExceptionManagerTests
    {
        ExceptionManager manager;
        public ExceptionManagerTests()
        {
            StubExceptionTypeValidatorFactory.SetValidator(new StubValidatorByMemoryWord());
            manager = new ExceptionManager(new StubSender());
            manager.ExceptionVerifyier = new StubVerifierByArgumentAndOutWords();
        }

        [Theory]
        [InlineData(typeof(ArgumentNullException))]
        [InlineData(typeof(ArgumentOutOfRangeException))]
        [InlineData(typeof(IndexOutOfRangeException))]
        public void IsCriticalException_WhenCriticalException_ReturnsTrue(Type exceptionType)
        {
            //ExceptionManager manager = new ExceptionManager();

            Assert.True(manager.IsCriticalException(exceptionType));
        }

        [Theory]
        [InlineData(typeof(MediumBatteryLevelException))]
        [InlineData(typeof(ArithmeticException))]
        [InlineData(typeof(DuplicateWaitObjectException))]
        public void IsCriticalException_WhenNotCriticalException_ReturnsFalse(Type exceptionType)
        {
            //ExceptionManager manager = new ExceptionManager();

            Assert.False(manager.IsCriticalException(exceptionType));
        }

        [Theory]
        [InlineData(typeof(MemoryOutException))]
        [InlineData(typeof(InsufficientMemoryException))]
        [InlineData(typeof(OutOfMemoryException))]
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
                typeof(IndexOutOfRangeException),
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

        [Fact]
        public void NorifyServer_When2ErrorOnSending_Returns2()
        {
            var mockSender = Substitute.For<ISender>();
            mockSender.When(x => x.NotifyServer(Arg.Any<Exception>()).ReturnsForAnyArgs(false));
            manager = new ExceptionManager(mockSender);
            manager.ExceptionVerifyier = new StubVerifierByArgumentAndOutWords();

            manager.HandleException(typeof(ArgumentNullException));
            manager.HandleException(typeof(ArgumentException));

            Assert.Equal((uint)2, manager.CounterOfWrongSending);
        }
    }
}
