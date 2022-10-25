using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using iText.Layout.Element;
using Paragraph = iText.Layout.Element.Paragraph;
using CosmeticsShop.Models.Data;

namespace CosmeticsShop.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для CityObjectPage.xaml
    /// </summary>
    /// 
    public partial class CityObjectPage : Page
    {
        BaseFont bf;
        Font f_title;
        Font f_text;
        public CityObjectPage()
        {
            InitializeComponent();
            using (var db = new Models.Data.UchPraktEntities())
            {
                ObjectsDG.ItemsSource = db.CityObject.ToList();
            }
            
        }
        public void RefreshObj()
        {
            ObjectsDG.ItemsSource = null;
            ObjectsDG.Items.Clear();
            using (var db = new UchPraktEntities())
            {
                ObjectsDG.ItemsSource = db.CityObject.ToList();

            }

        }
        private void BtnForEdit_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Windows.AddObjectWindow addObjectWindow = new Windows.AddObjectWindow(this, (sender as Border).DataContext as CityObject);
            addObjectWindow.Show();
        }

        private void BtnForDelete_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить выбранные данные?", "Удаление объекта", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                using (UchPraktEntities db = new UchPraktEntities())
                {
                    CityObject s = (sender as Border).DataContext as CityObject;
                    var attendance = db.AttendanceObject.Where(x=>x.CityObjectID == s.Id).ToList();
                    var cityobj = db.CityObject.FirstOrDefault(p => p.Id == s.Id);
                    db.CityObject.Remove(cityobj);
                    db.AttendanceObject.RemoveRange(attendance);
                    db.SaveChanges();
                    RefreshObj();
                    MessageBox.Show("Данные удалены");
                }
            }
        }

        private void AddObject_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Windows.AddObjectWindow a = new Windows.AddObjectWindow(this);
            a.Show();
        }

        /// <summary>
        ///  Метод, предназначенный для экспорта данных в PDF файл
        /// </summary>
        private void PrintToPDF_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PdfPTable table = new PdfPTable(7);
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 20, 20, 40, 20);
            PdfWriter writer = PdfWriter.GetInstance(doc, new System.IO.FileStream("Test.pdf", System.IO.FileMode.Create)); //Создаем файл
            
            bf = BaseFont.CreateFont("C:\\games\\ofont.ru_Times New Roman.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            f_title = new Font(bf, 20);
            f_text = new Font(bf, 14);
            
            doc.Open();
            doc.Add(new Phrase("Объекты города",f_title));
            for (int j = 0; j < 7; ++j)
            {
                if (ObjectsDG.Columns[j].Header.ToString() == "Изменить" || ObjectsDG.Columns[j].Header.ToString() == "Удалить")
                    continue;
                table.AddCell(new Phrase(ObjectsDG.Columns[j].Header.ToString(), f_text));
            }
            table.HeaderRows = 0;
            IEnumerable itemsSource = ObjectsDG.ItemsSource as IEnumerable;
            if (itemsSource != null)
            {
                foreach (var item in itemsSource)
                {
                    DataGridRow row = ObjectsDG.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                    if (row != null)
                    {
                        DataGridCellsPresenter presenter = InterfaceClass.FindVisualChild<DataGridCellsPresenter>(row);
                        for (int i = 0; i < 7; ++i)
                        {
                            DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(i);
                            TextBlock txt = cell.Content as TextBlock;
                            if (txt != null)
                            {
                                table.AddCell(new Phrase(txt.Text, f_text));
                            }
                        }
                    }
                }
                doc.Add(table);
                doc.Close();
                System.Diagnostics.Process.Start("Test.pdf");
            }
        }
    }
}
