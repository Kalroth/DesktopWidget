using DesktopWidget.Extensions;
using DesktopWidget.Helpers;
using DesktopWidget.Interfaces;

namespace DesktopWidget.Widgets
{
    public class MemoryUsedWidget : IWidgetValue
    {
        public string GetName()
        {
            return "MemoryUsed";
        }

        public dynamic GetValue()
        {
            return (MemoryHelper.UsedInKB * 1024).BytesToString(false);
        }
    }
}
