using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace SBModuleWorkDB
{
    public static class NpgSqlManager
    {
        private static NpgsqlDataSource _dataSourse;
        private static string _connectionString;
        private static string _request;
        public static void Init()
        {
            // initialize connection to postgre
            //var connectionStr = "Host=localhost;Port=5432;Username=postgres;Database=SBWorkPurchases";
            NpgsqlConnectionStringBuilder npgBuilder = new NpgsqlConnectionStringBuilder()
            {
                Host = "localhost",
                Port = 5432,
                Username = "postgres",
                Database = "SBWorkPurchases",
                Password = "65872143",
            };
            _connectionString = npgBuilder.ConnectionString;
            _dataSourse = NpgsqlDataSource.Create(_connectionString);
        }
        public static List<Order> Select()
        {
            _request = @"SELECT * FROM defaultschema.Products;";
            var cmd = new NpgsqlCommand(_request);
            return Select(cmd);
        }
        public static List<Order> Select(string param)
        {
            _request = @"SELECT * FROM defaultschema.Products WHERE Email = (@p1);";
            var cmd = new NpgsqlCommand(_request) { Parameters = { new NpgsqlParameter("p1", param) } };
            return Select(cmd);
        }
        private static List<Order> Select(NpgsqlCommand cmd)
        {
            var _orders = new List<Order>();
            using (var connection = _dataSourse.CreateConnection())
            {
                connection.Open();
                cmd.Connection = connection;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader["Id"].ToString();
                    var email = reader["Email"].ToString();
                    var code = reader["Code"].ToString();
                    var product = reader["Product"].ToString();
                    _orders.Add(new Order(Int32.Parse(id), email, Int32.Parse(code), product));
                }
            }
            return _orders;
        }
        public static void Insert(Order order)
        {
            _request = @"INSERT INTO defaultschema.Products (Email, Code, Product) VALUES ((@p1), (@p2), (@p3));";
            using (var connection = _dataSourse.CreateConnection())
            {
                connection.Open();
                var cmd = new NpgsqlCommand(_request, connection)
                {
                    Parameters =
                    {
                        new NpgsqlParameter("p1", order.Email),
                        new NpgsqlParameter("p2", order.Code),
                        new NpgsqlParameter("p3", order.Product)
                    }
                };
                cmd.ExecuteNonQuery();
            }
        }
        public static void Update(string oldvalue, string newvalue)
        {
            _request = @"UPDATE defaultschema.Products SET Email=(@p1) WHERE Email=(@p2);";
            using (var connection = _dataSourse.CreateConnection())
            {
                connection.Open();
                var cmd = new NpgsqlCommand(_request, connection)
                {
                    Parameters =
                    {
                        new NpgsqlParameter("p1", newvalue),
                        new NpgsqlParameter("p2", oldvalue)
                    }
                };
                cmd.ExecuteNonQuery();
            }
        }
        public static void Delete(string email)
        {
            _request = @"DELETE FROM defaultschema.Products WHERE Email=(@p1);";
            using (var connection = _dataSourse.CreateConnection())
            {
                connection.Open();
                var cmd = new NpgsqlCommand(_request, connection)
                {
                    Parameters = { new NpgsqlParameter("p1", email) }
                };
                cmd.ExecuteNonQuery();
            }
        }
    }
}
