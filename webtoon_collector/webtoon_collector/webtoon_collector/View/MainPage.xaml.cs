using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using webtoon_collector.ViewModel;
using webtoon_collector.View;

namespace webtoon_collector
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MainViewModelPage mainViewmodelpage = new MainViewModelPage();


        public MainPage()
        {
            InitializeComponent();
            BindingContext = mainViewmodelpage;
        }

        public void Button_Naver(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ComicPage_Naver(mainViewmodelpage));
        }
    }
}
