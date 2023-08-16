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
using System.Data.OleDb;
using System.Data;
using System.Threading;

namespace SBModuleWorkDB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;
        SqlDataAdapter sqlDAdapter;
        DataTable dataTable;
        DataRowView dataRView;
        public MainWindow()
        {
            InitializeComponent();
            Initialization();
        }
        private void Initialization()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "SBModuleDB",
                IntegratedSecurity = true,
                ConnectTimeout = 30,
                Encrypt = false,
                TrustServerCertificate = false,
                ApplicationIntent = ApplicationIntent.ReadWrite,
                MultiSubnetFailover = false
            };
            sqlConnection = new SqlConnection(builder.ConnectionString);
            sqlDAdapter = new SqlDataAdapter();
            dataTable = new DataTable();

            var sql = @"select * from Clients order by Clients.Id";
            sqlDAdapter.SelectCommand = new SqlCommand(sql, sqlConnection);

            sqlDAdapter.Fill(dataTable);
            gridView.DataContext = dataTable.DefaultView;
        }
        
    }
}
