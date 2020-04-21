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
            InitializeComponent();
        }

        private void CompareButtonClick(object sender, RoutedEventArgs e)
        {
            this.DifferenceReport.ViewModel.Compare(this.FollowersInput.ViewModel.Entries, this.FollowingInput.ViewModel.Entries);
            this.FollowersReport.ViewModel.SetEntries(this.FollowersInput.ViewModel.Entries);
            this.FollowingReport.ViewModel.SetEntries(this.FollowingInput.ViewModel.Entries);
        }
    }
}
