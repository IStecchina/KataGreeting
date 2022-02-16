using NUnit.Framework;
using System;

namespace Greeting.Test
{
    public class OrchestratorTests
    {
        private IGreeting _g;

        [SetUp]
        public void Setup()
        {
            _g = new GreetingOrchestrator();
        }

        [Test]
        public void SimpleGreeting()
        {
            var expected = "Hello, Andrea.";
            var actual = _g.Greet("Andrea");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NullGreeting()
        {
            var expected = "Hello, my friend.";
            var actual1 = _g.Greet(null);
            var actual2 = _g.Greet(Array.Empty<string>());

            Assert.AreEqual(expected, actual1);
            Assert.AreEqual(expected, actual2);
        }

        [Test]
        public void ManyNamesGreeting()
        {
            var expected = "Hello, Andrea and Franco.";
            var actual = _g.Greet("Andrea", "Franco");
            Assert.AreEqual(expected, actual);

            expected = "Hello, Andrea, Franco, and Giuseppe.";
            actual = _g.Greet("Andrea", "Franco", "Giuseppe");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UppercaseGreeting()
        {
            var expected = "HELLO ANDREA!";
            var actual = _g.Greet("ANDREA");
            Assert.AreEqual(expected, actual);

            expected = "HELLO ANDREA! AND HELLO FRANCO!";
            actual = _g.Greet("ANDREA", "FRANCO");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MixedCaseGreeting()
        {
            var expected = "Hello, Andrea and Franco. AND HELLO GIUSEPPE!";
            var actual = _g.Greet("Andrea", "Franco", "GIUSEPPE");
            Assert.AreEqual(expected, actual);

            expected = "Hello, Andrea and Giuseppe. AND HELLO FRANCO!";
            actual = _g.Greet("Andrea", "FRANCO", "Giuseppe");
            Assert.AreEqual(expected, actual);

            expected = "Hello, Andrea. AND HELLO FRANCO!";
            actual = _g.Greet("Andrea", "FRANCO");
            Assert.AreEqual(expected, actual);

            expected = "Hello, Andrea. AND HELLO FRANCO! AND HELLO GIUSEPPE!";
            actual = _g.Greet("Andrea", "FRANCO", "GIUSEPPE");
            Assert.AreEqual(expected, actual);

            expected = "Hello, Franco. AND HELLO ANDREA! AND HELLO GIUSEPPE!";
            actual = _g.Greet("ANDREA", "Franco", "GIUSEPPE");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MultiNameEntriesGreeting()
        {
            var expected = "Hello, Andrea, Franco, and Giuseppe.";
            var actual = _g.Greet("Andrea", "Franco, Giuseppe");
            Assert.AreEqual(expected, actual);

            expected = "Hello, Andrea, Franco, and Giuseppe.";
            actual = _g.Greet("Andrea", "Franco,Giuseppe");
            Assert.AreEqual(expected, actual);

            expected = "Hello, Andrea, Franco, and Giuseppe.";
            actual = _g.Greet("  Andrea ", "Franco ,Giuseppe");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NamesWithCommasGreeting()
        {
            var expected = "Hello, Andrea and Franco, Giuseppe.";
            var actual = _g.Greet("Andrea", "\"Franco, Giuseppe\"");
            Assert.AreEqual(expected, actual);

            expected = "Hello, Andrea and Franco,Giuseppe.";
            actual = _g.Greet("Andrea", "\"Franco,Giuseppe\"");
            Assert.AreEqual(expected, actual);

            expected = "Hello, Andrea, Franco, Giuseppe, and ,,,.";
            actual = _g.Greet("  Andrea ", "Franco,Giuseppe", "\",,,\"");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EdgeCaseGreeting()
        {
            var expected = "Hello, 1.";
            var actual = _g.Greet("1");
            Assert.AreEqual(expected, actual);

            expected = "Hello, Franco and Giuseppe.";
            actual = _g.Greet(null, "Franco", "Giuseppe");
            Assert.AreEqual(expected, actual);

            expected = "Hello, my friend.";
            actual = _g.Greet(null, "\"\"", "  ", "\"  \"");
            Assert.AreEqual(expected, actual);
        }

    }
}