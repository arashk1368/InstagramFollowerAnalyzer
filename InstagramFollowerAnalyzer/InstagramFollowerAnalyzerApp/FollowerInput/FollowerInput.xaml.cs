using System.Windows.Controls;

namespace InstagramFollowerAnalyzerApp.FollowerInput
{
    using System.Windows;

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

    }
}
