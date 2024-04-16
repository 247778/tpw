using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Threading;
using Dane;
using Logika;


namespace Project.ViewModel
{
    public class BallViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Ball> Balls { get; set; } = new ObservableCollection<Ball>();

        private readonly BallLogic _ballLogic = new BallLogic();

        private readonly DispatcherTimer _timer = new DispatcherTimer();

        private readonly Random _random = new Random();

        public BallViewModel()
        {
            _timer.Interval = TimeSpan.FromMilliseconds(20);
            _timer.Tick += async (s, e) => await MoveBallsAsync();
        }

        public void InitializeBalls(int numberOfBalls)
        {
            Balls.Clear();
            for (int i = 0; i < numberOfBalls; i++)
            {
                Balls.Add(_ballLogic.CreateBall());
            }
            if (!_timer.IsEnabled)
            {
                _timer.Start();
            }
        }

        private async Task MoveBallsAsync()
        {
            var moveTasks = new List<Task>();
            foreach (var ball in Balls)
            {
                moveTasks.Add(Task.Run(() =>
                {
                    _ballLogic.Move(ball);
                }));
            }
            await Task.WhenAll(moveTasks);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
