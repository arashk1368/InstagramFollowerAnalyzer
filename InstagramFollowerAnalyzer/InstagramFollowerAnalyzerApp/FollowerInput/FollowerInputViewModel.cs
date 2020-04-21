namespace InstagramFollowerAnalyzerApp.FollowerInput
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.CompilerServices;

    public class FollowerInputViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string followers = "Please paste here or browse from file...";

        public string Followers
        {
            get => this.followers;

            set
            {
                this.followers = value;
                this.OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void LoadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                this.Followers = "The file does not exist, please select a valid file.";
                return;
            }

            this.followers = string.Empty;

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

                    this.followers += line + Environment.NewLine;
                }
            }
            catch (Exception exception)
            {
                this.followers = $"Could not read file : {exception}";
            }

            this.OnPropertyChanged(nameof(this.Followers));
        }
    }
}
