namespace InstagramFollowerAnalyzerApp.Report
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class DifferenceReportViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private const string WildCard = "'s profile picture";

        private string entriesDisplay = "Please compare to see the result.";

        private string numberDisplay = string.Empty;

        internal enum ComparisonMode
        {
            FollowersNotFollowing,
            FollowingNotFollowers,
            FollowersAndFollowing
        }

        public string EntriesDisplay
        {
            get => this.entriesDisplay;

            private set
            {
                this.entriesDisplay = value;
                this.OnPropertyChanged();
            }
        }

        public string NumberDisplay
        {
            get => this.numberDisplay;

            private set
            {
                this.numberDisplay = value;
                this.OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void SetEntries(IEnumerable<string> entries)
        {
            if (entries == null)
            {
                this.EntriesDisplay = "Please enter the inputs first";
                this.NumberDisplay = string.Empty;
                return;
            }

            IEnumerable<string> parsedEntries = entries.Where(entry => !string.IsNullOrWhiteSpace(entry) && entry.EndsWith(WildCard, StringComparison.Ordinal)).Select(entry => entry.Replace(WildCard, null)).Distinct();

            this.DisplayEntries(parsedEntries);
        }

        internal void Compare(IEnumerable<string> followers, IEnumerable<string> followings, ComparisonMode comparisonMode)
        {
            if (followers == null)
            {
                this.EntriesDisplay = "Please enter the followers first";
                this.NumberDisplay = string.Empty;
                return;
            }

            if (followings == null)
            {
                this.EntriesDisplay = "Please enter the following first";
                this.NumberDisplay = string.Empty;
                return;
            }

            var followersSet = new HashSet<string>(followers.Where(entry => !string.IsNullOrWhiteSpace(entry) && entry.EndsWith(WildCard, StringComparison.Ordinal)).Select(entry => entry.Replace(WildCard, null)));
            var followingsSet = new HashSet<string>(followings.Where(entry => !string.IsNullOrWhiteSpace(entry) && entry.EndsWith(WildCard, StringComparison.Ordinal)).Select(entry => entry.Replace(WildCard, null)));

            HashSet<string> resultSet;

            switch (comparisonMode)
            {
                case ComparisonMode.FollowersNotFollowing:
                    followersSet.ExceptWith(followingsSet);
                    resultSet = followersSet;
                    break;
                case ComparisonMode.FollowingNotFollowers:
                    followingsSet.ExceptWith(followersSet);
                    resultSet = followingsSet;
                    break;
                case ComparisonMode.FollowersAndFollowing:
                    followersSet.IntersectWith(followingsSet);
                    resultSet = followersSet;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(comparisonMode), comparisonMode, null);
            }

            this.DisplayEntries(resultSet);
        }

        private void DisplayEntries(IEnumerable<string> parsedEntries)
        {
            this.entriesDisplay = string.Empty;
            uint number = 0;

            // Sort based on the string.
            foreach (string entry in parsedEntries.OrderBy(s => s))
            {
                this.entriesDisplay += entry + Environment.NewLine;
                number++;
            }

            if (number == 0)
            {
                this.entriesDisplay = "No entry was found.";
                this.numberDisplay = string.Empty;
            }
            else
            {
                this.NumberDisplay = number.ToString();
            }

            this.OnPropertyChanged(nameof(this.EntriesDisplay));
        }
    }
}
