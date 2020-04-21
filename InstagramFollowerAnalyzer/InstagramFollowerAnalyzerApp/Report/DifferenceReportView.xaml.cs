namespace InstagramFollowerAnalyzerApp.Report
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for DifferenceReportView.xaml
    /// </summary>
    public partial class DifferenceReportView : UserControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(DifferenceReportView), new PropertyMetadata(default(string)));

        public DifferenceReportView()
        {
            this.ViewModel = new DifferenceReportViewModel();
            InitializeComponent();
        }

        public string Title
        {
            get => (string)this.GetValue(TitleProperty);
            set => this.SetValue(TitleProperty, value);
        }

        public DifferenceReportViewModel ViewModel { get; }
    }
}
