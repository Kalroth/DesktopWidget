using DesktopWidget.Extensions;
using DesktopWidget.Helpers;
using DesktopWidget.Interfaces;

namespace DesktopWidget.Widgets
{
    public class MemoryFreeWidget : IWidgetValue
    {
        public string GetName()
        {
            return "MemoryFree";
        }

        public dynamic GetValue()
        {
            return (MemoryHelper.FreeInKB * 1024).BytesToString(false);
        }
    }
}
