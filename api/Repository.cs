using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ServiceStack.Redis;

namespace ProteinTrackerMVC.api
{

    public interface  IRepository
    {
        long AddUser(string name, int goal);
    }
    public class Repository : IRepository
    {
        IRedisClientsManager RedisManager { get; set; }
    
        public Repository(IRedisClientsManager redisManager)
        {
            RedisManager = redisManager;
        }

        public long AddUser(string name, int goal)
        {
            using (var redisclient = RedisManager.GetClient())
            {
                var redisUsers = redisclient.As<User>();
                var user = new User() {Name = name, Goal = goal, ID = redisUsers.GetNextSequence()};
                redisUsers.Store(user);
                return user.ID;
                ;

                ;
            }
        }
    }
}