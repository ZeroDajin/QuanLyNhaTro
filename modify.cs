using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DOAN
{
    internal class modify
    {
        public modify()
        {
        }
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        SqlDataAdapter adapter;
        public List<TaikhoanAD> TaikhoanADs(string query)
        {
            List<TaikhoanAD> taikhoanADs=new List<TaikhoanAD>();
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand=new SqlCommand(query,sqlConnection);
                dataReader = sqlCommand.ExecuteReader();

                while(dataReader.Read())
                {
                    taikhoanADs.Add(new TaikhoanAD(dataReader.GetString(0),dataReader.GetString(1)));
                }
                sqlConnection.Close();

            }
            return taikhoanADs; 
        }
        public List<TaikhoanK> TaikhoanKs(string query)
        {
            List<TaikhoanK> taikhoanKs = new List<TaikhoanK>();
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    taikhoanKs.Add(new TaikhoanK(dataReader.GetString(0), dataReader.GetString(1)));
                }
                sqlConnection.Close();

            }
            return taikhoanKs;
        }

        public DataTable Table(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                adapter = new SqlDataAdapter(query, sqlConnection);
                adapter.Fill(dt);
                sqlConnection.Close();
            }
            return dt;
        }
        public void Command(string query)
        {
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
        
    }
}
