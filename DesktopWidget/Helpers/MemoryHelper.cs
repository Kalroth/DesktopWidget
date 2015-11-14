using System;
using System.Management;
using DesktopWidget.BackgroundUpdaters;

namespace DesktopWidget.Helpers
{
    public static class MemoryHelper
    {
        public static long FreeInKB { get; set; }
        public static long TotalInKB { get; set; }
        public static long UsedInKB { get; set; }

        private static MemoryBackgroundUpdater updater = new MemoryBackgroundUpdater();
    }
}
