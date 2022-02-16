using NUnit.Framework;

namespace Greeting.Test
{
    public class OneNameHandlerTests
    {
        private IGreeting _g;

        [SetUp]
        public void Setup()
        {
            _g = new GreetingOrchestrator();

        }

        [Test]
        public void Should_Add_Greeting_To_Name()
        {
            var expected = "Hello, Andrea.";
            var actual = _g.Greet("Andrea");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Uppercase_Name()
        {
            var expected = "HELLO ANDREA!";
            var actual = _g.Greet("ANDREA");

            Assert.AreEqual(expected, actual);
        }
    }
}