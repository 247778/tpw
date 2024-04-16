using System.Windows;


namespace Project.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel.BallViewModel();
        }

        public void GenerateBalls(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModel.BallViewModel viewModel)
            {
                if (int.TryParse(NumberInput.Text, out int numberOfBalls))
                {
                    viewModel.InitializeBalls(numberOfBalls);
                }
                else
                {
                    MessageBox.Show("Wpisz prawidłową liczbę");
                }
            }
        }
    }
}
