using Ekzamen.SQL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Ekzamen.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditShop.xaml
    /// </summary>
    public partial class AddEditShop : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Shop CurrentShop { get; set; }

        private IEnumerable<Shop> _BookList;
        public IEnumerable<Shop> BookList
        {
            get
            {
                return _BookList;
            }
            set
            {
                _BookList = value;
            }
        }

        public AddEditShop(Shop shops)
        {
            InitializeComponent();
            DataContext = this;

            CurrentShop = shops;
            BookList = Core.DB.Shop.ToList();
        }

        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog GetImageDialog = new OpenFileDialog();
            GetImageDialog.Filter = "Файлы изображений: (*.png, *.jng, *.jpg)| *.png; *.jnp; *.jpg";
            GetImageDialog.InitialDirectory = Environment.CurrentDirectory;
            if (GetImageDialog.ShowDialog() == true)
            {
                CurrentShop.Imagess = GetImageDialog.FileName.Substring(Environment.CurrentDirectory.Length);
                PropertyChanged(this, new PropertyChangedEventArgs("AgentList"));
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentShop.ID == 0) Core.DB.Shop.Add(CurrentShop);
            try
            {
                Core.DB.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка");
                return;
            }
            DialogResult = true;
        }
    }
}
