using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using webtoon_collector.Model;
using webtoon_collector.Model.ClassCollect;
using webtoon_collector.View;
using Xamarin.Forms;

namespace webtoon_collector.ViewModel
{
    public class MainViewModelPage : INotifyPropertyChanged
    {
        MainModelPage mainModelpage = new MainModelPage();
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ComicInfo> comicList { get; set; }
        
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

        public ComicInfo WebtoonName;

        public MainViewModelPage()
        {
            comicList = new ObservableCollection<ComicInfo>();
            DownloadStartCommand = new Command(DownComic);
            //DownloadStartCommand = new Command(async () => await CheckComic());
        }

        public void DownComic()
        {
            ComicInfo testcomic = new ComicInfo()
            {
                Autor = "tester",
                StartEpisode = "1",
                EndEpisode = "3",
                Title = "쿠베라",
                TitleId = "131385"
            };
            mainModelpage.GetNaverWebtoonImgList(testcomic);


        }
        async Task CheckComic()
        {

            WebtoonName = mainModelpage.GetWebtoonTitle(titleId);
            WebtoonName.StartEpisode = startEpisod;
            WebtoonName.EndEpisode = endEpisod;
            await PopupNavigation.PushAsync(new popupdemo(WebtoonName,this));
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
