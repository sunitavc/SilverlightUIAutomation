using System.Drawing;
using ArtOfTest.WebAii.Silverlight;
using TestApp.Setup;

namespace TestApp.Pages
{
    /// <summary>
    /// The class that models the Page Object for silverlight pages
    /// In order for the Bitmap code to work, you have to reference the System.Drawing assembly 
    /// No idea why it wasn't referenced automagically. Duh.
    /// I have a Draw() method that is required to be implemented because I find this to be a better
    /// way to manage pages. Since there is no concept of "Page loading Done" in SPAs such as Silverlight
    /// I find that having a Draw method that "draws" the components of a page, waits for the presence of an
    /// element or text is a way to manage the inherent fragility of this application automation.
    /// </summary>
    public abstract class BasePage : ApplicationBase
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        public FrameworkElement Page { get; protected set; }

        /// <summary>
        /// Draws this page.
        /// </summary>
        protected abstract void Draw();

        /// <summary>
        /// Refreshes this page.
        /// </summary>
        public void Refresh()
        {
            Application.RefreshVisualTrees();
            Draw();
        }

        /// <summary>
        /// Gets the title of this page
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get { return Driver.Browser.PageTitle; }
        }

        /// <summary>
        /// Gets the screenshot of the current page
        /// </summary>
        /// <value>
        /// The screenshot as Bitmap
        /// </value>
        public Bitmap Screenshot
        {
            get { return Driver.Browser.Window.GetBitmap(); }
        }
    }
}
