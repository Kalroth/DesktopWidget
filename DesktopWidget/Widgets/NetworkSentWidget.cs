using DesktopWidget.Extensions;
using DesktopWidget.Helpers;
using DesktopWidget.Interfaces;

namespace DesktopWidget.Widgets
{
    public class NetworkSentWidget : IWidgetValue
    {
        public string GetName()
        {
            return "NetworkSent";
        }

        public dynamic GetValue()
        {
            return NetworkHelper.BytesSent.BytesToString(true);
        }
    }
}
