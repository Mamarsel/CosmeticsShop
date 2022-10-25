using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using CosmeticsShop.Models.Data;

namespace CosmeticsShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddObjectWindow.xaml
    /// </summary>
    public partial class AddObjectWindow : Window
    {
        private CityObject _e;
        public Pages.Admin.CityObjectPage _cs = new Pages.Admin.CityObjectPage();
        public AddObjectWindow(Pages.Admin.CityObjectPage _c, CityObject e = null)
        {
            InitializeComponent();
            

            _e = e;
            _cs = _c;

            if (_e != null)
            {
                
                NameTB.Text = _e.Name;
                TypeTB.Text = _e.Type;
                AddressTB.Text = _e.Address;

                NumberTB.Text = Convert.ToString(_e.NumberOfSeats);
                DateTB.Text = Convert.ToString(_e.DateOpening);
                OwnerIDTB.Text = Convert.ToString(_e.OwnerID);
                AvailableCB.IsChecked = _e.Available;

                LabelOfBorder.Text = "Изменить";
                lbl.Content = "Изменение объекта";
            }
            else
            {
                LabelOfBorder.Text = "Добавить";
                lbl.Content = "Добавление объекта";
            }
        }

        private void AddBTN_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Owner owner = new Owner();
            using(var db = new UchPraktEntities())
            {
                 owner = db.Owner.FirstOrDefault(x => x.NameOwner == OwnerIDTB.Text);
            }
            if (owner != null &&  !String.IsNullOrEmpty(AddressTB.Text) && !String.IsNullOrEmpty(TypeTB.Text) && !String.IsNullOrEmpty(OwnerIDTB.Text))
            {
                if (_e == null)
                {
                    using (UchPraktEntities db = new UchPraktEntities())
                    {
                        CityObject s = new CityObject()
                        {

                            Name = NameTB.Text,
                            Type = TypeTB.Text,
                            Address = AddressTB.Text,
                            OwnerID = owner.Id,
                            Available = AvailableCB.IsChecked.Value,
                            DateOpening = Convert.ToDateTime(DateTB.Text),
                            NumberOfSeats = Convert.ToInt32(NumberTB.Text),
                        };
                        db.CityObject.Add(s);
                        db.SaveChanges();
                        _cs.RefreshObj(); // Вот здесь заново загружаю датагрид при добавлении
                        this.Hide();
                        MessageBox.Show("Данные добавлены");
                    }
                }
                if (_e != null)
                {
                    using (UchPraktEntities db = new UchPraktEntities())
                    {
                        var ee = db.CityObject.FirstOrDefault(p => p.Id == _e.Id);
                        ee.Name = NameTB.Text;
                        ee.Type = TypeTB.Text;
                        ee.Address = AddressTB.Text;
                        ee.OwnerID = owner.Id;
                        ee.Available = AvailableCB.IsChecked.Value;
                        ee.DateOpening = Convert.ToDateTime(DateTB.Text);
                        ee.NumberOfSeats = Convert.ToInt32(NumberTB.Text);
                        db.SaveChanges();
                        _cs.RefreshObj();
                        this.Hide();
                        MessageBox.Show("Данные добавлены");
                    }

                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!\n Возможно, данный владелец не найден.");
            }

        }
    }
}
