using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SBModuleWorkDB
{
    /// <summary>
    /// Логика взаимодействия для OrderInfo.xaml
    /// </summary>
    public partial class OrderInfo : Window
    {
        private ObservableCollection<Order> _orders;
        private string _currentEmail;
        public OrderInfo(string email)
        {
            InitializeComponent();
            InitializeWindow(email);
            
        }
        private void InitializeWindow(string email)
        {
            _orders = new ObservableCollection<Order>();
            _currentEmail = email;
            var list = NpgSqlManager.Select(email);
            foreach(var o in list)
            {
                _orders.Add(o);
            }
            gridView.ItemsSource = _orders;
        }
        private void CreateNewOrder(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(code.Text) || String.IsNullOrEmpty(productName.Text))
            {
                MessageBox.Show("empty spaces !");
                return;
            }
            _orders.Add(new Order(0, _currentEmail, Int32.Parse(code.Text), productName.Text));
            NpgSqlManager.Insert(_orders.Last());
        }
    }
}
