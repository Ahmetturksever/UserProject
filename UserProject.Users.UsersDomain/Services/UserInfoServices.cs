using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProject.Users.UsersData.Repositories;
using UserProject.Users.UsersDomain.Helper;
using UserProject.Users.UsersDomain.Models;

namespace UserProject.Users.UsersDomain.Services
{
    public class UserInfoServices
    {
        public ResponseModel<UserInfoModel> UserLogin(UserLoginModel request)
        {
            if (string.IsNullOrEmpty(request.UserInfo) || string.IsNullOrEmpty(request.Password))
                return ResponseModelHelper<UserInfoModel>.WarnResponse("Kullanıcı bilgileri boş geçilemez!");
            try
            {
                var result = new UserInfoRepository().UserLogin(request.UserInfo, request.Password);
                if (result == null)
                    return ResponseModelHelper<UserInfoModel>.ErrorResponse("Beklenmedik hata");

                var model = new UserInfoModel()
                {
                    Id = result.Id,
                    UserEMail = result.UserEMail
                    //Devam ediniz
                };
                return ResponseModelHelper<UserInfoModel>.SuccesResponse(model);

            }
            catch (Exception ex)
            {
                return ResponseModelHelper<UserInfoModel>.ErrorResponse(ex.Message);
            }
        }


    }
}
