using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KoloryMAUI.ViewModels
{
    internal class ResetColorCommand : ICommand
    {
        private RectColorViewModel _rectColorViewModel;
        private bool? _lastCanExecuteResult = null;

        public ResetColorCommand(RectColorViewModel rectColorViewModel)
        {
            this._rectColorViewModel = rectColorViewModel;

            rectColorViewModel.PropertyChanged += RectColorViewModel_PropertyChanged;
        }

        private void RectColorViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var handler = CanExecuteChanged;

            bool result = CanExecute(null);

            if (result != _lastCanExecuteResult)
            {
                handler?.Invoke(this, EventArgs.Empty);
            }

            _lastCanExecuteResult = result;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => _rectColorViewModel.R > 0 || _rectColorViewModel.G > 0 || _rectColorViewModel.B > 0;

        public void Execute(object parameter)
        {
            _rectColorViewModel.R = 0;
            _rectColorViewModel.G = 0;
            _rectColorViewModel.B = 0;
        }

    }
}
