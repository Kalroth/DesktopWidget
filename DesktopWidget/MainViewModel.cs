using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DesktopWidget
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private const int MainUpdateDelayInMS = 500;
        private BackgroundWorker MainWorker = new BackgroundWorker();

        public MainViewModel()
        {
            MainWorker.DoWork += MainWorker_DoWork;
            MainWorker.WorkerSupportsCancellation = true;
            MainWorker.RunWorkerAsync();
        }

        private void MainWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            if (worker == null)
                return;

            while (!worker.CancellationPending)
            {
                // Trigger an update of all widgets
                OnPropertyChanged("Values");

                // Sleep for n milliseconds
                Thread.Sleep(MainUpdateDelayInMS);
            }
        }

        public WidgetValueList Values { get; set; } = new WidgetValueList();

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
