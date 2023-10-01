using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_managment.stock.database.connection
{
    public class ConnectionFactory
    {
        public MySqlConnection GetConnection()
        {
            //string de conexao
            string vcon = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            return new MySqlConnection(vcon);
        }
    }
}
