using Challenge.Mobile.Service;
using Challenge.Mobile.ViewModels;
using Nancy.TinyIoc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Challenge.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel();
        }

        private void PasswordVisibility(object sender, EventArgs e)
        {
            passwordVisibility.Source = !passwordEntry.IsPassword ? "ic_ShowPassword" : "ic_hidden";
            passwordEntry.IsPassword = !passwordEntry.IsPassword;
        }
    }
}