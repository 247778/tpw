using Dane;
using System;

namespace Logika
{
    public class BallLogic
    {
        private const int BallDiameter = 100;
        private const int CanvasWidth = 880;
        private const int CanvasHeight = 425;
        private const int OffsetX = 0;
        private const int OffsetY = 0;
        private readonly Random _random = new Random();

        public Ball Move(Ball ball)
        {
            ball.X += ball.VelocityX;
            ball.Y += ball.VelocityY;

            if (ball.X <= 0 + OffsetX || ball.X >= CanvasWidth - BallDiameter + OffsetX)
            {
                ball.VelocityX = -ball.VelocityX;
            }
            if (ball.Y <= 0 + OffsetY || ball.Y >= CanvasHeight - BallDiameter + OffsetY)
            {
                ball.VelocityY = -ball.VelocityY;
            }

            return ball;
        }

        public Ball CreateBall()
        {
            Ball ball = new Ball
            {
                X = _random.Next(0, 828 - 100),
                Y = _random.Next(0, 373 - 100),
                VelocityX = 5 * (_random.Next(2) == 0 ? 1 : -1),
                VelocityY = 5 * (_random.Next(2) == 0 ? 1 : -1)
            };
            return ball;
        }
    }
}
