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

namespace TimeLord_Zanevskaya
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OpenPages(pages.stopwatch);
        }

        public enum  pages
        {
            stopwatch,
            timer
        }

        public void OpenPages(pages _page)
        {
            if (_page == pages.stopwatch)
            {
                frame.Navigate(new Pages.Stopwatch());
                btnSwitch.Content = "Таймер";
            }
            if (_page == pages.timer)
            {
                frame.Navigate(new Pages.Timer());
                btnSwitch.Content = "Секундомер";
            }
        }

        private void Page_switch(object sender, RoutedEventArgs e)
        {
            if (btnSwitch.Content.ToString() == "Таймер")
            {
                OpenPages(pages.timer);
                return;
            }
            if (btnSwitch.Content.ToString() == "Секундомер")
            {
                OpenPages(pages.stopwatch);
                return;
            }
        }
    }
}
