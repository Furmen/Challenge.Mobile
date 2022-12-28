using Challenge.Mobile.Service;
using System.Windows.Input;
using Xamarin.Forms;

namespace Challenge.Mobile.ViewModels
{
    public class MenuPageViewModel : BaseViewModel
    {
        private readonly ILoginService _loginService;
        public ICommand GoHomeCommand { get; set; }
        public ICommand GoSecondCommand { get; set; }
        public ICommand GoThirdCommand { get; set; }

        public MenuPageViewModel()
        {
            _loginService = container.Resolve<ILoginService>();

            GoHomeCommand = new Command(GoHome);
            GoSecondCommand = new Command(GoSecond);
            GoThirdCommand = new Command(GoThird);
        }

        private void GoHome(object obj)
        {
            Application.Current.MainPage.Navigation.PopToRootAsync();
        }

        private void GoSecond(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(new HomePage());
        }

        private void GoThird(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
    }
}