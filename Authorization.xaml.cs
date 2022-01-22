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
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Authorization_window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Login_label.Width = Authorization_grid.Width;
            Login_label.Height = Authorization_grid.Height / 8;

            Login.Width = Authorization_grid.Width;
            Login.Height = Authorization_grid.Height / 8;
            Login.Margin = new Thickness(0, Authorization_grid.Height / 8, 0, 0);

            Password_label.Width = Authorization_grid.Width;
            Password_label.Height = Authorization_grid.Height / 8;
            Password_label.Margin = new Thickness(0, Authorization_grid.Height / 8 * 3, 0, 0);

            Password.Width = Authorization_grid.Width;
            Password.Height = Authorization_grid.Height / 8;
            Password.Margin = new Thickness(0, Authorization_grid.Height / 8 * 4, 0, 0);

            Enter_but.Width = Authorization_grid.Width;
            Enter_but.Height = Authorization_grid.Height / 8;
            Enter_but.Margin = new Thickness(0, Authorization_grid.Height / 8 * 6, 0, 0);

            Error_label.Width = Authorization_grid.Width;
            Error_label.Height = Authorization_grid.Height / 8;
            Error_label.Margin = new Thickness(0, Authorization_grid.Height / 8 * 7, 0, 0);
        }
    }
}
