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

    public class AddProteinResponse
    {
        public int NewTotal { get; set; }
    }

    [Route("/users/{userid}", "POST")]
    public class AddProtein
    {
        public long UserID { get; set; }
        public int Amount { get; set; }
    }

    public class UserResponse
    {
       public IEnumerable<User> Users { get; set; } 
    }

    [Route("/users", "GET")]
    public class Users
    {
    }

    public class AddUserResponse
    {
        public long UserID { get; set; }
    }

    [Route("/users", "POST")]
    public class AddUser
    {
        public string Name { get; set; }
        public int Goal { get; set;}
    }
}