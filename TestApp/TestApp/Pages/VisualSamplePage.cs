using System;
using ArtOfTest.WebAii.Silverlight;
using TestApp.Extensions;

namespace TestApp.Pages
{
    /// <summary>
    /// Te page object that models the page that is rendered when Visual Sample menu item is clicked
    /// This is a partial implemenation of that class. The full implementation is left to you, 
    /// the dear Reader as an exercise. Oh, how I love saying that - have always wanted to say it.
    /// </summary>
    public class VisualSamplePage : BasePage
    {
        public FrameworkElement Root { get; private set; }
        public FrameworkElement Checkbox { get; private set; }

        protected override void Draw()
        {
            //Finding by Name is the same as Finding by Automation Id
            //Here I am finding the root of this page, the element that holds
            //all other elements on this page
            Root = Application.Find.ByName("ContentFrame");
            //Find By expression allows user to Find by xamltag, which the Find.ByType operation
            //also allows. Find.ByExpression allows more than one match, so I can say
            //xamltag=Checkbox, name=".." etc to do a more close match
            Checkbox = Root.Find.ByExpression(new XamlFindExpression("xamltag=CheckBox"));
            //..Find the other elements on this page
        }

        #region Public API

        /// <summary>
        /// Checks the checkbox on this page
        /// Now I should return void here. I am returning the instance of this class
        /// just to demonstrate method chaining
        /// If there were operations that I did in a sequence on this page
        /// then method chaining would help me build expressions that make business sense
        /// It's a technique used in building DSLs
        /// </summary>
        public VisualSamplePage Uncheck()
        {
            //Ideally I should have wrapper methods for Check and Uncheck.
            //Pity webaii's API is not so advanced
            //It makes sense to have a FrameworkElementExtension method like the one I've written here
            //for Click() that I would call Check() and Uncheck()
            Checkbox.Click();
            return this;
        }

        /// <summary>
        /// Determines whether this checkbox is checked.
        /// This demonstrates how to fetch XAML properties that indicate the 
        /// state of the control
        /// The way this is done is by creating a ne Automation Property on the fly
        /// using extension methods. See the FrameworkElementExtensions class
        /// </summary>
        /// <returns></returns>
        public bool IsChecked()
        {
            return Checkbox.Get<string>("IsChecked").Equals("False");
        }

        #endregion
    }
}
