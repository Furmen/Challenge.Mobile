using Challenge.Mobile.Models;
using Challenge.Mobile.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Challenge.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : MasterDetailPage
    {
        public MenuPage()
        {
            BindingContext = new MenuPageViewModel();
            InitializeComponent();
            MyMenu();
        }

        public void MyMenu()
        {
            Detail = new NavigationPage(new MainPage());
            ListMenu.ItemsSource = new List<MainMenuItem>
            {
                new MainMenuItem{ Page= new HomePage(), MenuTitle="Home", Icon="ic_home.png"},
                new MainMenuItem{ Page= new LoginPage(), MenuTitle="Logout", Icon="ic_world.png"}
            };
        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is MainMenuItem menu)
            {
                IsPresented = false;
                Detail = new NavigationPage(menu.Page);
            }
        }
    }
}