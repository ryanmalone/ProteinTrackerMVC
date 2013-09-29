using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace ProteinTrackerMVC.api
{
    public class UserService : Service
    {

        public IRepository Repository { get; set; }

        public object Post(AddUser request)
        {

            var id = Repository.AddUser(request.Name, request.Goal);

            // add the user
            return new AddUserResponse { UserID = id };
        }

        public object Get(Users request)
        {
            return new UserResponse {Users = Repository.GetUsers()};
        }

        public object Post(AddProtein request)
        {
            var user = Repository.GetUsers(request.UserID);
            user.Total += request.Amount;
            Repository.UpdateUser(user);
            return new AddProteinResponse {NewTotal = user.Total};


        }
    }

   
}