using DesktopWidget.Extensions;
using DesktopWidget.Helpers;
using DesktopWidget.Interfaces;

namespace DesktopWidget.Widgets
{
    public class MemoryTotalWidget : IWidgetValue
    {
        public string GetName()
        {
            return "MemoryTotal";
        }

        public dynamic GetValue()
        {
            return (MemoryHelper.TotalInKB * 1024).BytesToString(false);
        }
    }
}
