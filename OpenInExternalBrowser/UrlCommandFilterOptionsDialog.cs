
namespace Tvl.VisualStudio.OpenInExternalBrowser
{
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;

    [Guid("F986D105-B927-474B-AF7D-34DC4B2D9718")]
    class UrlCommandFilterOptionsDialog : DialogPage
    {

        public const string Category = "Uri Handling Options";
        public const string SubCategory = "General";

        private const string FileSchemeSubCagtegory = "File Scheme Handler";

        [Category(FileSchemeSubCagtegory)]
        [DisplayName("Use VS Editor")]
        [Description("Will open the file in its default VS editor (not browser); will cause custom handler to be ignored.")]
        public bool UseVsEditor { get; set; }



        [Category(FileSchemeSubCagtegory)]
        [DisplayName("File Scheme Program")]
        [Description("Choose a handler for the file:/// scheme")]       
        public string FileSchemeHandler { get; set; }
        
        private const string SchemeHandlerSubCategory = "Other Scheme Handlers";
        [Category(SchemeHandlerSubCategory)]
        [DisplayName("HTTP/HTTPS Enabled")]
        [DefaultValue(true)]
        public bool HttpHttpsEnabled { get; set; }

        [Category(SchemeHandlerSubCategory)]
        [DisplayName("FTP Enabled")]
        [DefaultValue(true)]
        public bool FtpEnabled { get; set; }

        [Category(SchemeHandlerSubCategory)]
        [DisplayName("Mail Enabled")]
        [DefaultValue(true)]
        public bool MailEnabled { get; set; }

        [Category(SchemeHandlerSubCategory)]
        [DisplayName("Telnet Client path")]
        [DefaultValue(true)]
        public string TelnetClient { get; set; }



        public override void LoadSettingsFromStorage()
        {
            var settings = Settings.Load();

            UseVsEditor = settings.UseVsEditor;
            FileSchemeHandler = settings.FileSchemeHandler;
            HttpHttpsEnabled = settings.HttpHttpsEnabled;
            FtpEnabled = settings.FtpEnabled;
            MailEnabled = settings.MailEnabled;
            TelnetClient = settings.TelnetClient;        
        }

        public override void SaveSettingsToStorage()
        {
            var settings = new Settings
            {
                UseVsEditor = this.UseVsEditor,
                FileSchemeHandler = this.FileSchemeHandler,
                HttpHttpsEnabled = this.HttpHttpsEnabled,
                FtpEnabled = this.FtpEnabled,
                MailEnabled = this.MailEnabled,
                TelnetClient = this.TelnetClient
            };
            settings.Save();
        }
    }
}
