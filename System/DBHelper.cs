using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace System
{
    internal class DBHelper
    {
        private string SQL_ConnectStr = "server = 127.0.0.1; port = 3306; user = root ; password = root; database =rating_system";
        public MySqlConnection MySqlConnection;

        public void Database_connection()
        {
            try
            {
                MySqlConnection = new MySqlConnection(SQL_ConnectStr);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.WriteLine("数据库连接成功");
            }
        }
    }
}
