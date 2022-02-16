using NUnit.Framework;
using Moq;

namespace Greeting.Test
{
    public class ManyNamesHandlerTests
    {
        private IGreeting _g;

        [SetUp]
        public void Setup()
        {
            _g = new GreetingOrchestrator();
        }

        [Test]
        public void Should_Handle_Multiple_Name()
        {
            var expected = "Hello, Andrea, Franco, and Giuseppe.";
            var actual = _g.Greet("Andrea", "Franco", "Giuseppe");

            Assert.AreEqual(expected, actual);
        }
    }
}