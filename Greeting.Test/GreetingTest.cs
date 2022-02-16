using NUnit.Framework;

namespace Greeting.Test
{
    public class GreetingTests
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
        public void Should_Handle_Null_Name()
        {
            var expected = "Hello, my friend.";
            var actual = _g.Greet(null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Uppercase_Name()
        {
            var expected = "HELLO ANDREA!";
            var actual = _g.Greet("ANDREA");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Two_Name()
        {
            var expected = "Hello, Andrea and Franco.";
            var actual = _g.Greet("Andrea", "Franco");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Multiple_Name()
        {
            var expected = "Hello, Andrea, Franco, and Giuseppe.";
            var actual = _g.Greet("Andrea", "Franco", "Giuseppe");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Multiple_Name_With_Upper()
        {
            var expected = "Hello, Andrea and Franco. AND HELLO GIUSEPPE!";
            var actual = _g.Greet("Andrea", "Franco", "GIUSEPPE");

            Assert.AreEqual(expected, actual);
        }
        
    }
}