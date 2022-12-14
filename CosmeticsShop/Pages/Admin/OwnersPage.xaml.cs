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
    /// Логика взаимодействия для OwnersPage.xaml
    /// </summary>
    public partial class OwnersPage : Page
    {
        public OwnersPage()
        {
            InitializeComponent();
            using (var db = new Models.Data.UchPraktEntities())
            {
                OwnersDG.ItemsSource = db.Owner.ToList(); //Загрузка данных о владельцах в DataGrid OwnersDG
            }
        }
    }
}
