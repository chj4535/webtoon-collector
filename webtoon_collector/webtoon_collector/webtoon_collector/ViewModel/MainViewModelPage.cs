using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace webtoon_collector.ViewModel
{
    public class MainViewModelPage : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand DownloadStartCommand { get; private set; }

        public MainViewModelPage()
        {
            DownloadStartCommand = new Command(async () => await CheckComic());
        }

        async Task CheckComic()
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
