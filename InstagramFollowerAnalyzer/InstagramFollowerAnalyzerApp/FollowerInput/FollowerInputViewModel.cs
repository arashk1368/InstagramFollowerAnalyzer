namespace InstagramFollowerAnalyzerApp.FollowerInput
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.CompilerServices;

    public class FollowerInputViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string entriesToDisplay = "Please paste here or browse from file...";

        public string EntriesToDisplay
        {
            get => this.entriesToDisplay;

            private set
            {
                this.entriesToDisplay = value;
                this.OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void LoadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                this.EntriesToDisplay = "The file does not exist, please select a valid file.";
                return;
            }

            this.entriesToDisplay = string.Empty;

            try
            {
                using var streamReader = new StreamReader(filePath);

                while (streamReader.Peek() >= 0)
                {
                    string line = streamReader.ReadLine();

                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    this.entriesToDisplay += line + Environment.NewLine;
                }
            }
            catch (Exception exception)
            {
                this.entriesToDisplay = $"Could not read file : {exception}";
            }

            this.OnPropertyChanged(nameof(this.EntriesToDisplay));
        }
    }
}
