using EV3_Control.windows.subwindows.UsbConnect;
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
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;
using System.Diagnostics;
using System.Threading;
using System.Timers;

namespace EV3_Control.windows.controlwindows.Normal
{
    /// <summary>
    /// Interaktionslogik für UsbConnectMain.xaml
    /// </summary>
    public partial class UsbConnectMain : Window
    {

       private Brick _bk;
     

        public UsbConnectMain()
        {
            InitializeComponent();
            //temp
            


       
          


        }
        
        // BRICK GETTER / MAIN CONTROLLER
        public void startcontroller(Brick brick , string connectiontype)
        {
            _bk = brick;
            try
            {
                Connectiontypelabel.Content = connectiontype;
                ControlsGui controls = new ControlsGui();
                controls.Show();
                controls.GUIcontroller(_bk);
                guiupdater();
                _bk.BrickChanged += OnBrickChanged;
             
               
            }
            catch (Exception e) { Trace.WriteLine(e); }
        }
        // BRICK GETTER END

        



         void OnBrickChanged(object sender, BrickChangedEventArgs e)
        {
            guiupdater();

           

        }

    async void guiupdater()
        {
            try
            {
                if (await _bk.DirectCommand.GetFirmwareVersionAsync() != string.Empty) { firmware1.Content = await _bk.DirectCommand.GetFirmwareVersionAsync(); } else { motorportA.Content = "None"; }
                if (await _bk.DirectCommand.GetDeviceNameAsync(InputPort.A) != string.Empty) { motorportA.Content = await _bk.DirectCommand.GetDeviceNameAsync(InputPort.A); } else { motorportA.Content = "None"; }
                if (await _bk.DirectCommand.GetDeviceNameAsync(InputPort.B) != string.Empty) { motorportB.Content = await _bk.DirectCommand.GetDeviceNameAsync(InputPort.B); } else { motorportB.Content = "None"; }
                if (await _bk.DirectCommand.GetDeviceNameAsync(InputPort.C) != string.Empty) { motorportC.Content = await _bk.DirectCommand.GetDeviceNameAsync(InputPort.C); } else { motorportC.Content = "None"; }
                if (await _bk.DirectCommand.GetDeviceNameAsync(InputPort.D) != string.Empty) { motorportD.Content = await _bk.DirectCommand.GetDeviceNameAsync(InputPort.D); } else { motorportD.Content = "None"; }
                if (await _bk.DirectCommand.GetDeviceNameAsync(InputPort.One) != string.Empty) { sensorport1.Content = await _bk.DirectCommand.GetDeviceNameAsync(InputPort.One); } else { sensorport1.Content = "None"; }
                if (await _bk.DirectCommand.GetDeviceNameAsync(InputPort.Two) != string.Empty) { sensorport2.Content = await _bk.DirectCommand.GetDeviceNameAsync(InputPort.Two); } else { sensorport2.Content = "None"; }
                if (await _bk.DirectCommand.GetDeviceNameAsync(InputPort.Three) != string.Empty) { sensorport3.Content = await _bk.DirectCommand.GetDeviceNameAsync(InputPort.Three); } else { sensorport3.Content = "None"; }
                if (await _bk.DirectCommand.GetDeviceNameAsync(InputPort.Four) != string.Empty) { sensorport4.Content = await _bk.DirectCommand.GetDeviceNameAsync(InputPort.Four); } else { sensorport4.Content = "None"; }
            }
            catch (Exception ex) { Trace.WriteLine(ex.GetType()); }
        }

      
        


        // WINDOW CONTROLS
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // WINDOW CONTROLS END

    }
}
