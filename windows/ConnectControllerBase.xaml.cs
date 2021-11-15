using EV3_Control.windows.controlwindows.Subsetupwindows;
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
using WiimoteLib;

namespace EV3_Control.windows
{
    /// <summary>
    /// Interaktionslogik für ConnectControllerBase.xaml
    /// </summary>
    public partial class ConnectControllerBase : Window
    {

        MainWindow window = new MainWindow();
        public ConnectControllerBase()
        {
            InitializeComponent();
        }
        // window controls
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

        private void Helpbutton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/JuniorJacki/EV3-Controller/wiki");
        }


        private void Connectowiimote_Click(object sender, RoutedEventArgs e)
        {
            startwiimoteconnection();
        }

        // window controls end
        // WIIMOTE _-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void startwiimoteconnection() {
       
           
            try
            {
                Wiimote wm = new Wiimote();
                wm.Connect();
                startwindowcontrollers(wm);
            }
            catch (WiimoteNotFoundException ex)
            {
           
                MessageBox.Show(ex.Message + " Errorcode: #06020a", "Kein Gerät dieses Typs gefunden!");
            }
            catch (WiimoteException ex)
            {
            
                MessageBox.Show(ex.Message + " Errorcode: #06010a", "Wiimote error");
            }
            catch (Exception ex)
            {
          
                MessageBox.Show(ex.Message + " Errorcode: #06000a", "Unbekannter error");
            }
            


        }

        private void startwindowcontrollers(Wiimote _wm)
        {
            this.Hide();
            WiimoteSetupControl window = new WiimoteSetupControl();
            window.Show();
            window.startupwiimote(_wm);
        }

        
    }
}
