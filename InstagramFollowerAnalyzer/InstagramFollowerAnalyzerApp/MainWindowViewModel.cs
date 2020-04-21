namespace InstagramFollowerAnalyzerApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string comparisonResult = "Please compare to see the result.";

        public string ComparisonResult
        {
            get => this.comparisonResult;

            private set
            {
                this.comparisonResult = value;
                this.OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void Compare(IEnumerable<string> followers, IEnumerable<string> followings)
        {
            if (followers == null)
            {
                this.ComparisonResult = "Please enter the followers first";
                return;
            }

            if (followings == null)
            {
                this.ComparisonResult = "Please enter the following first";
                return;
            }

            // Makes them unique.
            var followersSet = new HashSet<string>(followers);
            var followingsSet = new HashSet<string>(followings);

            followingsSet.ExceptWith(followersSet);

            this.comparisonResult = string.Empty;

            foreach (string difference in followingsSet)
            {
                this.comparisonResult += difference + Environment.NewLine;
            }

            if (this.comparisonResult == string.Empty)
            {
                this.comparisonResult = "No difference was found.";
            }

            this.OnPropertyChanged(nameof(this.ComparisonResult));
        }
    }
}
