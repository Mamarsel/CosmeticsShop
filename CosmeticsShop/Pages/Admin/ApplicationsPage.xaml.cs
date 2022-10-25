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

namespace CosmeticsShop.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для ApplicationsPage.xaml
    /// </summary>
    public partial class ApplicationsPage : Page
    {
        public ApplicationsPage()
        {
            InitializeComponent();
            using (var db = new Models.Data.UchPraktEntities())
            {
                ApllicationsDG.ItemsSource = db.Applications.ToList();
            }
        }

        private void BtnForEdit_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void BtnForDelete_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
