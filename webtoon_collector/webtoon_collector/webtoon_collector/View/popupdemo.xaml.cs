using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webtoon_collector.Model.ClassCollect;
using webtoon_collector.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace webtoon_collector.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class popupdemo : Rg.Plugins.Popup.Pages.PopupPage
    {
        MainViewModelPage mainViewmodelpage;
        ComicInfo comicInfo;
        public popupdemo(ComicInfo comicInfo,MainViewModelPage mainViewmodelpage)
        {
            this.mainViewmodelpage = mainViewmodelpage;
            this.comicInfo = comicInfo;
            InitializeComponent();
            TitleImg.Source = comicInfo.TitleImgUrl;
            TitleName.Text = comicInfo.Title;
            Autor.Text = comicInfo.Autor;
            StartEpisode.Text = "StartEpisode : " + comicInfo.StartEpisode;
            EndEpisode.Text = "EndEpisode : " + comicInfo.EndEpisode;
        }

        private async void Button_AddComic(object sender, EventArgs e)
        {
            mainViewmodelpage.comicList.Add(comicInfo);
            await PopupNavigation.PopAsync();
        }

        private async void Button_Cancel(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync();
        }
    }
}