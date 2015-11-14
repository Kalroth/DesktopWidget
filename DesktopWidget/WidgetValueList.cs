using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DesktopWidget.Interfaces;

namespace DesktopWidget
{
    public class WidgetValueList : List<IWidgetValue>
    {
        public WidgetValueList()
        {
            // Construct and store the types that implements IWidgetValue without any create parameters
            foreach (var widgetType in Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IWidgetValue)) && t.GetConstructor(Type.EmptyTypes) != null))
                Add(Activator.CreateInstance(widgetType) as IWidgetValue);
        }

        public dynamic this[string name]
        {
            get
            {
                var widget = this.FirstOrDefault(x => x.GetName().Equals(name, StringComparison.CurrentCultureIgnoreCase));
                if (widget != null)
                    return widget.GetValue();

                return null;
            }
        }
    }
}
