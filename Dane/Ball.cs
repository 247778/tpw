using System.ComponentModel;
using System.Drawing;

namespace Dane
{
    public class Ball : INotifyPropertyChanged
    {
        private double _x;
        private double _y;
        private double _velocityX;
        private double _velocityY;

        public double X
        {
            get { return _x; }
            set
            {
                if (_x != value)
                {
                    _x = value;
                    NotifyPropertyChanged("X");
                    UpdateRect();
                }
            }
        }

        public double Y
        {
            get { return _y; }
            set
            {
                if (_y != value)
                {
                    _y = value;
                    NotifyPropertyChanged("Y");
                    UpdateRect();
                }
            }
        }

        public double VelocityX
        {
            get { return _velocityX; }
            set { _velocityX = value; }
        }

        public double VelocityY
        {
            get { return _velocityY; }
            set { _velocityY = value; }
        }

        private Rectangle collisionRect;
        public Rectangle CollisionRect => collisionRect;
        public double Mass = 5.0;

        private void UpdateRect()
        {
            collisionRect.X = (int)Math.Round(X);
            collisionRect.Y = (int)Math.Round(Y);
        }
        public Ball()
        {
            collisionRect = new Rectangle((int)Math.Round(X), (int)Math.Round(Y), 49, 49);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
