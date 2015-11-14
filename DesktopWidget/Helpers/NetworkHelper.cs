using DesktopWidget.BackgroundUpdaters;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace DesktopWidget.Helpers
{
    public static class NetworkHelper
    {
        public static long BytesRecieved { get; set; }
        public static long BytesSent { get; set; }

        private static NetworkBackgroundUpdater updater = new NetworkBackgroundUpdater();
    }
}
