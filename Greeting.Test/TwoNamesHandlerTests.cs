using NUnit.Framework;

namespace Greeting.Test
{
    public class TwoNamesHandlerTests
    {
        private IGreeting _g;

        [SetUp]
        public void Setup()
        {
            _g = new GreetingOrchestrator();
        }

        [Test]
        public void Should_Handle_Two_Name()
        {
            var expected = "Hello, Andrea and Franco.";
            var actual = _g.Greet("Andrea", "Franco");
            Assert.AreEqual(expected, actual);
        }
    }
}