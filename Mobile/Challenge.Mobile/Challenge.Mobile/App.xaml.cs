using Challenge.Mobile.Infrastructure;
using Challenge.Mobile.Models;
using Challenge.Mobile.Service;
using Nancy.TinyIoc;
using Xamarin.Forms;

namespace Challenge.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var container = TinyIoCContainer.Current;

            #region DB Setters

            var connection = Sqlite.ConnectionDB;
            connection.CreateTable<User>();

            #endregion DB Setters

            #region Services

            container.Register<ILoginService, LoginService>().AsMultiInstance();

            #endregion Services

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}