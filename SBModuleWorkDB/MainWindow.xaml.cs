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
using System.IO;

namespace SBModuleWorkDB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _sqlConnectionString;
        private string _sqlRequest;
        
        public MainWindow()
        {
            InitializeComponent();
            Initialization();
        }
        private void Initialization()
        {
            // initialize sql connection to database
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                //InitialCatalog = MyData.localSqlCatalog,
                // enter your attached file name 
                AttachDBFilename = @"C:\Users\user\Documents\GitHub\SBModuleWorkDB\SBModuleWorkDB\DB(.mdf)\SBModuleDB.mdf",
                IntegratedSecurity = true,
                ConnectTimeout = 30,
                Encrypt = false,
                TrustServerCertificate = false,
                ApplicationIntent = ApplicationIntent.ReadWrite,
                MultiSubnetFailover = false
            };

            _sqlConnectionString = builder.ConnectionString;

            SqlConnection connection = new SqlConnection(_sqlConnectionString);

            try
            {
                connection.Open();
            }
            catch
            {
                MessageBox.Show("incorrect db filename");
            }

            if (connection.State == System.Data.ConnectionState.Open)
            {
                Select();

                gridView.DataContext = Repository.Clients;

                NpgSqlManager.Init();

                connection.Close();
            }
            else
            {
                Application.Current.Shutdown();
            }
            
        }
        private void AddNewMenuItem(object sender, RoutedEventArgs e)
        {
            ClientInfo window = new ClientInfo(Repository.GetLast(), WindowType.AddNew);
            window.GetResult += (c) =>
            {
                Repository.AddClient(c);
                Insert(c);
                window.Close();
            };
            window.Show();
        }
        private void EditMenuItem(object sender, RoutedEventArgs e)
        {
            if (!IsItemSelected())
            {
                MessageBox.Show("none client selected !");
                return;
            }
            var index = gridView.SelectedIndex;
            ClientInfo window = new ClientInfo(Repository.Clients[index], WindowType.Edit);
            window.GetResult += (c) =>
            {
                if (!Repository.Clients[index].Email.Equals(c.Email))
                {
                    NpgSqlManager.Update(Repository.Clients[index].Email, c.Email);
                }
                Repository.Clients[index].Rewrite(c);
                Update(c);
                window.Close();
            };
            window.Show();
        }
        private void DeleteMenuItem(object sender, RoutedEventArgs e)
        {
            if (!IsItemSelected()) return;
            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionString))
            {
                sqlConnection.Open();
                _sqlRequest = @"DELETE FROM Clients WHERE [Id] = @id";
                SqlCommand cmd = new SqlCommand(_sqlRequest, sqlConnection);
                cmd.Parameters.AddWithValue("@id", Repository.Clients[gridView.SelectedIndex].Id);
                cmd.ExecuteNonQuery();
            }
            NpgSqlManager.Delete(Repository.Clients[gridView.SelectedIndex].Email);
            Repository.Clients.RemoveAt(gridView.SelectedIndex);
        }
        private void ShowOrders(object sender, RoutedEventArgs e)
        {
            if (!IsItemSelected()) return;
            OrderInfo window = new OrderInfo(Repository.Clients[gridView.SelectedIndex].Email);
            window.Show();
        }
        private void SeeAllOrders(object sender, RoutedEventArgs e)
        {
            Orders window = new Orders();
            window.Show();
        }
        private void Select()
        {
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
                    Repository.AddClient(new Client(Int32.Parse(id), secondName, name, patr, number, email));
                }
            }
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
                _sqlRequest = @"INSERT INTO Clients ([Id], [SecondName], [Name], [Patronymic], [Number], [Email])
                                VALUES (@id, @secondname, @name, @patronymic, @number, @email)";
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
        private bool IsItemSelected() => gridView.SelectedItem != null;
    }
}
