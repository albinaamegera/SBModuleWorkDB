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
    /// Логика взаимодействия для AddNewClient.xaml
    /// </summary>
    public partial class ClientInfo : Window
    {
        public event Action<Client> GetResult;
        private Client _currentClient;
        private WindowType _type;
        public ClientInfo(Client client, WindowType type)
        {
            InitializeComponent();
            InitializeWindow(client, type);
        }
        private void InitializeWindow(Client client, WindowType type)
        {
            _currentClient = client;
            _type = type;
            switch (_type)
            {
                case WindowType.AddNew:
                    Title = "Add new client";
                    break;
                case WindowType.Edit:
                    Title = "Edit client's info";
                    secondname.Text = _currentClient.SecondName;
                    name.Text = _currentClient.Name;
                    patronymic.Text = _currentClient.Patronymic;
                    number.Text = _currentClient.Number;
                    email.Text = _currentClient.Email;
                    break;
            }
        }
        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(secondname.Text) || 
                String.IsNullOrEmpty(name.Text) ||
                String.IsNullOrEmpty(patronymic.Text) ||
                String.IsNullOrEmpty(number.Text) ||
                String.IsNullOrEmpty(email.Text))
            {
                MessageBox.Show("fill the blank spaces", "warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                int id = _type == WindowType.AddNew ? _currentClient.Id + 1 : _currentClient.Id;
                var client = new Client(id, secondname.Text, name.Text, patronymic.Text, number.Text, email.Text);
                GetResult?.Invoke(client);
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    public enum WindowType
    {
        AddNew,
        Edit,
    }
}
