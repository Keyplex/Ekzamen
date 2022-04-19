using Ekzamen.SQL;
using Ekzamen.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ekzamen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    ///     
    public partial class MainWindow : Window, INotifyPropertyChanged
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
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            BookList = Core.DB.Shop.ToList();

        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            var NewBook = new Shop();
            var NewBookWindow = new AddEditShop(NewBook);
            if ((bool)NewBookWindow.ShowDialog())
            {
                BookList = Core.DB.Shop.ToList();
                Core.DB.SaveChanges();
                PropertyChanged(this, new PropertyChangedEventArgs("BookList"));
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Выйти из приложения?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ShoppingCart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RemoveCart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cart_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
