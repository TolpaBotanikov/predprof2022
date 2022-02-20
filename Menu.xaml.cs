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

namespace predprof2022
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void See_data(object sender, RoutedEventArgs e)
        {
            if(sender == Graf_but)
            {
                NavigationService.Navigate(new Graf());
            }
            else if (sender == Table_but)
            {
                NavigationService.Navigate(new Table());
            }
        }
    }
}
