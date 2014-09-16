using System;
using System.Threading;
using ArtOfTest.Common.Exceptions;
using ArtOfTest.WebAii.Controls.Xaml.Wpf;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;
using TestApp.Components;
using TestApp.Extensions;

namespace TestApp.Pages
{
    /// <summary>
    /// Models the Home Page
    /// </summary>
    public class HomePage : BasePage
    {
        private TopMenu _topMenu;
        private FrameworkElement _root;

        /// <summary>
        /// Waits for home page to appear
        /// </summary>
        protected void WaitForHome()
        {
            Application.WaitForMessageToAppear(
                "The visual runtime inspector for Silverlight, Windows Phone and WinRT XAML applications.");
        }

      
        #region Public APIs
        /// <summary>
        /// Draw the Home Page
        /// </summary>
        protected override void Draw()
        {
            //Initialize all private elements of the page here
            Application.Find.Strategy = FindStrategy.WhenNotVisibleThrowException;
            _root = Application.GetRootElement();
            try
            {
                _topMenu = _root.Find.ByName("LayoutRoot").CastAs<TopMenu>();
            }
            catch (FindElementException)
            {
                const string exception = "The main menu is not visible, or the application is not on the home page";
                Driver.Log.WriteLine(LogType.Error, exception);
                throw new FindElementException(exception);
            }
        }

        /// <summary>
        /// Get the Main Menu of the Home Page
        /// </summary>
        /// <returns>Cursor/Element at the main menu</returns>
        public TopMenu MainMenu()
        {
            return _topMenu;
        }

        public String PageContent()
        {
            return _root.Find.ByName("ContentFrame").Text;
        }

        #endregion


    }
}
