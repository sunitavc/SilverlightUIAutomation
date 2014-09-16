using ArtOfTest.WebAii.Silverlight;
using TestApp.Setup;

namespace TestApp.Components
{
    /// <summary>
    /// The base class for all components
    /// Now you may ask, why do I need Components?
    /// What do components model?
    /// They model those reusable pieces of application that appear on more than one "page"
    /// A good example for this is the drop down menu on the top, it is rendered on most pages
    /// It is common throughout but cannot be a page because it doesn't exist by itself
    /// A page contains many components and components appear in many pages
    /// </summary>
    public abstract class BaseComponent : FrameworkElement
    {
        /// <summary>
        /// Get the Application object that owns this element.
        /// </summary>
        protected new SilverlightApp Application { get { return (SilverlightApp)Host; } }

        /// <summary>
        /// Gets the WebAii driver.
        /// </summary>
        /// <value>
        /// The driver.
        /// </value>
        protected WebAiiDriver Driver { get { return (WebAiiDriver)(Application.Manager); } }

        /// <summary>
        /// Gets or sets the element.
        /// </summary>
        /// <value>
        /// The element.
        /// </value>
        protected FrameworkElement Element { get; set; }

    }
}
