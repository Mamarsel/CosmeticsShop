using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using CosmeticsShop.Models.Data;
using CosmeticsShop.Pages.Admin;

namespace CosmeticsShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddObjectWindow.xaml
    /// </summary>
    public partial class AddObjectWindow : Window
    {
        private CityObject _cityObj;
        public CityObjectPage CityObjPage = new CityObjectPage();
        public AddObjectWindow(CityObjectPage _cityObjectPage, CityObject cityobj = null)
        {
            InitializeComponent();
            _cityObj = cityobj;
            CityObjPage = _cityObjectPage;
            if (_cityObj != null) //Если переданный объект не пустой, то заполняем поля для ввода значениями этого объекта
            {
                NameTB.Text = _cityObj.Name;
                TypeTB.Text = _cityObj.Type;
                AddressTB.Text = _cityObj.Address;

                NumberTB.Text = Convert.ToString(_cityObj.NumberOfSeats);
                DateTB.Text = Convert.ToString(_cityObj.DateOpening);
                OwnerIDTB.Text = Convert.ToString(_cityObj.OwnerID);
                AvailableCB.IsChecked = _cityObj.Available;

                LabelOfBorder.Text = "Изменить";
                lbl.Content = "Изменение объекта";
            }
            else
            {
                LabelOfBorder.Text = "Добавить";
                lbl.Content = "Добавление объекта";
            }
        }
        /// <summary>
        /// Обработчик событий для изменения или добавления данных
        /// В зависимости он значения параметра конструктора cityObj проводится 
        /// либо изменение выбранных данных
        /// либо добавление новых.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBTN_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Owner owner = new Owner();
            using(var db = new UchPraktEntities())
            {
                 owner = db.Owner.FirstOrDefault(x => x.NameOwner == OwnerIDTB.Text);
            }
            if (owner != null &&  !String.IsNullOrEmpty(AddressTB.Text) && !String.IsNullOrEmpty(TypeTB.Text) && !String.IsNullOrEmpty(OwnerIDTB.Text))
            {
                if (_cityObj == null)
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
                        CityObjPage.RefreshObj();
                        this.Hide();
                        MessageBox.Show("Данные добавлены");
                    }
                }
                if (_cityObj != null)
                {
                    using (UchPraktEntities db = new UchPraktEntities())
                    {
                        var dbCityObject = db.CityObject.FirstOrDefault(p => p.Id == _cityObj.Id);
                        dbCityObject.Name = NameTB.Text;
                        dbCityObject.Type = TypeTB.Text;
                        dbCityObject.Address = AddressTB.Text;
                        dbCityObject.OwnerID = owner.Id;
                        dbCityObject.Available = AvailableCB.IsChecked.Value;
                        dbCityObject.DateOpening = Convert.ToDateTime(DateTB.Text);
                        dbCityObject.NumberOfSeats = Convert.ToInt32(NumberTB.Text);
                        db.SaveChanges();
                        CityObjPage.RefreshObj();
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
