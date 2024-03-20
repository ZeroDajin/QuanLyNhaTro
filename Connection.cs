using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DOAN
{
    internal class Connection
    {
        private static string strconnection = @"Data Source=DESKTOP-SDN9VVQ;Initial Catalog=ADMIN;Integrated Security=True";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(strconnection);
        }
    }
}
