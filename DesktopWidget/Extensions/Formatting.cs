using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopWidget.Extensions
{
    public static class Formatting
    {
        private static readonly string[] suffixBase10 = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
        private static readonly string[] suffixPowerOfTwo = { "B", "KiB", "MiB", "GiB", "TiB", "PiB", "EiB" };

        public static string BytesToString(this long byteCount, bool base10)
        {
            var suffix = base10 ? suffixBase10 : suffixPowerOfTwo;
            int BytesPerK = base10 ? 1000 : 1024;

            if (byteCount < BytesPerK + 1)
                return string.Format("{0} {1}", byteCount, suffix[0]);

            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, BytesPerK)));
            double num = Math.Round(bytes / Math.Pow(BytesPerK, place), 1);
            return string.Format("{0:0.0} {1}", (Math.Sign(byteCount) * num), suffix[place]);
        }
    }
}
