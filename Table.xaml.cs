using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    /// Логика взаимодействия для Table.xaml
    /// </summary>
    public partial class Table : Page
    {
        public Table()
        {
            InitializeComponent();
            HttpClient client = new HttpClient();
            var content = client.GetAsync("http://black-bread-board.herokuapp.com/api/akeses").Result.Content;
            var json = content.ReadAsStringAsync().Result;
            List<AKES> akeses = JsonConvert.DeserializeObject<AKES_list>(json).akeses;
            Combobox.ItemsSource = akeses;
            Combobox.SelectedIndex = 0;
        }

        private void toMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }

        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HttpClient client = new HttpClient();
            var id = ((AKES)Combobox.SelectedItem).id;
            var content = client.GetAsync($"http://black-bread-board.herokuapp.com/api/{id}/akes_outputs").Result.Content;
            var json = content.ReadAsStringAsync().Result;
            List<AKES_outputs> akes_output = JsonConvert.DeserializeObject<AKES_outputs_list>(json).akes_outputs;
            foreach (AKES_outputs i in akes_output)
            {
                if (i.all.All(a => a != null))
                {
                    float? p_off = i.active_power_A_off + i.active_power_B_off + i.active_power_C_off;
                    float? p_on = i.active_power_A + i.active_power_B + i.active_power_C;
                    i.effectiveness = (p_off - p_on) / p_off * 100;
                }
            }
            aKES_outputsDataGrid.ItemsSource = akes_output;
        }
    }
}
