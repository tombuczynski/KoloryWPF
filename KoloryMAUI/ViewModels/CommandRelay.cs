using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KoloryMAUI.ViewModels
{
    internal class CommandRelay : ICommand
    {
        private INotifyPropertyChanged _viewModel;
        private bool? _lastCanExecuteResult = null;

        private Action<object> _execute;
        private Predicate<object> _canExecute;

        public CommandRelay(INotifyPropertyChanged viewModel, Action<object> execute, Predicate<object> canExecute = null)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            _viewModel = viewModel;

            _viewModel.PropertyChanged += PropertyChanged;

            _execute = execute;
            _canExecute = canExecute;
        }

        private void PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
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

        public bool CanExecute(object parameter) => (_canExecute != null) ? _canExecute(parameter) : true;

        public void Execute(object parameter) => _execute(parameter);
    }

}

