using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using webtoon_collector.Model;
using Xamarin.Forms;

namespace webtoon_collector.ViewModel
{
    public class MainViewModelPage : INotifyPropertyChanged
    {
        MainModelPage mainModelpage = new MainModelPage();
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand DownloadStartCommand { get; private set; }

        private string _titleId;
        public string titleId
        {
            get
            {
                return _titleId;
            }

            set
            {
                if (_titleId == value) return;
                _titleId = value;
                OnPropertyChanged("titleId");
            }
        }

        private string _startEpisod;
        public string startEpisod
        {
            get
            {
                return _startEpisod;
            }

            set
            {
                if (_startEpisod == value) return;
                _startEpisod = value;
                OnPropertyChanged("startEpisod");
            }
        }

        private string _endEpisod;
        public string endEpisod
        {
            get
            {
                return _endEpisod;
            }

            set
            {
                if (_endEpisod == value) return;
                _endEpisod = value;
                OnPropertyChanged("endEpisod");
            }
        }

        public string WebtoonName;

        public MainViewModelPage()
        {
            DownloadStartCommand = new Command(async () => await CheckComic());
        }

        async Task CheckComic()
        {

            WebtoonName = mainModelpage.GetWebtoonTitle(titleId);
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
