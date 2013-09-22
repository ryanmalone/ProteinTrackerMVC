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