using Challenge.Mobile.Service;
using System.Windows.Input;
using Xamarin.Forms;

namespace Challenge.Mobile.ViewModels
{
    public class MenuPageViewModel : BaseViewModel
    {
        private readonly ILoginService _loginService;
        public ICommand GoHomeCommand { get; set; }
        public ICommand GoLogoutCommand { get; set; }

        public MenuPageViewModel()
        {
            _loginService = container.Resolve<ILoginService>();

            GoHomeCommand = new Command(GoHome);
            GoLogoutCommand = new Command(GoLogout);
        }

        private async void GoHome(object obj)
        {
            App.MasterDetailPage.IsPresented = false;
            await App.MasterDetailPage.Detail.Navigation.PushAsync(new HomePage());
        }

        private async void GoLogout(object obj)
        {
            App.MasterDetailPage.IsPresented = false;
            await App.MasterDetailPage.Detail.Navigation.PushAsync(new LoginPage());
        }
    }
}