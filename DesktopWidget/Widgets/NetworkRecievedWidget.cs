using DesktopWidget.Extensions;
using DesktopWidget.Helpers;
using DesktopWidget.Interfaces;

namespace DesktopWidget.Widgets
{
    public class NetworkRecievedWidget : IWidgetValue
    {
        public string GetName()
        {
            return "NetworkRecieved";
        }

        public dynamic GetValue()
        {
            return NetworkHelper.BytesRecieved.BytesToString(true);
        }
    }
}
