using System;
using System.Windows;
using System.Windows.Media;

using static KoloryWPF.Properties.Settings;

namespace KoloryWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SolidColorBrush _rectBrush;
        private bool _valueChangedEventDisabled = false;
        
        // Color of rectangle
        public Color RectColor { get => _rectBrush.Color; set => _rectBrush.Color = value; }
        // Color selected by the sliders
        public Color SelectedColor
        {
            get => Color.FromRgb((byte)SliderR.Value, (byte)SliderG.Value, (byte)SliderB.Value);
            set
            {
                _valueChangedEventDisabled = true;
                SliderR.Value = value.R;
                SliderG.Value = value.G;
                SliderB.Value = value.B;
                _valueChangedEventDisabled = false;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            LoadSettings();
            _rectBrush = new SolidColorBrush(SelectedColor);
            FilledRect.Fill = _rectBrush;
        }

        public void LoadSettings()
        {
            SelectedColor = Color.FromRgb(Default.R, Default.G, Default.B);
            MainWin.Left = Default.Left;
            MainWin.Top = Default.Top;
            MainWin.Width = Default.Width;
            MainWin.Height = Default.Height;
        }

        public void SaveSettings()
        {
            Color c = SelectedColor;
            Default.R = c.R;
            Default.G = c.G;
            Default.B = c.B;

            Default.Left = MainWin.Left;
            Default.Top = MainWin.Top;
            Default.Width = MainWin.Width;
            Default.Height = MainWin.Height;

            Default.Save();
        }

        private void ColorSliders_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!_valueChangedEventDisabled)
            {
                RectColor = SelectedColor;
            }
        }

        private void MainWin_Closed(object sender, EventArgs e)
        {
            SaveSettings();
        }
    }
}
