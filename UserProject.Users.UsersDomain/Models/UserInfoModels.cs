namespace UserProject.Users.UsersDomain.Models
{
    public class UserInfoModel : BaseModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public string UserEMail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int FailCount { get; set; }
    }

    public class UserLoginModel
    {
        //User Name or User EMail
        public string UserInfo { get; set; }
        public string Password { get; set; }
    }
}
