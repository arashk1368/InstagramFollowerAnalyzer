using System.Windows.Controls;

namespace InstagramFollowerAnalyzerApp.FollowerInput
{
    using System.Windows;

    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for FollowerInput.xaml
    /// </summary>
    public partial class FollowerInput : UserControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(FollowerInput), new PropertyMetadata(default(string)));

        public FollowerInput()
        {
            this.ViewModel = new FollowerInputViewModel();
            InitializeComponent();
        }

        public string Title
        {
            get => (string)this.GetValue(TitleProperty);
            set => this.SetValue(TitleProperty, value);
        }

        public FollowerInputViewModel ViewModel { get; }

        private void BrowseFileClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog { FileName = string.Empty, Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*", Title = "Open File", CheckFileExists = true, CheckPathExists = true, };
            if (openFileDialog.ShowDialog() == true)
            {
                this.ViewModel.LoadFile(openFileDialog.FileName);
            }
        }
    }
}
