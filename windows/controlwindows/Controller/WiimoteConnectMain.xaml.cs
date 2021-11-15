using Lego.Ev3.Core;
using Lego.Ev3.Desktop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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


namespace EV3_Control.windows.controlwindows.Controller
{
    /// <summary>
    /// Interaktionslogik für WiimoteConnectMain.xaml
    /// </summary>
    public partial class WiimoteConnectMain : Window
    {
        private Brick _bk;
        private Wiimote _wm;

        public WiimoteConnectMain()
        {
            InitializeComponent();
            loadpreferencesgui();
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private async void close_Click(object sender, RoutedEventArgs e)
        {
            await _bk.DirectCommand.StopMotorAsync(OutputPort.A, false);
            await _bk.DirectCommand.StopMotorAsync(OutputPort.B, false);
            await _bk.DirectCommand.StopMotorAsync(OutputPort.C, false);
            await _bk.DirectCommand.StopMotorAsync(OutputPort.D, false);
            
            _wm.Disconnect();
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();

        }

        // WINDOW LOADER
        private void loadpreferencesgui()
        {
            UP_Entry.Text = Properties.Settings.Default.W_ControlSpeed_UP.ToString();
            DOWN_Entry.Text = Properties.Settings.Default.W_ControlSpeed_DOWN.ToString();
            if (Properties.Settings.Default.W_Control_UP_A == true)
            {
                UP_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                UP_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.W_Control_UP_B == true)
            {
                UP_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                UP_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.W_Control_UP_C == true)
            {
                UP_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                UP_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.W_Control_UP_D == true)
            {
                UP_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                UP_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            //DOWN

           
            if (Properties.Settings.Default.W_Control_DOWN_A == true)
            {
                DOWN_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                DOWN_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.W_Control_DOWN_B == true)
            {
                DOWN_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                DOWN_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.W_Control_DOWN_C == true)
            {
                DOWN_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                DOWN_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.W_Control_DOWN_D == true)
            {
                DOWN_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                DOWN_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            //LEFT

           
            if (Properties.Settings.Default.W_Control_LEFT_A == true)
            {
                LEFT_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                LEFT_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.W_Control_LEFT_B == true)
            {
                LEFT_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                LEFT_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.W_Control_LEFT_C == true)
            {
                LEFT_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                LEFT_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.W_Control_LEFT_D == true)
            {
                LEFT_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                LEFT_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            //RIGHT

           
            if (Properties.Settings.Default.W_Control_RIGHT_A == true)
            {
                RIGHT_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                RIGHT_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.W_Control_RIGHT_B == true)
            {
                RIGHT_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                RIGHT_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.W_Control_RIGHT_C == true)
            {
                RIGHT_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                RIGHT_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.W_Control_RIGHT_D == true)
            {
                RIGHT_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                RIGHT_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
        }


        // WINDOW CONTROLS END
        // GET WIIMOTE AND EV3
        public async void getreferences(Brick brick, Wiimote wiimote, String Connectiontype)
        {
            _bk = brick;
            _wm = wiimote;
            guiupdater();
           
            
            
            // GUI SELF
            try
            {
                if (await _bk.DirectCommand.GetFirmwareVersionAsync() != string.Empty) { firmware1.Content = await _bk.DirectCommand.GetFirmwareVersionAsync(); } else { motorportA.Content = "None"; }
            }
            catch { }
            // END


            _bk.BrickChanged += OnBrickChanged;
            _wm.SetReportType(InputReport.IRAccel, true);
            _wm.WiimoteChanged += wm_WiimoteChanged;


            Connectiontypelabel.Content = Connectiontype;
        }



        // END

        // KEYs

        private  async void Window_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Space)
            {

                _bk.BatchCommand.StopMotor(OutputPort.A, false);
                _bk.BatchCommand.StopMotor(OutputPort.B, false);
                _bk.BatchCommand.StopMotor(OutputPort.C, false);
                _bk.BatchCommand.StopMotor(OutputPort.D, false);
                await _bk.BatchCommand.SendCommandAsync();
            }
        }



        // EKYS END
        // validate textinput

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {


            e.Handled = !IsValid(((TextBox)sender).Text + e.Text, e.Text);

        }

        public static bool IsValid(string str, string sttr)
        {
            if (sttr == "-") { return true; }
            int i;
            return int.TryParse(str, out i) && i >= -100 && i <= 100;
        }


        // validate end






        //Wiimote
        private delegate void UpdateWiimoteStateDelegate(WiimoteChangedEventArgs args);
        private void wm_WiimoteChanged(object sender, WiimoteChangedEventArgs e)
        {

            try
            {
                Dispatcher.BeginInvoke(new UpdateWiimoteStateDelegate(UpdateWiimoteChanged), e);
            }
            catch (Exception exc) { Trace.WriteLine(exc); }
        }

        private void UpdateWiimoteChanged(WiimoteChangedEventArgs args)
        {
            WiimoteState ws = args.WiimoteState;
            updatemotors( ws.AccelState.Values.Y, ws.ButtonState.One, ws.ButtonState.Two);
            x_wiimote.Content = ws.AccelState.Values.X.ToString();            
           y_wiimote.Content = ws.AccelState.Values.Y.ToString();
            z_wiimote.Content = ws.AccelState.Values.Z.ToString();
        }


        // >_>__>_>__> EV3 CONTROL WITH WIIMOTE ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
        int x = 1;
        int motorvalue;
        private async void updatemotors(float ywii, bool one, bool two)
        {
          
            int y;
              if (ywii.Equals("-")) {
                y = (int)ywii - ((int)ywii * 99); 
              } else { y = (int)ywii * 100; }
            x = x + 1;
            if (x == 20) { x = 1; }
            if (x == 1)
            {
                if (y != motorvalue)
                {            
                        if (y < motorvalue)
                        {
                            if (!(motorvalue - 15 < -106))
                            {
                                motorvalue = motorvalue - 15;
                                setmotor(-15);
                            }
                        }
                        else
                        {
                            if (!(motorvalue + 15 > 106))
                            {

                                motorvalue = motorvalue + 15;
                                setmotor(15);
                            }
                        }        

                }
               
            }

            if (one == true)
            {
                if (Properties.Settings.Default.W_Control_DOWN_A == true)
                {
                    await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.A, Properties.Settings.Default.W_ControlSpeed_DOWN);
                }
                if (Properties.Settings.Default.W_Control_DOWN_B == true)
                {
                    await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.B, Properties.Settings.Default.W_ControlSpeed_DOWN);
                }
                if (Properties.Settings.Default.W_Control_DOWN_C == true)
                {
                    await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.C, Properties.Settings.Default.W_ControlSpeed_DOWN);
                }
                if (Properties.Settings.Default.W_Control_DOWN_D == true)
                {
                    await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.D, Properties.Settings.Default.W_ControlSpeed_DOWN);
                }
            } else if (two == true)
            {
                if (Properties.Settings.Default.W_Control_UP_A == true)
                {
                    await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.A, Properties.Settings.Default.W_ControlSpeed_UP);
                }
                if (Properties.Settings.Default.W_Control_UP_B == true)
                {
                    await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.B, Properties.Settings.Default.W_ControlSpeed_UP);
                }
                if (Properties.Settings.Default.W_Control_UP_C == true)
                {
                    await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.C, Properties.Settings.Default.W_ControlSpeed_UP);
                }
                if (Properties.Settings.Default.W_Control_UP_D == true)
                {
                    await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.D, Properties.Settings.Default.W_ControlSpeed_UP);
                }
            } else
           if (one == false || two == false)
            {
                if (one == false)
                {
                    if (Properties.Settings.Default.W_Control_DOWN_A == true)
                    {
                        await _bk.DirectCommand.StopMotorAsync(OutputPort.A, false);
                    }
                    if (Properties.Settings.Default.W_Control_DOWN_B == true)
                    {
                        await _bk.DirectCommand.StopMotorAsync(OutputPort.B, false);
                    }
                    if (Properties.Settings.Default.W_Control_DOWN_C == true)
                    {
                        await _bk.DirectCommand.StopMotorAsync(OutputPort.C, false);
                    }
                    if (Properties.Settings.Default.W_Control_DOWN_D == true)
                    {
                        await _bk.DirectCommand.StopMotorAsync(OutputPort.D, false);
                    }
                }

                if (two == false)
                {
                    if (Properties.Settings.Default.W_Control_UP_A == true)
                    {
                        await _bk.DirectCommand.StopMotorAsync(OutputPort.A, false);
                    }
                    if (Properties.Settings.Default.W_Control_UP_B == true)
                    {
                        await _bk.DirectCommand.StopMotorAsync(OutputPort.B, false);
                    }
                    if (Properties.Settings.Default.W_Control_UP_C == true)
                    {
                        await _bk.DirectCommand.StopMotorAsync(OutputPort.C, false);
                    }
                    if (Properties.Settings.Default.W_Control_UP_D == true)
                    {
                        await _bk.DirectCommand.StopMotorAsync(OutputPort.D, false);
                    }
                }
            }



           
        }
        private async void setmotor(int value)
        {
            if (Properties.Settings.Default.W_Control_LEFT_A == true || Properties.Settings.Default.W_Control_RIGHT_A == true)
            {
                await _bk.DirectCommand.StepMotorAtSpeedAsync(OutputPort.A, value, 10, true);
            }
            if (Properties.Settings.Default.W_Control_LEFT_B == true || Properties.Settings.Default.W_Control_RIGHT_B == true)
            {
                await _bk.DirectCommand.StepMotorAtSpeedAsync(OutputPort.B, value, 10, true);
            }
            if (Properties.Settings.Default.W_Control_LEFT_C == true || Properties.Settings.Default.W_Control_RIGHT_C == true)
            {
                await _bk.DirectCommand.StepMotorAtSpeedAsync(OutputPort.C, value , 10 , true);
            }
            if (Properties.Settings.Default.W_Control_LEFT_D == true || Properties.Settings.Default.W_Control_RIGHT_D == true)
            {
                await _bk.DirectCommand.StepMotorAtSpeedAsync(OutputPort.D, value , 10 , true);
            }
        }


        // <-<-<-<____<-----<-- END





      
        //Wiimote end
        // EV3
        void OnBrickChanged(object sender, BrickChangedEventArgs e)
        {
          
       
            guiupdater();

          
          
        }
        // EV3 end





        // WINDOW GUI

        async void guiupdater()
        {
            
            try
            {
              
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



        //GUI INTERACTS
        // UP
        private void UP_Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            int.TryParse(UP_Entry.Text, out i);
            Properties.Settings.Default.W_ControlSpeed_UP = i;

            Properties.Settings.Default.Save();
        }


        private void UP_A_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.W_Control_UP_A == false)
            {
                Properties.Settings.Default.W_Control_UP_A = true;
                UP_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.W_Control_UP_A = false;
                UP_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }

        }

        private void UP_B_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.W_Control_UP_B == false)
            {
                Properties.Settings.Default.W_Control_UP_B = true;
                UP_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.W_Control_UP_B = false;
                UP_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void UP_C_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.W_Control_UP_C == false)
            {
                Properties.Settings.Default.W_Control_UP_C = true;
                UP_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.W_Control_UP_C = false;
                UP_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void UP_D_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.W_Control_UP_D == false)
            {
                Properties.Settings.Default.W_Control_UP_D = true;
                UP_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.W_Control_UP_D = false;
                UP_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }
        //DOWN

        private void DOWN_Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            int.TryParse(DOWN_Entry.Text, out i);
            Properties.Settings.Default.W_ControlSpeed_DOWN = i;

            Properties.Settings.Default.Save();
        }

        private void DOWN_A_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.W_Control_DOWN_A == false)
            {
                Properties.Settings.Default.W_Control_DOWN_A = true;
                DOWN_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.W_Control_DOWN_A = false;
                DOWN_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void DOWN_B_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.W_Control_DOWN_B == false)
            {
                Properties.Settings.Default.W_Control_DOWN_B = true;
                DOWN_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.W_Control_DOWN_B = false;
                DOWN_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void DOWN_C_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.W_Control_DOWN_C == false)
            {
                Properties.Settings.Default.W_Control_DOWN_C = true;
                DOWN_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.W_Control_DOWN_C = false;
                DOWN_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void DOWN_D_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.W_Control_DOWN_D == false)
            {
                Properties.Settings.Default.W_Control_DOWN_D = true;
                DOWN_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.W_Control_DOWN_D = false;
                DOWN_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        //LEft

        private void LEFT_A_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.W_Control_LEFT_A == false)
            {
                Properties.Settings.Default.W_Control_LEFT_A = true;
                LEFT_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.W_Control_LEFT_A = false;
                LEFT_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void LEFT_B_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.W_Control_LEFT_B == false)
            {
                Properties.Settings.Default.W_Control_LEFT_B = true;
                LEFT_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.W_Control_LEFT_B = false;
                LEFT_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void LEFT_C_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.W_Control_LEFT_C == false)
            {
                Properties.Settings.Default.W_Control_LEFT_C = true;
                LEFT_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.W_Control_LEFT_C = false;
                LEFT_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void LEFT_D_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.W_Control_LEFT_D == false)
            {
                Properties.Settings.Default.W_Control_LEFT_D = true;
                LEFT_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.W_Control_LEFT_D = false;
                LEFT_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        // RIght

        private void RIGHT_A_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.W_Control_RIGHT_A == false)
            {
                Properties.Settings.Default.W_Control_RIGHT_A = true;
                RIGHT_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.W_Control_RIGHT_A = false;
                RIGHT_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void RIGHT_B_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.W_Control_RIGHT_B == false)
            {
                Properties.Settings.Default.W_Control_RIGHT_B = true;
                RIGHT_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.W_Control_RIGHT_B = false;
                RIGHT_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void RIGHT_C_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.W_Control_RIGHT_C == false)
            {
                Properties.Settings.Default.W_Control_RIGHT_C = true;
                RIGHT_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.W_Control_RIGHT_C = false;
                RIGHT_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void RIGHT_D_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.W_Control_RIGHT_D == false)
            {
                Properties.Settings.Default.W_Control_RIGHT_D = true;
                RIGHT_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.W_Control_RIGHT_D = false;
                RIGHT_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }
    }
}
