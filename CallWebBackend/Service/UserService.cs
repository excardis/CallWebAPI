using CallWebBackend.Common;
using CallWebBackend.CustomModel;
using CallWebBackend.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CallWebBackend.Service
{
    public class UserService
    {
        private static UserService _instance;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static UserService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserService();
            }
            return _instance;
        }

        public ResultLog GetActiveUsers()
        {
            ResultLog result = new ResultLog();
            try
            {
                ApiContext context = new ApiContext();

                // Example of get rows and cast to model
                var data = context.Users
                    .Where(i => i.Status == true)
                    .Select(UserModel.ConvertUserToUserModel) // convert each row into custom model
                    .ToList();

                result.Message = "Users retrieved success";
                result.ReturnObject = data;
            }
            catch (Exception ex)
            {
                result.Code = (int)HttpStatusCode.InternalServerError;
                result.Message = Util.ExtractExceptionMessage(ex);
            }
            return result;
        }
    }
}
