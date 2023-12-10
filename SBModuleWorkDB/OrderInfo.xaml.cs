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

namespace SBModuleWorkDB
{
    /// <summary>
    /// Логика взаимодействия для OrderInfo.xaml
    /// </summary>
    public partial class OrderInfo : Window
    {
        public OrderInfo(string email)
        {
            InitializeComponent();
            InitializeWnidow(email);
            
        }
        private void InitializeWnidow(string email)
        {

        }
        private void CreateNewOrder(object sender, RoutedEventArgs e)
        {

        }
    }
}
