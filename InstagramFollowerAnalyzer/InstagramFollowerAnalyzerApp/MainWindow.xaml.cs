using System.Windows;

namespace InstagramFollowerAnalyzerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.ViewModel = new MainWindowViewModel();
            InitializeComponent();
        }

        public MainWindowViewModel ViewModel { get; }

        private void CompareButtonClick(object sender, RoutedEventArgs e)
        {
            this.ViewModel.Compare(this.FollowersInput.ViewModel.Entries, this.FollowingInput.ViewModel.Entries);
        }
    }
}
