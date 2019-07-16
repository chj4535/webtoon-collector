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
        TestEvent testevnet = new TestEvent();
        public event PropertyChangedEventHandler PropertyChanged;
        MainModelPage mainModelpage = new MainModelPage();

        public ObservableCollection<ComicInfo> comicList { get; set; }

        public ICommand DownloadStartCommand { get; private set; }
        public ICommand TestCommand { get; private set; }


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

        private string _testValue;
        public string testValue
        {
            get
            {
                return _testValue;
            }

            set
            {
                if (_testValue == value) return;
                _testValue = value;
                OnPropertyChanged("testValue");
            }
        }

        public ComicInfo WebtoonName;

        public MainViewModelPage()
        {
            testValue = "hello";
            comicList = new ObservableCollection<ComicInfo>();
            DownloadStartCommand = new Command(async () => await CheckComic());
            TestCommand = new Command(Test);
            testevnet.testevent += new EventHandler(testevnet2);
        }
        void testevnet2(object sender, EventArgs e)
        {
            testValue = sender as string;
        }
        public void Test()
        {
            mainModelpage.Test(testevnet,"hi");
        }

        public void DownLoadComic(ComicInfo comIcInfo)
        {
            mainModelpage.DownLoadNaverWebtoonImgList(comIcInfo);
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
