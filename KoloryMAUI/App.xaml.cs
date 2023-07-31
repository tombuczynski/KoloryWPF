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
            public double R, G, B;
            public bool IsValid;
        }

        public AppSettings Settings = new AppSettings() { IsValid = false };

        private void SaveSettings()
        {
            IFormatProvider f = CultureInfo.InvariantCulture;

            XDocument document = new XDocument(
                new XComment($"Last saved: {DateTime.Now.ToString(f)}"),
                new XElement("settings",
                    new XElement("r", Settings.R.ToString(f)),
                    new XElement("g", Settings.G.ToString(f)),
                    new XElement("b", Settings.B.ToString(f))
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

                Settings.R = double.Parse(document.Root.Element("r").Value, f);
                Settings.G = double.Parse(document.Root.Element("g").Value, f);
                Settings.B = double.Parse(document.Root.Element("b").Value, f);

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