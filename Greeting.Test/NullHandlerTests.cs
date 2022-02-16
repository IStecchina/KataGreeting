using NUnit.Framework;

namespace Greeting.Test
{
    public class NullHandlerTests
    {
        private IGreeting _g;

        [SetUp]
        public void Setup()
        {
            _g = new GreetingOrchestrator();
        }

        [Test]
        public void Should_Handle_Null_Name()
        {
            var expected = "Hello, my friend.";
            var actual = _g.Greet(null);

            Assert.AreEqual(expected, actual);
        }
    }
}
