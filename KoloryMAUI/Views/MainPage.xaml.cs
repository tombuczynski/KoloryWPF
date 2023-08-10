using KoloryMAUI.ViewModels;
using Microsoft.Maui.Controls;
using System.Globalization;
using System.Xml.Linq;

namespace KoloryMAUI.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            App app = (App)Application.Current;
            if (! app.Settings.IsValid)
            {
                Color color = Color.FromArgb("FF9595F1");

                RectColorViewModel vm = (RectColorViewModel)BindingContext;

                vm.R = color.Red;
                vm.G = color.Green;
                vm.B = color.Blue;
            }
        }

    }
}