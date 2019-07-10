using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webtoon_collector.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace webtoon_collector.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComicPage_Naver : ContentPage
    {
        public ComicPage_Naver(MainViewModelPage mainViewmodelpage)
        {
            InitializeComponent();
            BindingContext = mainViewmodelpage;
        }
    }
}