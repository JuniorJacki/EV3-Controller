using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EV3_Control.windows.controlwindows.Normal;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;
using System.IO.Ports;

namespace EV3_Control.windows
{
    /// <summary>
    /// Interaktionslogik für connectbase.xaml
    /// </summary>
    public partial class connectbase : Window
    {
        private Brick startbrick;
        
        MainWindow window = new MainWindow();
        public connectbase()
        {
            InitializeComponent();
            Bluethoot.Visibility = Visibility.Visible;
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {


            window.WindowState = WindowState.Normal;
            window.Show();
            window.Top = this.Top;
            window.Left = this.Left;


            this.Close();

        }
        // Tab Controls
        private void tab_usb_click(object sender, RoutedEventArgs e)
        {
            error.Items.Clear();
            Bluethoot.Visibility = Visibility.Hidden;
            USB.Visibility = Visibility.Visible;
        }

        private void tab_bluethoot_click(object sender, RoutedEventArgs e)
        {
            error.Items.Clear();
            Comtextbox.Text = "COM";
            USB.Visibility = Visibility.Hidden;
            Bluethoot.Visibility = Visibility.Visible;
        }


        // Panel Controls

        private void helpbutton(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/JuniorJacki/EV3-Controller/wiki");
        }


        private async void start_bluethoot_connection(object sender, RoutedEventArgs e)
        {

            // Trace.WriteLine("start Bluethoot connection with: " + Comtextbox.Text);
            startbrick = new Brick(new BluetoothCommunication(Comtextbox.Text));
            try
            {

                await startbrick.ConnectAsync();
                await startbrick.DirectCommand.PlayToneAsync(10, 1000, 400);
                startwindow("Bluetooth");


            }
            catch 
            {
               
                error.Items.Add("Es kann keine Verbindung zu ! " + Comtextbox.Text + " ! hergestellt werden!");
                error.Items.Add("FehlerCode:");
                error.Items.Add("#00600d");
            }
          

        }

        private async void start_usb_connection(object sender, RoutedEventArgs e)
        {
            startbrick = new Brick(new UsbCommunication());
            Trace.WriteLine("start usb connection");

            try {
                await startbrick.ConnectAsync();
                await startbrick.DirectCommand.PlayToneAsync(10, 1000, 400);
                startwindow("USB");
                
                
               
            } catch {
                error.Items.Add("Bitte schließe einen EV3 über USB an!");
                error.Items.Add("FehlerCode:");
                error.Items.Add("#00100a");
            }
            


        }
        private void startwindow(string cn)
        {
            this.Hide();
            UsbConnectMain usbcontroller = new UsbConnectMain();
            usbcontroller.Show();
            usbcontroller.startcontroller(startbrick ,cn);
        }
           
           

    }
}
