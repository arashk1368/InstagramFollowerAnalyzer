using System.Windows;

namespace InstagramFollowerAnalyzerApp
{
    using InstagramFollowerAnalyzerApp.Report;

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
            this.FollowersReport.ViewModel.SetEntries(this.FollowersInput.ViewModel.Entries);
            this.FollowingReport.ViewModel.SetEntries(this.FollowingInput.ViewModel.Entries);

            this.FollowersNotFollowingReport.ViewModel.Compare(this.FollowersInput.ViewModel.Entries, this.FollowingInput.ViewModel.Entries, DifferenceReportViewModel.ComparisonMode.FollowersNotFollowing);
            this.FollowingNotFollowerReport.ViewModel.Compare(this.FollowersInput.ViewModel.Entries, this.FollowingInput.ViewModel.Entries, DifferenceReportViewModel.ComparisonMode.FollowingNotFollowers);
            this.FollowersAndFollowingReport.ViewModel.Compare(this.FollowersInput.ViewModel.Entries, this.FollowingInput.ViewModel.Entries, DifferenceReportViewModel.ComparisonMode.FollowersAndFollowing);
        }
    }
}
