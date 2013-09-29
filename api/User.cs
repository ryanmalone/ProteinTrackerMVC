using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceHost;

namespace ProteinTrackerMVC.api
{
    public class User
    {
        public string Name { get; set; }
        public int Goal { get; set; }
        public int Total { get; set; }
        public long Id { get; set; }
    }

    public class AddProteinResponse
    {
        public int NewTotal { get; set; }
    }

    [Route("/users/{userid}", "POST")]
    public class AddProtein : IReturn<AddProteinResponse>
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
    public class AddUser : IReturn<AddUserResponse>
    {
        public string Name { get; set; }
        public int Goal { get; set; }
    }
}
