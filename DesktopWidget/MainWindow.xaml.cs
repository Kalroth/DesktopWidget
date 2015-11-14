using System.Windows;
using System.Windows.Input;

namespace DesktopWidget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (Properties.Settings.Default.WindowX != 0)
                Top = Properties.Settings.Default.WindowX;
            if (Properties.Settings.Default.WindowY != 0)
                Left = Properties.Settings.Default.WindowY;
            if (Properties.Settings.Default.WindowWidth != 0)
                Width = Properties.Settings.Default.WindowWidth;
        }

        private void DesktopWidget_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void DesktopWidget_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Properties.Settings.Default.WindowWidth = Width;
            Properties.Settings.Default.Save();
        }

        private void DesktopWidget_LocationChanged(object sender, System.EventArgs e)
        {
            Properties.Settings.Default.WindowX = Top;
            Properties.Settings.Default.WindowY = Left;
            Properties.Settings.Default.Save();
        }
    }
}
