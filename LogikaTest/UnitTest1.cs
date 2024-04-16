using Logika;
using Dane;
using NUnit.Framework;

namespace LogikaTest
{
    public class BallLogicTest
    {
        private BallLogic _ballLogic;

        [SetUp]
        public void Setup()
        {
            _ballLogic = new BallLogic();
        }

        [Test]
        public void Move_UpdatesBallPositionAccordingToVelocity()
        {
            Ball ball = new Ball
            {
                X = 100,
                Y = 100,
                VelocityX = 2,
                VelocityY = -3
            };

            Ball movedBall = _ballLogic.Move(ball);

            Assert.AreEqual(102, movedBall.X);
            Assert.AreEqual(97, movedBall.Y);
        }
    }
}
