using Challenge.Mobile.Models;
using Challenge.Mobile.Service;
using System.Windows.Input;
using Xamarin.Forms;

namespace Challenge.Mobile.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly ILoginService _loginService;
        public string DisplayErrorMessage { get; set; }
        public User User { get; set; } = new User();
        public ICommand LoginCommand { get; set; }
        public ICommand SignUpCommand { get; set; }
        public ICommand GoToSignUpCommand { get; set; }

        public LoginPageViewModel()
        {
            _loginService = container.Resolve<ILoginService>();

            SetUserCredentialsIfExistsInDB();

            LoginCommand = InitLoginCommand();
        }

        private Command InitLoginCommand() => new Command(async () =>
        {
            if (!_loginService.HasValidCredentials(User))
            {
                DisplayErrorMessage = "Invalid credentials. Please try again.";
            }
            else
            {
                _loginService.RegisterLogin(User);
                DisplayErrorMessage = "";
                User = _loginService.CleanUser();
                this.OnPropertyChanged("User");
                await Application.Current.MainPage.Navigation.PushModalAsync(new MenuPage());
            }
            this.OnPropertyChanged("DisplayErrorMessage");
        });

        private void SetUserCredentialsIfExistsInDB()
        {
            var userCredentials = _loginService.GetRegisteredCredentials();

            if (!(userCredentials is null))
            {
                User.UserName = userCredentials.UserName;
                User.Password = userCredentials.Password;
                this.OnPropertyChanged("User");
            }
        }
    }
}