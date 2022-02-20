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
using System.Net.Http;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Net;
using System.Reflection;
using System.IO;

namespace predprof2022
{
    public partial class Authorization : Page
    {
        private HttpClient client = new HttpClient();

        public Authorization()
        {
            InitializeComponent();
        }

        private void Auth_but_Click(object sender, RoutedEventArgs e)
        {
            User user1 = new User(loginTb.Text, passwordTb.Password);
            string user = JsonConvert.SerializeObject(user1);
            var request = WebRequest.Create("http://black-bread-board.herokuapp.com/api/login"); 
            request.ContentType = "application/json";
            request.Method = "GET";
            var type = request.GetType(); var currentMethod = type.GetProperty("CurrentMethod", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(request);
            var methodType = currentMethod.GetType();
            methodType.GetField("ContentBodyNotAllowed", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(currentMethod, false);
            using (var streamWriter = new StreamWriter(request.GetRequestStream())) { streamWriter.Write(user); }
            var response = (HttpWebResponse)request.GetResponse();
            var encoding = ASCIIEncoding.UTF8;
            string responseText;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                responseText = reader.ReadToEnd();
            }
            Succecful tf = JsonConvert.DeserializeObject<Succecful>(responseText);
            if (tf.Successfully)
            {
                NavigationService.Navigate(new Menu());
            }
            else
            {
                Error_lab.Content = "Неверный логин/пароль";
            }
        }
    }
}