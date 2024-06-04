using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Threading;
using Dane;
using Logika;


namespace ProjectWorking.ViewModel
{
    public class BallViewModel /*: INotifyPropertyChanged */
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Ball> Balls { get; set; } = new ObservableCollection<Ball>();

        private readonly BallLogic _ballLogic = new BallLogic();

        private readonly DispatcherTimer _timer = new DispatcherTimer();

        private readonly Random _random = new Random();

        private Logger logger;

        private DispatcherTimer loggingTimer = new DispatcherTimer();

        public BallViewModel()
        {
            _timer.Interval = TimeSpan.FromMilliseconds(20);
            _timer.Tick += async (s, e) => await MoveBallsAsync();
            loggingTimer.Interval = TimeSpan.FromSeconds(1);
            loggingTimer.Tick += async (s, e) => await LogBallsAsync();
            logger = new Logger("C:\\Users\\silk7\\source\\repos\\tpw\\ball_logs.json");
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
            if (!loggingTimer.IsEnabled)
            {
                loggingTimer.Start();
            }
        }
        private static readonly object collisionLock = new object();
        private async Task MoveBallsAsync()
        {
            var moveTasks = new List<Task>();
            foreach (var ball in Balls)
            {
                moveTasks.Add(Task.Run(() =>
                {
                    _ballLogic.Move(ball);
                    lock (collisionLock)
                    {
                        _ballLogic.CheckAndHandleCollision(ball, Balls);
                    }
                }));
            }
            await Task.WhenAll(moveTasks);
        }

        private async void StartLogging()
        {
            
            while (true)
            {
                await logger.LogAsync(Balls);
            await Task.Delay(1000); // Log every second
            }
        }
        private async Task LogBallsAsync()
        {
            await logger.LogAsync(Balls);
        }
    }
}
