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
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace predprof2022
{
    public partial class Graf : Page
    {
        public Graf()
        {
            InitializeComponent();
            Chart.ChartAreas.Add(new ChartArea("Main"));
            var currentSeries = new Series("Data")
            {
                IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Line
            };
            Chart.Series.Add(currentSeries);

            HttpClient client = new HttpClient();
            var content = client.GetAsync("http://black-bread-board.herokuapp.com/api/akeses").Result.Content;
            var json = content.ReadAsStringAsync().Result;
            List<AKES> akeses = JsonConvert.DeserializeObject<AKES_list>(json).akeses;
            Combobox.ItemsSource = akeses;
            Combobox.SelectedIndex = 0;
            Datepicker.SelectedDate = DateTime.Now.Date;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Datepicker.SelectedDate == null)
            {
                Datepicker.SelectedDate = DateTime.Now.Date;
            }
            HttpClient client = new HttpClient();
            var id = ((AKES)Combobox.SelectedItem).id;
            var content = client.GetAsync($"http://black-bread-board.herokuapp.com/api/{id}/akes_outputs").Result.Content;
            var json = content.ReadAsStringAsync().Result;
            List<AKES_outputs> akes_output = JsonConvert.DeserializeObject<AKES_outputs_list>(json).akes_outputs;
            List<DateTime> dates = new List<DateTime>();
            List<float?> floats = new List<float?>();
            Series currentSeries = Chart.Series.FirstOrDefault();
            currentSeries.Points.Clear();
            foreach (AKES_outputs i in akes_output)
            {
                if (i.datetime_start.Date <= Datepicker.SelectedDate.Value.Date && Datepicker.SelectedDate.Value.Date <= i.datetime_end.Date)
                {
                    i.all.Add(i.active_power_A);
                    i.all.Add(i.active_power_A_off);
                    i.all.Add(i.active_power_B);
                    i.all.Add(i.active_power_B_off);
                    i.all.Add(i.active_power_C);
                    i.all.Add(i.active_power_C_off);
                    if (i.all.All(a => a != null))
                    {
                        float? p_off = i.active_power_A_off + i.active_power_B_off + i.active_power_C_off;
                        float? p_on = i.active_power_A + i.active_power_B + i.active_power_C;
                        float? n = (p_off - p_on) / p_off * 100;
                        dates.Add(i.datetime_start);
                        floats.Add(n);
                    }
                }
            }
            for (int j = 0; j < floats.Count; j++)
            {
                currentSeries.Points.AddXY(dates[j].Date.ToString(), floats[j]);
            }

        }

        private void toMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }
    }
}
