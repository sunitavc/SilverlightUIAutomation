using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ArtOfTest.Common.Exceptions;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;
using TestApp.Pages;

namespace TestApp.Components
{
    /// <summary>
    /// Models the menu item of the base menu
    /// </summary>
    public class TopMenu : BaseComponent
    {
        public FrameworkElement Welcome
        {
            get{ return FindMenuItem("WELCOME");}
        }

        public FrameworkElement VisualsSample
        {
            get {return FindMenuItem("VISUALS SAMPLE");} 
        }
        public FrameworkElement BindingSample
        {
            get {return FindMenuItem("BINDING SAMPLE");}
        }
        
        private FrameworkElement FindMenuItem(string name)
        {
            //I don't have to do it this way, I can just find by TextContent but I
            //do it this way because text search may match some other user content
            var menuItems = Find.ByType("StackPanel").Children;
            foreach (var menu in menuItems)
            {
                var textBlocks = menu.Find.AllByType<TextBlock>();
                if (textBlocks[0].TextLiteralContent.Equals(name))
                    return menu;
            }
            throw new FindElementException(string.Format("The menu item named {0} was not found", name));
        }

        #region Public APIs

        /// <summary>
        /// Allows the user to select each menu item by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The cursor at the clicked Menu Item</returns>
        public void Select(string name)
        {
           FindMenuItem(name).User.Click();
        }

        /// <summary>
        /// Opens the home page.
        /// </summary>
        /// <returns></returns>
        public HomePage OpenWelcomePage()
        {
            Welcome.User.Click();
            var page = new HomePage();
            page.Refresh();
            return page;
        }
        
        /// <summary>
        /// Opens the Visuals Sample page.
        /// </summary>
        /// <returns></returns>
        public VisualSamplePage OpenVisualSamplesPage()
        {
            VisualsSample.User.Click();
            var page = new VisualSamplePage();
            page.Refresh();
            return page;
        }

        /// <summary>
        /// Opens the Binding Samples Page
        /// </summary>
        /// <returns></returns>
        public BindingSamplePage OpenBindinfSamplesPage()
        {
            BindingSample.User.Click();
            var page = new BindingSamplePage();
            page.Refresh();
            return page;
        }

        #endregion
    }

   
}

