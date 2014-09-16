using ArtOfTest.WebAii.Core;

namespace TestApp.Setup
{
    /// <summary>
    /// A wrapper over the WebAii Manager class
    /// </summary>
    public class WebAiiDriver : Manager
    {
        /// <summary>
        /// Gets the base URL.
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>
        public string BaseUrl
        {
            get { return Settings.Web.BaseUrl; }
        }

        /// <summary>
        /// Gets the current active browser.
        /// </summary>
        /// <value>
        /// The browser.
        /// </value>
        public Browser Browser
        {
            get { return ActiveBrowser; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebAiiDriver" /> class.
        /// </summary>
        /// <param name="setting">The setting.</param>
        public WebAiiDriver(Settings setting)
            : base(setting)
        {
            Start();
        }

        /// <summary>
        /// Writes to log.
        /// </summary>
        /// <param name="text">The text.</param>
        public void WriteToLog(string text)
        {
            Log.WriteLine(text);
        }

        /// <summary>
        /// Writes to log.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="path">The path.</param>
        public void WriteToLog(string text, string path)
        {
            Settings.LogLocation = path;
            Log.WriteLine(text);
        }

        /// <summary>
        /// Cleans up.
        /// </summary>
        public void CleanUp()
        {
            if (Settings.Web.RecycleBrowser)
                return;
            Dispose();
        }

    }
}
