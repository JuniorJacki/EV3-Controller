using System;
using System.Windows;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;
using System.Diagnostics;
using System.Windows.Input;
using EV3_Control.windows;

namespace EV3_Control
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            Trace.WriteLine("Programm gestartet");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void preferences_click(object sender, RoutedEventArgs e)
        {
            preferences subwindow = new preferences();

            this.Hide();
          
            subwindow.Owner = this;

           
            subwindow.Show();
            subwindow.Activate();
        }

        private void connect_button(object sender, RoutedEventArgs e)
        {
            connectbase window = new connectbase();
            window.Owner = this;
            window.Show();
            this.Hide();
        }
    }
}
