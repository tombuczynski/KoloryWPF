using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KoloryMAUI.ViewModels
{
    internal class RectColorViewModel : ObservedObject
    {
        private readonly Models.FillColor _model;

        public RectColorViewModel()
        {
            _model = ((App)Application.Current).Settings.RectColor;
            ResetColorCmd = new ResetColorCommand(this);
        }

        #region Properties
        public double R 
        {
            get => _model.R; 
            set
            {
                if (value != _model.R)
                {
                    _model.R = value;
                    OnPropertyChanged(nameof(R));
                }
            }
        }
        public double G
        {
            get => _model.G;
            set
            {
                if (value != _model.G)
                {
                    _model.G = value;
                    OnPropertyChanged(nameof(G));
                }
            }
        }
        public double B
        {
            get => _model.B;
            set
            {
                if (value != _model.B)
                {
                    _model.B = value;
                    OnPropertyChanged(nameof(B));
                }
            }
        }

        public ICommand ResetColorCmd { get; }

        #endregion
    }
}
