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
using System.Windows.Shapes;

namespace CosmeticsShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.Admin.CityObjectPage());
        }

        private void AddProduct_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new Pages.Admin.CityObjectPage());
        }

        private void SeeOrder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new Pages.Admin.ApplicationsPage());
        }

        private void SeeOwner_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new Pages.Admin.OwnersPage());
        }
    }
}
