using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Challenge.Mobile.Models
{
    public class MainMenuItem : INotifyPropertyChanged
    {
        public string MenuTitle { get; set; }
        public ImageSource Icon { get; set; }
        private Page _page;

        public Page Page
        {
            get => _page;
            set => SetProperty(ref _page, value);
        }

        private bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}