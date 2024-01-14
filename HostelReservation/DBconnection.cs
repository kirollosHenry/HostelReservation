using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelReservation
{
    internal class DBconnection
    {
        public static readonly string connStr = @"Data Source=DESKTOP-VD76OGN\SQLEXPRESS01;Initial Catalog=Somabay;Integrated Security=True";
        static SqlConnection conn;
        public static void OpenConnection()
        {
            conn = new SqlConnection(connStr);
            conn.Open();
        }

        public static void CloseConnection()
        {
            conn.Close();
        }

        public static int ExecuteQueries(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, conn);

            int ctr = cmd.ExecuteNonQuery();
            return ctr;
        }


        public static bool CheckPkExists(int pk)
        {
            OpenConnection();
            string sql = "SELECT TOP 1 1 FROM Hotel WHERE HotelId= '" + pk + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }
        public static int CountRecords()
        {
            OpenConnection();
            string sql = "SELECT COUNT(*) FROM Hotels";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int recordCount = Convert.ToInt32(cmd.ExecuteScalar());
            CloseConnection();
            return recordCount;
        }
        public static SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
