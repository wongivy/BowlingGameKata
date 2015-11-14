
using BowlingGameKata.Models;
using NUnit.Framework;

namespace BowlingGameKata.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        private Game g;

        [TestFixtureSetUp]
        public void setUp()
        {
            g = new Game();
        }

        private void rollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                g.roll(pins);
            }
        }

        [Test]
        public void testGutterGame()
        {
            rollMany(20, 0);
            Assert.AreEqual(0, g.score());
        }

        [Test]
        public void testAllOnes()
        {
            rollMany(20, 1);
            Assert.AreEqual(20, g.score());
        }

        [Test]
        public void testOneSpare()
        {
            rollSpare();
            g.roll(3);
            rollMany(17, 0);
            Assert.AreEqual(16, g.score());
        }

        [Test]
        public void testTwoStrike()
        {
            rollStrike();
            g.roll(3);
            g.roll(4);
            rollMany(16, 0);
            Assert.AreEqual(24, g.score());
        }

        [Test]
        public void testPerfectGame()
        {
            rollMany(12, 10);
            Assert.AreEqual(300, g.score());
        }

        public void rollStrike()
        {
            g.roll(10);
        }

        private void rollSpare()
        {
            g.roll(5);
            g.roll(5);
        }
    }
}

