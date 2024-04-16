using Dane;
using NUnit.Framework;

namespace DaneTest
{
    public class BallTests
    {
        private Ball ball;

        [SetUp]
        public void Setup()
        {
            ball = new Ball();
        }

        [Test]
        public void TestVelocity()
        {
            double expectedVelocityX = 5;
            double expectedVelocityY = -3;

            ball.VelocityX = expectedVelocityX;
            ball.VelocityY = expectedVelocityY;

            Assert.AreEqual(expectedVelocityX, ball.VelocityX);
            Assert.AreEqual(expectedVelocityY, ball.VelocityY);
        }
    }
}
