using System.ComponentModel;

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
