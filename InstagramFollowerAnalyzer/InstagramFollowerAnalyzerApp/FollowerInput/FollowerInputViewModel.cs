namespace InstagramFollowerAnalyzerApp.FollowerInput
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class FollowerInputViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string peopleList;

        public string Followers
        {
            get => this.peopleList;

            set
            {
                this.peopleList = value;
                this.OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
