using System;
using DesktopWidget.Interfaces;

namespace DesktopWidget.Widgets
{
    public class DateTimeWidget : IWidgetValue
    {
        public string GetName()
        {
            return "DateTime";
        }

        public dynamic GetValue()
        {
            return DateTime.Now;
        }
    }
}
