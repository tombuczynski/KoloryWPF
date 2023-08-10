using System.ComponentModel;

namespace KoloryMAUI.ViewModels
{
    internal class ObservedObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(params string[] props)
        {
            var handler = PropertyChanged;

            foreach (string prop in props)
            {
                handler?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}