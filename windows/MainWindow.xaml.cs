using System;
using System.Windows;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;
using System.Diagnostics;
using System.Windows.Input;
using EV3_Control.windows;
using EV3_Control.windows.controlwindows.Normal;
using System.Xml;
using System.Windows.Media.Imaging;

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

        private void temp_button(object sender, RoutedEventArgs e)
        {
            ConnectControllerBase twindow = new ConnectControllerBase();
            twindow.Owner = this;
            twindow.Show();
            this.Hide();
        }

        private void over_Click(object sender, RoutedEventArgs e)
        {
            over ov = new over();
            ov.Owner = this;
            ov.Show();
            this.Hide();
        }

        private void references_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/JuniorJacki/EV3-Controller");
        }

        private void tutorial_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/JuniorJacki/EV3-Controller/wiki");
        }
        // TABS 
        private void Tab1_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage picture = new BitmapImage();
            picture.BeginInit();
            picture.UriSource = new Uri(@"pack://application:,,,/EV3_Control;component/assets/pictures/tab-image1.png");
            picture.EndInit();
            TabImageField.Source = picture;
        }

        private void Tab2_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage picture = new BitmapImage();
            picture.BeginInit();
            picture.UriSource = new Uri(@"pack://application:,,,/EV3_Control;component/assets/pictures/tab-image2.png");
            picture.EndInit();
            TabImageField.Source = picture;
        }

        private void Tab3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tab4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tab5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tab6_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
