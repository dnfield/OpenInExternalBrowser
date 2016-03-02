namespace Tvl.VisualStudio.OpenInExternalBrowser
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;

    [DataContract]
    public class Settings
    {
        public const string RegistryPath = @"DialogPage\VsOpenInExternalBrowser";

        [DataMember(Order = 0)]
        public bool UseVsEditor { get; set; }

        [DataMember(Order = 1)]
        public string FileSchemeHandler { get; set; }

        [DataMember(Order = 2)]
        public bool HttpHttpsEnabled { get; set; }

        [DataMember(Order = 3)]
        public bool FtpEnabled { get; set; }

        [DataMember(Order = 4)]
        public bool MailEnabled { get; set; }

        [DataMember(Order = 5)]
        public string TelnetClient { get; set; }

        private static readonly string ProgramDataFolder;
        private static readonly string SettingsFile;

        public static event EventHandler SettingsUpdated;

        private static void OnSettingsUpdated(object sender, EventArgs ea) => SettingsUpdated?.Invoke(sender, ea);

        public Settings()
        {
            MailEnabled = true;
            HttpHttpsEnabled = true;
            TelnetClient = "";
            UseVsEditor = true;
            FileSchemeHandler = "notepad++.exe";
            FtpEnabled = true;
        }

        static Settings()
        {
            ProgramDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "urihandlerextension");
            SettingsFile = Path.Combine(ProgramDataFolder, "urihandler.json");            
        }

        public static Settings Load()
        {
            Directory.CreateDirectory(ProgramDataFolder);
            if (!File.Exists(SettingsFile)) new Settings().Save();
            using (var stream = new FileStream(SettingsFile, FileMode.Open))
            {
                DataContractJsonSerializer deserialize = new DataContractJsonSerializer(typeof(Settings));
                Settings settings = (Settings)deserialize.ReadObject(stream);

                return settings;
            }
        }

        public void Save()
        {
            Directory.CreateDirectory(ProgramDataFolder);
            using (var stream = new FileStream(SettingsFile, FileMode.Create))
            {
                var serializer = new DataContractJsonSerializer(typeof(Settings));
                serializer.WriteObject(stream, this);
            }
            OnSettingsUpdated(this, EventArgs.Empty);
        }
    }
}
