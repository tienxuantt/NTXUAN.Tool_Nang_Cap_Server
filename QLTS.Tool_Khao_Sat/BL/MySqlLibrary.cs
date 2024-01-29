using MySql.Data.MySqlClient;
using System.Data;

namespace QLTS.Tool_Khao_Sat
{
    public class MySqlLibrary
    {
        private readonly string connectionString;

        public MySqlLibrary(string server, string database, string username, string password)
        {
            // Tạo chuỗi kết nối
            connectionString = $"Server={server};Database={database};User ID={username};Password={password};";
        }

        // Hàm thực hiện truy vấn SELECT
        public DataTable ExecuteQuery(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        // Hàm thực hiện truy vấn INSERT, UPDATE, DELETE
        public int ExecuteNonQuery(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }

        // Hàm kiểm tra kết nối đến cơ sở dữ liệu
        public bool TestConnection()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}