using Nancy.TinyIoc;
using System.ComponentModel;

namespace Challenge.Mobile.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public readonly TinyIoCContainer container = TinyIoCContainer.Current;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}