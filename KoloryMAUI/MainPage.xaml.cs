using Microsoft.Maui.Controls;
using System.Globalization;
using System.Xml.Linq;

namespace KoloryMAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            double r = 0, g = 0, b = 0;

            if (FilledRectangle.Fill is SolidColorBrush brush)
            {
                Color color = brush.Color;

                r = color.Red;
                g = color.Green;
                b = color.Blue;
            }

            App app = (App)Application.Current;
            if (app.Settings.IsValid)
            {
                r = app.Settings.R;
                g = app.Settings.G;
                b = app.Settings.B;
            }

            SliderR.Value = r;
            SliderG.Value = g;
            SliderB.Value = b;
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Color color = Color.FromRgb(SliderR.Value, SliderG.Value, SliderB.Value);

            FilledRectangle.Fill = new SolidColorBrush(color);

            LabelValR.Text = Math.Round(SliderR.Value * 255.0).ToString();
            LabelValG.Text = Math.Round(SliderG.Value * 255.0).ToString();
            LabelValB.Text = Math.Round(SliderB.Value * 255.0).ToString();

            App app = (App)Application.Current;
            app.Settings.R = SliderR.Value;
            app.Settings.G = SliderG.Value;
            app.Settings.B = SliderB.Value;


        }
    }
}