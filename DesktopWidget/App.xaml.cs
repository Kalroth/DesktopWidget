using System.Globalization;
using System.Windows;
using System.Windows.Markup;

namespace DesktopWidget
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Stupid WPF defaults to en-US culture ..
            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(
                    CultureInfo.CurrentCulture.IetfLanguageTag)));
            base.OnStartup(e);
        }
    }
}
