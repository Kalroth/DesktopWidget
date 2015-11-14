using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using DesktopWidget.Helpers;

namespace DesktopWidget.BackgroundUpdaters
{
    public class NetworkBackgroundUpdater
    {
        // Update values once every second
        private const int ThreadSleep = 1000;
        // Lock object used when updating NetworkHelper values
        private static object lockObj = new object();

        public NetworkBackgroundUpdater()
        {
            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += NetworkBackgroundWorker_DoWork;
            worker.RunWorkerAsync();
        }

        private readonly BackgroundWorker worker;
        private long LastBytesRecieved { get; set; }
        private long LastBytesSent { get; set; }

        private void NetworkBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!worker.CancellationPending)
            {
                var mainNic = GetMainNetworkInterface();
                if (mainNic == null)
                    return;

                var mainNicStats = mainNic.GetIPStatistics();
                if (mainNicStats == null)
                    UpdateStatistics(0, 0); // Reset variables since we did not get ip statistics
                else
                    UpdateStatistics(mainNicStats.BytesReceived, mainNicStats.BytesSent);

                Thread.Sleep(ThreadSleep);
            }
        }

        private void UpdateStatistics(long bytesRecieved, long bytesSent)
        {
            lock (lockObj)
            {
                NetworkHelper.BytesRecieved = bytesRecieved - LastBytesRecieved;
                NetworkHelper.BytesSent = bytesSent - LastBytesSent;
            }
            LastBytesRecieved = bytesRecieved;
            LastBytesSent = bytesSent;
        }

        private static NetworkInterface GetMainNetworkInterface()
        {
            // Create a list of enabled network interfaces
            var networkInterfaces = new List<NetworkInterface>();
            networkInterfaces.AddRange(NetworkInterface.GetAllNetworkInterfaces()
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback));

            if (!networkInterfaces.Any())
                return null;

            // Get the network interface with the lowest index
            // Attempt to locate a IPv4 interface first and use IPv6 as fallback
            var networkInterface = networkInterfaces
                .Where(nic => nic.GetIPProperties() != null)
                .OrderBy(nic => nic.GetIPProperties().GetIPv4Properties().Index)
                .FirstOrDefault() ?? networkInterfaces
                .Where(nic => nic.GetIPProperties() != null)
                .OrderBy(nic => nic.GetIPProperties().GetIPv6Properties().Index)
                .FirstOrDefault();

            return networkInterface;
        }
    }
}
