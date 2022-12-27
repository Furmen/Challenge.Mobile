using Challenge.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Challenge.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopFoodiePage : ContentPage
    {
        public TopFoodiePage()
        {
            InitializeComponent();
            BindingContext = new TopFoodiePageViewModel();
        }
    }
}