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
        private static string _connectionString;
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
        }
        public static void OpenConnection()
        {
            NpgsqlConnection npgConnection = new NpgsqlConnection(_connectionString);
            npgConnection.Open();
            if (npgConnection.FullState != System.Data.ConnectionState.Open)
                throw new Exception("connection not opened");
        }
    }
}
