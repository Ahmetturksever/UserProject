using Dapper;
using System;
using System.Text;
using UserProject.Users.UsersData.DbManager;

namespace UserProject.Users.UsersData.Repositories
{
    public class UserInfoRepository
    {
        private StringBuilder sb;
        private string connectionString = "Ahmet düzeltecek";
        private ConnectionManager connectionManager;
        public UserInfoEnitity UserLogin(string userNameOrEmail, string password)
        {
            try
            {
                connectionManager = new ConnectionManager();
                var conn = connectionManager.CreateConnection(connectionString);
                sb = new StringBuilder();
                sb.Append("SELECT * FROM UserInfos ")
                    .Append(" WHERE ")
                    .Append(" (UserEMail = @UserInfo) ")
                    .Append(" OR ")
                    .Append(" (UserName = @UserInfo)");
                var parameters = new { UserInfo = userNameOrEmail };
                conn.Open();
                var result = conn.QueryFirst<UserInfoEnitity>(sb.ToString(), parameters);
                if (result != null && result.Password == password)
                    return result;
                throw new Exception("Hatalı kullanıcı adı / Şifre");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
