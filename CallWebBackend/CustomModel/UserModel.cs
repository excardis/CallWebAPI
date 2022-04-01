using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallWebBackend.CustomModel
{
    public class UserModel
    {
        public int Id { get; set; }
        public string AgentCode { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public double TotalPurchaseAmount { get; set; }

        internal static UserModel ConvertUserToUserModel(Database.User user)
        {
            UserModel model = new UserModel();
            model.Id = user.Id;
            model.AgentCode = user.AgentCode;
            model.FullName = user.FirstName + user.LastName;
            model.Email = user.Email;
            model.TotalPurchaseAmount = 10000; // can get the total purchase amount from query and assign here

            return model;
        }
    }
}
