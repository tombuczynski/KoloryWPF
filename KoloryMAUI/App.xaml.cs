using System.Globalization;
using System.Xml.Linq;

namespace KoloryMAUI
{
    public partial class App : Application
    {
        private static readonly string SettingsFilePath = Path.Combine(FileSystem.AppDataDirectory, "settings.xml");

        public App()
        {
            InitializeComponent();

            LoadSettings();

            MainPage = new AppShell();
        }

        public struct AppSettings
        {
            public Models.FillColor RectColor;
            public bool IsValid;
        }

        public AppSettings Settings = new AppSettings() { IsValid = false, RectColor = new Models.FillColor() };

        private void SaveSettings()
        {
            IFormatProvider f = CultureInfo.InvariantCulture;

            XDocument document = new XDocument(
                new XComment($"Last saved: {DateTime.Now.ToString(f)}"),
                new XElement("settings",
                    new XElement("r", Settings.RectColor.R.ToString(f)),
                    new XElement("g", Settings.RectColor.G.ToString(f)),
                    new XElement("b", Settings.RectColor.B.ToString(f))
                    )
                );

            document.Save(SettingsFilePath);
        }

        private void LoadSettings()
        {
            IFormatProvider f = CultureInfo.InvariantCulture;

            if (!File.Exists(SettingsFilePath))
                return;

            try
            {
                XDocument document = XDocument.Load(SettingsFilePath);

                Settings.RectColor = new Models.FillColor(
                    double.Parse(document.Root.Element("r").Value, f),
                    double.Parse(document.Root.Element("g").Value, f),
                    double.Parse(document.Root.Element("b").Value, f));

            }
            catch
            {
                return;
            }

            Settings.IsValid = true;
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            Window w = base.CreateWindow(activationState);

            w.Deactivated += Window_Deactivated;
            w.Destroying += Window_Deactivated;

            return w;
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            SaveSettings();
        }

    }
}