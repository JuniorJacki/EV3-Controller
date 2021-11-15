using EV3_Control.windows.controlwindows.Controller;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;
using System;
using System.Collections.Generic;
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
using WiimoteLib;

namespace EV3_Control.windows.controlwindows.Subsetupwindows
{
    /// <summary>
    /// Interaktionslogik für WiimoteSetupControl.xaml
    /// </summary>
    public partial class WiimoteSetupControl : Window
    {
        private Brick startbrick;
        Wiimote _WM = new Wiimote();

        MainWindow window = new MainWindow();
        public WiimoteSetupControl()
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

        //wiimote setup
        public void startupwiimote(Wiimote _wm)
        {
            _WM = _wm;
        }


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
           

            try
            {
                await startbrick.ConnectAsync();
                await startbrick.DirectCommand.PlayToneAsync(10, 1000, 400);
                startwindow("USB");



            }
            catch
            {
                error.Items.Add("Bitte schließe einen EV3 über USB an!");
                error.Items.Add("FehlerCode:");
                error.Items.Add("#00100a");
            }



        }
        private void startwindow(string cn)
        {
            try
            {
                _WM.SetLEDs(false, true, true, false);
                startwindowcontrols(cn);
            } catch (Exception ex) {

                MessageBox.Show(ex.Message + " Errorcode: #06020a" , "Gerät Disconnected");

            }

           
           


        }
     
        private void startwindowcontrols(string cn)
        {
            this.Hide();
            WiimoteConnectMain wmwindow = new WiimoteConnectMain();
            wmwindow.getreferences(startbrick, _WM, cn);
            wmwindow.Show();
        }


    }
}
