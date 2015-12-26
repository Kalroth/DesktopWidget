using DesktopWidget.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopWidget.Widgets
{
    public class DayWidget : IWidgetValue
    {
        public string GetName()
        {
            return "Day";
        }

        public dynamic GetValue()
        {
            return DateTime.Now.DayOfWeek.ToString();
        }
    }
}
