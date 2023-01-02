using Challenge.Mobile.Models;
using Challenge.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Challenge.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPageMaster : MasterDetailPage
    {
        public MenuPageMaster()
        {
            InitializeComponent();
            BindingContext = new MenuPageViewModel();
            Master = new MenuPage();
            Detail = new NavigationPage(new MainPage());
            App.MasterDetailPage = this;
        }
    }
}