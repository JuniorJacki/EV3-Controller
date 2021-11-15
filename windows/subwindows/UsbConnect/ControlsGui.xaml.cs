using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Color = System.Windows.Media.Color;

namespace EV3_Control.windows.subwindows.UsbConnect
{
    /// <summary>
    /// Interaktionslogik für ControlsGui.xaml
    /// </summary>
    public partial class ControlsGui : Window
    {
        bool anykeypressed;
        private Brick _bk;
        public ControlsGui()
        {
            InitializeComponent();
           
        }
        // START WINDOW CONTROLS 
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        // END WINDOW CONTROLS 
        // ----------------------------------------------------------------------------------------------

        //Normal control window

        // window COntrols
        private void Open_subwindow_button_Click(object sender, RoutedEventArgs e)
        {
            controlsgrid.Visibility = Visibility.Hidden;
            shortcutgrid.Visibility = Visibility.Visible;

            // UPDATE WINDOW
            //UP

             UP_Entry.Text = Properties.Settings.Default.U_B_ControlSpeed_UP.ToString();
            if (Properties.Settings.Default.U_B_Control_UP_A == true)
            {
                UP_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                UP_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.U_B_Control_UP_B == true)
            {
                UP_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                UP_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.U_B_Control_UP_C == true)
            {
                UP_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                UP_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.U_B_Control_UP_D == true)
            {
                UP_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                UP_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            //DOWN

            DOWN_Entry.Text = Properties.Settings.Default.U_B_ControlSpeed_DOWN.ToString();
            if (Properties.Settings.Default.U_B_Control_DOWN_A == true)
            {
                DOWN_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                DOWN_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.U_B_Control_DOWN_B == true)
            {
                DOWN_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                DOWN_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.U_B_Control_DOWN_C == true)
            {
                DOWN_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                DOWN_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.U_B_Control_DOWN_D == true)
            {
                DOWN_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                DOWN_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            //LEFT

            LEFT_Entry.Text = Properties.Settings.Default.U_B_ControlSpeed_LEFT.ToString();
            if (Properties.Settings.Default.U_B_Control_LEFT_A == true)
            {
                LEFT_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                LEFT_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.U_B_Control_LEFT_B == true)
            {
                LEFT_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                LEFT_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.U_B_Control_LEFT_C == true)
            {
                LEFT_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                LEFT_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.U_B_Control_LEFT_D == true)
            {
                LEFT_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                LEFT_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            //RIGHT

            RIGHT_Entry.Text = Properties.Settings.Default.U_B_ControlSpeed_RIGHT.ToString();
            if (Properties.Settings.Default.U_B_Control_RIGHT_A == true)
            {
                RIGHT_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                RIGHT_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.U_B_Control_RIGHT_B == true)
            {
                RIGHT_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                RIGHT_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.U_B_Control_RIGHT_C == true)
            {
                RIGHT_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                RIGHT_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
            if (Properties.Settings.Default.U_B_Control_RIGHT_D == true)
            {
                RIGHT_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
            }
            else
            {
                RIGHT_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
            }
        }

        //window control end

        // BRICK GETTER / MAIN CONTROL
        public void GUIcontroller(Brick brick)
        {
            _bk = brick;

        }
        // BRICK GETTER


        // UI
        private void UI_UP_Pressed(object sender, RoutedEventArgs e)
        {
            if (anykeypressed == false)
            {
                UP_Command();
            }
        }

        private void UI_DOWN_Pressed(object sender, RoutedEventArgs e)
        {
            if (anykeypressed == false)
            {
                DOWN_Command();
            }
        }

        private void UI_LEFT_Pressed(object sender, RoutedEventArgs e)
        {
            if (anykeypressed == false)
            {
                LEFT_Command();
            }
        }
        private void UI_RIGHT_Pressed(object sender, RoutedEventArgs e)
        {
            if (anykeypressed == false)
            {
                RIGHT_Command();
            }
        }

        //UI END

        // COMANDS
        private async void UP_Command() 
        {
            if (Properties.Settings.Default.U_B_Control_UP_A == true) {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.A, Properties.Settings.Default.U_B_ControlSpeed_UP);
            }
            if (Properties.Settings.Default.U_B_Control_UP_B == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.B, Properties.Settings.Default.U_B_ControlSpeed_UP);
            }
            if (Properties.Settings.Default.U_B_Control_UP_C == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.C, Properties.Settings.Default.U_B_ControlSpeed_UP);
            }
            if (Properties.Settings.Default.U_B_Control_UP_D == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.D, Properties.Settings.Default.U_B_ControlSpeed_UP);
            }
        }

        private async void DOWN_Command()
        {
            if (Properties.Settings.Default.U_B_Control_DOWN_A == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.A, Properties.Settings.Default.U_B_ControlSpeed_DOWN);
            }
            if (Properties.Settings.Default.U_B_Control_DOWN_B == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.B, Properties.Settings.Default.U_B_ControlSpeed_DOWN);
            }
            if (Properties.Settings.Default.U_B_Control_DOWN_C == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.C, Properties.Settings.Default.U_B_ControlSpeed_DOWN);
            }
            if (Properties.Settings.Default.U_B_Control_DOWN_D == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.D, Properties.Settings.Default.U_B_ControlSpeed_DOWN);
            }

        }

        private async void LEFT_Command()
        {
            if (Properties.Settings.Default.U_B_Control_LEFT_A == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.A, Properties.Settings.Default.U_B_ControlSpeed_LEFT);
            }
            if (Properties.Settings.Default.U_B_Control_LEFT_B == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.B, Properties.Settings.Default.U_B_ControlSpeed_LEFT);
            }
            if (Properties.Settings.Default.U_B_Control_LEFT_C == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.C, Properties.Settings.Default.U_B_ControlSpeed_LEFT);
            }
            if (Properties.Settings.Default.U_B_Control_LEFT_D == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.D, Properties.Settings.Default.U_B_ControlSpeed_LEFT);
            }
        }

        private async void RIGHT_Command()
        {

            if (Properties.Settings.Default.U_B_Control_RIGHT_A == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.A, Properties.Settings.Default.U_B_ControlSpeed_RIGHT);
            }
            if (Properties.Settings.Default.U_B_Control_RIGHT_B == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.B, Properties.Settings.Default.U_B_ControlSpeed_RIGHT);
            }
            if (Properties.Settings.Default.U_B_Control_RIGHT_C == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.C, Properties.Settings.Default.U_B_ControlSpeed_RIGHT);
            }
            if (Properties.Settings.Default.U_B_Control_RIGHT_D == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.D, Properties.Settings.Default.U_B_ControlSpeed_RIGHT);
            }
        }

        // UNNCOMANDS

        private async void UI_ALL_UNCOMMAND() 
        {
            _bk.BatchCommand.StopMotor(OutputPort.A, false);
            _bk.BatchCommand.StopMotor(OutputPort.B, false);
            _bk.BatchCommand.StopMotor(OutputPort.C, false);
            _bk.BatchCommand.StopMotor(OutputPort.D, false);
            await _bk.BatchCommand.SendCommandAsync();
        }

        //KEYCODES
 

        private async void KEY_UP_Command()
        {
            UP_BUTTON.SetResourceReference(StyleProperty, "subwindowControlsGui2");
            if (Properties.Settings.Default.U_B_Control_UP_A == true)
            {

                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.A, Properties.Settings.Default.U_B_ControlSpeed_UP);
            }
            if (Properties.Settings.Default.U_B_Control_UP_B == true)
            {
        
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.B, Properties.Settings.Default.U_B_ControlSpeed_UP);
            }
            if (Properties.Settings.Default.U_B_Control_UP_C == true)
            {

                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.C, Properties.Settings.Default.U_B_ControlSpeed_UP);
            }
            if (Properties.Settings.Default.U_B_Control_UP_D == true)
            { 
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.D, Properties.Settings.Default.U_B_ControlSpeed_UP);
            }
        }

        private async void KEY_DOWN_Command()
        {
            DOWN_BUTTON.SetResourceReference(StyleProperty, "subwindowControlsGui2");
            if (Properties.Settings.Default.U_B_Control_DOWN_A == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.A, Properties.Settings.Default.U_B_ControlSpeed_DOWN);
            }
            if (Properties.Settings.Default.U_B_Control_DOWN_B == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.B, Properties.Settings.Default.U_B_ControlSpeed_DOWN);
            }
            if (Properties.Settings.Default.U_B_Control_DOWN_C == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.C, Properties.Settings.Default.U_B_ControlSpeed_DOWN);
            }
            if (Properties.Settings.Default.U_B_Control_DOWN_D == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.D, Properties.Settings.Default.U_B_ControlSpeed_DOWN);
            }
        }

        private async void KEY_LEFT_Command()
        {
            LEFT_BUTTON.SetResourceReference(StyleProperty, "subwindowControlsGui2");
            if (Properties.Settings.Default.U_B_Control_LEFT_A == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.A, Properties.Settings.Default.U_B_ControlSpeed_LEFT);
            }
            if (Properties.Settings.Default.U_B_Control_LEFT_B == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.B, Properties.Settings.Default.U_B_ControlSpeed_LEFT);
            }
            if (Properties.Settings.Default.U_B_Control_LEFT_C == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.C, Properties.Settings.Default.U_B_ControlSpeed_LEFT);
            }
            if (Properties.Settings.Default.U_B_Control_LEFT_D == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.D, Properties.Settings.Default.U_B_ControlSpeed_LEFT);
            }
        }

        private async void KEY_RIGHT_Command()
        {
            RIGHT_BUTTON.SetResourceReference(StyleProperty, "subwindowControlsGui2");
            if (Properties.Settings.Default.U_B_Control_RIGHT_A == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.A, Properties.Settings.Default.U_B_ControlSpeed_RIGHT);
            }
            if (Properties.Settings.Default.U_B_Control_RIGHT_B == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.B, Properties.Settings.Default.U_B_ControlSpeed_RIGHT);
            }
            if (Properties.Settings.Default.U_B_Control_RIGHT_C == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.C, Properties.Settings.Default.U_B_ControlSpeed_RIGHT);
            }
            if (Properties.Settings.Default.U_B_Control_RIGHT_D == true)
            {
                await _bk.DirectCommand.TurnMotorAtSpeedAsync(OutputPort.D, Properties.Settings.Default.U_B_ControlSpeed_RIGHT);
            }
        }



        //UNCOMMANDS

        private async void UP_KEY_UNCOMMAND()
        {
            
            if (Properties.Settings.Default.U_B_Control_UP_A == true)
            {
                await _bk.DirectCommand.StopMotorAsync(OutputPort.A, false);
            }
            if (Properties.Settings.Default.U_B_Control_UP_B == true)
            {
                await _bk.DirectCommand.StopMotorAsync(OutputPort.B, false);
            }
            if (Properties.Settings.Default.U_B_Control_UP_C == true)
            {
                await _bk.DirectCommand.StopMotorAsync(OutputPort.C, false);
            }
            if (Properties.Settings.Default.U_B_Control_UP_D == true)
            {
                await _bk.DirectCommand.StopMotorAsync(OutputPort.D, false);
            }
           
            UP_BUTTON.SetResourceReference(StyleProperty, "subwindowControlsGui");
        }

        private async void DOWN_KEY_UNCOMMAND()
        {
            DOWN_BUTTON.SetResourceReference(StyleProperty, "subwindowControlsGui");
            if (Properties.Settings.Default.U_B_Control_DOWN_A == true)
            {
                await _bk.DirectCommand.StopMotorAsync(OutputPort.A, false);
            }
            if (Properties.Settings.Default.U_B_Control_DOWN_B == true)
            {
                await _bk.DirectCommand.StopMotorAsync(OutputPort.B, false);
            }
            if (Properties.Settings.Default.U_B_Control_DOWN_C == true)
            {
                await _bk.DirectCommand.StopMotorAsync(OutputPort.C, false);
            }
            if (Properties.Settings.Default.U_B_Control_DOWN_D == true)
            {
                await _bk.DirectCommand.StopMotorAsync(OutputPort.D, false);
            }
        }

        private async void LEFT_KEY_UNCOMMAND()
        {
            LEFT_BUTTON.SetResourceReference(StyleProperty, "subwindowControlsGui");
            if (Properties.Settings.Default.U_B_Control_LEFT_A == true)
            {
                await _bk.DirectCommand.StopMotorAsync(OutputPort.A, false);
            }
            if (Properties.Settings.Default.U_B_Control_LEFT_B == true)
            {
                await _bk.DirectCommand.StopMotorAsync(OutputPort.B, false);
            }
            if (Properties.Settings.Default.U_B_Control_LEFT_C == true)
            {
                await _bk.DirectCommand.StopMotorAsync(OutputPort.C, false);
            }
            if (Properties.Settings.Default.U_B_Control_LEFT_D == true)
            {
                await _bk.DirectCommand.StopMotorAsync(OutputPort.D, false);
            }
        }

        private async void RIGHT_KEY_UNCOMMAND()
        {
            RIGHT_BUTTON.SetResourceReference(StyleProperty, "subwindowControlsGui");
            if (Properties.Settings.Default.U_B_Control_RIGHT_A == true)
            {
                await _bk.DirectCommand.StopMotorAsync(OutputPort.A, false);
            }
            if (Properties.Settings.Default.U_B_Control_RIGHT_B == true)
            {
                await _bk.DirectCommand.StopMotorAsync(OutputPort.B, false);
            }
            if (Properties.Settings.Default.U_B_Control_RIGHT_C == true)
            {
                await _bk.DirectCommand.StopMotorAsync(OutputPort.C, false);
            }
            if (Properties.Settings.Default.U_B_Control_RIGHT_D == true)
            {
                await _bk.DirectCommand.StopMotorAsync(OutputPort.D, false);
            }
        }


        // COMMANDS END




        private void UI_ANY_UNPressed(object sender, RoutedEventArgs e)
        {
            UI_ALL_UNCOMMAND();
            Trace.WriteLine("knopf nicht mehr gedrückt");
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Up)
            {
                anykeypressed = true;
                KEY_UP_Command();
            }
            if (e.Key == Key.Down)
            {
                anykeypressed = true;
                KEY_DOWN_Command();
            }
            if (e.Key == Key.Left)
            {
                anykeypressed = true;
                KEY_LEFT_Command();
            }
            if (e.Key == Key.Right)
            {
                anykeypressed = true;
                KEY_RIGHT_Command();
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                anykeypressed = false;
                UP_KEY_UNCOMMAND();
            }
            if (e.Key == Key.Down)
            {
                anykeypressed = false;
                DOWN_KEY_UNCOMMAND();
            }
            if (e.Key == Key.Left)
            {
                anykeypressed = false;
                LEFT_KEY_UNCOMMAND();
            }
            if (e.Key == Key.Right)
            {
                anykeypressed = false;
                RIGHT_KEY_UNCOMMAND();
            }
        }

        // NORMAL COntrolwindow end

        // SHortcuts subwindow

        // WINDOW CONTROLS
        private void return_button_Click(object sender, RoutedEventArgs e)
        {
            controlsgrid.Visibility = Visibility.Visible;
            shortcutgrid.Visibility = Visibility.Hidden;
        }
        // WINDOW CONTROLS END

        // validate textinput

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

     
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text ,e.Text);

        }

        public static bool IsValid(string str ,string sttr)
        {
            if (sttr == "-") { return true; }
            int i;
            return int.TryParse(str, out i) && i >= -100 && i <= 100;
        }


        // validate end
        // UP

        private void UP_Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            int.TryParse(UP_Entry.Text,out i);
            Properties.Settings.Default.U_B_ControlSpeed_UP = i;
           
            Properties.Settings.Default.Save();
        }

       
        private void UP_A_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.U_B_Control_UP_A == false) {
                Properties.Settings.Default.U_B_Control_UP_A = true;
                UP_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            } else
            {
                Properties.Settings.Default.U_B_Control_UP_A = false;
                UP_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }

        }

        private void UP_B_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.U_B_Control_UP_B == false)
            {
                Properties.Settings.Default.U_B_Control_UP_B = true;
                UP_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.U_B_Control_UP_B = false;
                UP_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void UP_C_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.U_B_Control_UP_C == false)
            {
                Properties.Settings.Default.U_B_Control_UP_C = true;
                UP_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.U_B_Control_UP_C = false;
                UP_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void UP_D_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.U_B_Control_UP_D == false)
            {
                Properties.Settings.Default.U_B_Control_UP_D = true;
                UP_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.U_B_Control_UP_D = false;
                UP_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        //DOWN

        private void DOWN_Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            int.TryParse(DOWN_Entry.Text, out i);
            Properties.Settings.Default.U_B_ControlSpeed_DOWN = i;

            Properties.Settings.Default.Save();
        }

        private void DOWN_A_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.U_B_Control_DOWN_A == false)
            {
                Properties.Settings.Default.U_B_Control_DOWN_A = true;
                DOWN_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.U_B_Control_DOWN_A = false;
                DOWN_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void DOWN_B_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.U_B_Control_DOWN_B == false)
            {
                Properties.Settings.Default.U_B_Control_DOWN_B = true;
                DOWN_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.U_B_Control_DOWN_B = false;
                DOWN_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void DOWN_C_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.U_B_Control_DOWN_C == false)
            {
                Properties.Settings.Default.U_B_Control_DOWN_C = true;
                DOWN_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.U_B_Control_DOWN_C = false;
                DOWN_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void DOWN_D_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.U_B_Control_DOWN_D == false)
            {
                Properties.Settings.Default.U_B_Control_DOWN_D = true;
                DOWN_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.U_B_Control_DOWN_D = false;
                DOWN_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        //LEFT

        private void LEFT_Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            int.TryParse(LEFT_Entry.Text, out i);
            Properties.Settings.Default.U_B_ControlSpeed_LEFT = i;

            Properties.Settings.Default.Save();
        }

        private void LEFT_A_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.U_B_Control_LEFT_A == false)
            {
                Properties.Settings.Default.U_B_Control_LEFT_A = true;
                LEFT_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.U_B_Control_LEFT_A = false;
                LEFT_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void LEFT_B_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.U_B_Control_LEFT_B == false)
            {
                Properties.Settings.Default.U_B_Control_LEFT_B = true;
                LEFT_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.U_B_Control_LEFT_B = false;
                LEFT_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void LEFT_C_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.U_B_Control_LEFT_C == false)
            {
                Properties.Settings.Default.U_B_Control_LEFT_C = true;
                LEFT_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.U_B_Control_LEFT_C = false;
                LEFT_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void LEFT_D_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.U_B_Control_LEFT_D == false)
            {
                Properties.Settings.Default.U_B_Control_LEFT_D = true;
                LEFT_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.U_B_Control_LEFT_D = false;
                LEFT_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        //RIGHT

        private void Right_Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            int.TryParse(RIGHT_Entry.Text, out i);
            Properties.Settings.Default.U_B_ControlSpeed_RIGHT = i;

            Properties.Settings.Default.Save();
        }

        private void RIGHT_A_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.U_B_Control_RIGHT_A == false)
            {
                Properties.Settings.Default.U_B_Control_RIGHT_A = true;
                RIGHT_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.U_B_Control_RIGHT_A = false;
                RIGHT_A.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void RIGHT_B_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.U_B_Control_RIGHT_B == false)
            {
                Properties.Settings.Default.U_B_Control_RIGHT_B = true;
                RIGHT_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.U_B_Control_RIGHT_B = false;
                RIGHT_B.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void RIGHT_C_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.U_B_Control_RIGHT_C == false)
            {
                Properties.Settings.Default.U_B_Control_RIGHT_C = true;
                RIGHT_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.U_B_Control_RIGHT_C = false;
                RIGHT_C.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        private void RIGHT_D_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.U_B_Control_RIGHT_D == false)
            {
                Properties.Settings.Default.U_B_Control_RIGHT_D = true;
                RIGHT_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortPushedButton");
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.U_B_Control_RIGHT_D = false;
                RIGHT_D.SetResourceReference(StyleProperty, "subwindowControlsGuiShortButtons");
                Properties.Settings.Default.Save();
            }
        }

        
    }
}
