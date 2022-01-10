using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace weatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Timers.Timer t;
        int sec;
        String city="Ankara";
        weatherApi weatherApi = new weatherApi();
        public MainWindow()
        {
            InitializeComponent();
            timer();
            getWeather();

        }

        private void OnTimeEvent(object? sender, ElapsedEventArgs e)
        {
            sec += 1;
            
            if(sec == 5)
            {
                getWeather();
                sec = 0;
            }
            if (weatherApi.Description.Equals("kar yağışlı") || weatherApi.Description.Equals("hafif kar yağışlı"))
            {
                img_snow.Dispatcher.Invoke(new Action(() =>
                {
                    img_snow.Visibility = Visibility.Visible;
                }));
            }
            else
            {
                img_snow.Dispatcher.Invoke(new Action(() =>
                {
                    img_snow.Visibility = Visibility.Hidden;
                }));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void getWeather()
        {
            try
            {
                
                weatherApi.getApi(city);
                lbl_name.Dispatcher.Invoke(new Action(() =>
                {
                    lbl_name.Content = weatherApi.Name;
                }));

                lbl_temp.Dispatcher.Invoke(new Action(() =>
                {
                    lbl_temp.Content = weatherApi.Temp + " °C";
                }));

                lbl_description.Dispatcher.Invoke(new Action(() =>
                {
                    lbl_description.Content = weatherApi.Description;
                }));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
               
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txt_city.Text=txt_city.Text.Trim();
                city=txt_city.Text;
                getWeather();
            }
        }
        private void timer()
        {
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
            t.Start();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton==MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        private void gifControl()
        {
                if (weatherApi.Description.Equals("kar yağışlı") || weatherApi.Description.Equals("hafif kar yağışlı"))
                {
                    img_snow.Dispatcher.Invoke(new Action(() =>
                    {
                        img_snow.Visibility = Visibility.Visible;
                    }));
                }
                else
                {
                    img_snow.Dispatcher.Invoke(new Action(() =>
                    {
                        img_snow.Visibility = Visibility.Hidden;
                    }));
                }
        }

    }
}
