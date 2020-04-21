namespace InstagramFollowerAnalyzerApp
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using InstagramFollowerAnalyzerApp.FollowerInput;

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
