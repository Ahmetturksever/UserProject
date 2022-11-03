using System;
using System.Data;
using System.Data.SqlClient;

namespace UserProject.Users.UsersData.DbManager
{
    public class ConnectionManager
    {
        public SqlConnection CreateConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
        public void OpenConnection(string connectionString)
        {
            try
            {
                var conn = CreateConnection(connectionString);
                if (conn != null)
                    conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void OpenConnection(SqlConnection connection)
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CloseConnection(SqlConnection connection)
        {
            try
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
