using System;
using System.ComponentModel;
using System.Management;
using System.Threading;
using DesktopWidget.Helpers;

namespace DesktopWidget.BackgroundUpdaters
{
    public class MemoryBackgroundUpdater
    {
        // Update values once every second
        private const int ThreadSleep = 1000;
        // Lock object used when updating MemoryHelper values
        private static object lockObj = new object();

        public MemoryBackgroundUpdater()
        {
            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += MemoryBackgroundWorker_DoWork;
            worker.RunWorkerAsync();
        }

        private readonly BackgroundWorker worker;

        private void MemoryBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!worker.CancellationPending)
            {
                ObjectQuery winQuery = new ObjectQuery("SELECT * FROM CIM_OperatingSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(winQuery);
                foreach (ManagementObject item in searcher.Get())
                {
                    lock (lockObj)
                    {
                        MemoryHelper.FreeInKB = Convert.ToInt64(item["FreePhysicalMemory"]);
                        MemoryHelper.TotalInKB = Convert.ToInt64(item["TotalVisibleMemorySize"]);
                        MemoryHelper.UsedInKB = MemoryHelper.TotalInKB - MemoryHelper.FreeInKB;
                    }
                }

                Thread.Sleep(ThreadSleep);
            }
        }
    }
}
