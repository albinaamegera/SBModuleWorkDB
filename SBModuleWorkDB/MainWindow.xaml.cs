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
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace SBModuleWorkDB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Client> _clients;
        private string _sqlConnectionString;
        private string _sqlRequest;
        public MainWindow()
        {
            InitializeComponent();
            Initialization();
        }
        private void Initialization()
        {
            _clients = new ObservableCollection<Client>();
            
            // initialize sql connection to database
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
            {
                DataSource = MyData.localSqlSourse,
                InitialCatalog = MyData.localSqlCatalog,
                IntegratedSecurity = true,
                ConnectTimeout = 30,
                Encrypt = false,
                TrustServerCertificate = false,
                ApplicationIntent = ApplicationIntent.ReadWrite,
                MultiSubnetFailover = false
            };

            _sqlConnectionString = builder.ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionString))
            {
                sqlConnection.Open();
                _sqlRequest = @"SELECT * FROM Clients ORDER BY Clients.Id";
                SqlCommand cmd = new SqlCommand(_sqlRequest, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader["Id"].ToString();
                    var secondName = reader["SecondName"].ToString();
                    var name = reader["Name"].ToString();
                    var patr = reader["Patronymic"].ToString();
                    var number = reader["Number"].ToString();
                    var email = reader["Email"].ToString();
                    _clients.Add(new Client(Int32.Parse(id), secondName, name, patr, number, email));
                }
            }
            gridView.DataContext = _clients;

            NpgSqlManager.Init();
        }
        private void AddNewMenuItem(object sender, RoutedEventArgs e)
        {
            ClientInfo window = new ClientInfo(_clients.Last(), WindowType.AddNew);
            window.GetResult += (c) =>
            {
                _clients.Add(c);
                Insert(c);
                window.Close();
            };
            window.Show();
        }
        private void EditMenuItem(object sender, RoutedEventArgs e)
        {
            var index = gridView.SelectedIndex;
            if (gridView.SelectedItem == null)
            {
                MessageBox.Show("none client selected !");
                return;
            }
            ClientInfo window = new ClientInfo(_clients[index], WindowType.Edit);
            window.GetResult += (c) =>
            {
                if (!_clients[index].Email.Equals(c.Email))
                {
                    NpgSqlManager.Update(_clients[index].Email, c.Email);
                }
                _clients[index].Rewrite(c);
                Update(c);
                window.Close();
            };
            window.Show();
        }
        private void DeleteMenuItem(object sender, RoutedEventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionString))
            {
                sqlConnection.Open();
                _sqlRequest = @"DELETE FROM Clients WHERE [Id] = @id";
                SqlCommand cmd = new SqlCommand(_sqlRequest, sqlConnection);
                cmd.Parameters.AddWithValue("@id", _clients[gridView.SelectedIndex].Id);
                cmd.ExecuteNonQuery();
            }
            NpgSqlManager.Delete(_clients[gridView.SelectedIndex].Email);
            _clients.RemoveAt(gridView.SelectedIndex);
        }
        private void ShowOrders(object sender, RoutedEventArgs e)
        {
            OrderInfo window = new OrderInfo(_clients[gridView.SelectedIndex].Email);
            window.Show();
        }
        private void SeeAllOrders(object sender, RoutedEventArgs e)
        {
            Orders window = new Orders();
            window.Show();
        }
        private void Update(Client client)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionString))
            {
                sqlConnection.Open();
                _sqlRequest = @"UPDATE Clients SET SecondName = @secondname, 
                                                   [Name] = @name, 
                                                   Patronymic = @patronymic, 
                                                   Number = @number, 
                                                   Email = @email 
                                WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(_sqlRequest, sqlConnection);
                cmd.Parameters.AddWithValue("@id", client.Id);
                cmd.Parameters.AddWithValue("@secondname", client.SecondName);
                cmd.Parameters.AddWithValue("@name", client.Name);
                cmd.Parameters.AddWithValue("@patronymic", client.Patronymic);
                cmd.Parameters.AddWithValue("@number", client.Number);
                cmd.Parameters.AddWithValue("@email", client.Email);
                cmd.ExecuteNonQuery();
            }
        }
        private void Insert(Client client)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionString))
            {
                sqlConnection.Open();
                _sqlRequest = @"INSERT INTO Clients ([SecondName], [Name], [Patronymic], [Number], [Email])
                                VALUES (@secondname, @name, @patronymic, @number, @email)
                                SET @id = @@IDENTITY";
                SqlCommand cmd = new SqlCommand(_sqlRequest, sqlConnection);
                cmd.Parameters.AddWithValue("@id", client.Id);
                cmd.Parameters.AddWithValue("@secondname", client.SecondName);
                cmd.Parameters.AddWithValue("@name", client.Name);
                cmd.Parameters.AddWithValue("@patronymic", client.Patronymic);
                cmd.Parameters.AddWithValue("@number", client.Number);
                cmd.Parameters.AddWithValue("@email", client.Email);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
