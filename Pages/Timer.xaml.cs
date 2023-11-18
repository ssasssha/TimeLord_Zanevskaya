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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TimeLord_Zanevskaya.Pages
{
    /// <summary>
    /// Логика взаимодействия для Timer.xaml
    /// </summary>
    public partial class Timer : Page
    {
        public Timer()
        {
            InitializeComponent();

            dispatcherTimer.Tick += TimerSecond;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }

        public DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public float full_second = 0;
        public bool start_timer = false;
        private void StartTimer(object sender, RoutedEventArgs e)
        {
            if (start_timer == false)
            {
                if (hoursTim.Text == "")
                    hoursTim.Text = "00";

                if (minutesTim.Text == "")
                    minutesTim.Text = "00";

                if (secondsTim.Text == "")
                    secondsTim.Text = "00";
                try
                {
                    full_second = (float.Parse(hoursTim.Text) * 60 * 60) + (float.Parse(minutesTim.Text) * 60) + (float.Parse(secondsTim.Text)); // установите свое значение таймера
                }
                catch { MessageBox.Show("Введите время для таймера"); }
                dispatcherTimer.Start();
                start_timer = true;
                start.Content = "Остановить";
            }
            else
            {
                dispatcherTimer.Stop();
                start_timer = false;
                start.Content = "Запустить";
            }
        }
        private void TimerSecond(object sender, EventArgs e)
        {
            full_second--;
            if (full_second <= 0)
            {
                dispatcherTimer.Stop();
                time.Content = "00:00:00";
                start_timer = false;
                start.Content = "Запустить";
                return;
            }
            float hours = (int)(full_second / 60 / 60);
            float minuts = (int)(full_second / 60) - (hours * 60);
            float seconds = full_second - (hours * 60 * 60) - (minuts * 60);

            string s_seconds = seconds.ToString();
            if (seconds < 10) s_seconds = "0" + seconds;

            string s_minuts = minuts.ToString();
            if (minuts < 10) s_minuts = "0" + minuts;

            string s_hours = hours.ToString();
            if (hours < 10) s_hours = "0" + hours;

            time.Content = s_hours + ":" + s_minuts + ":" + s_seconds;
        }
    }
}
