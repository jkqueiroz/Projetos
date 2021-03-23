using innner.DFO_API.Model;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace innner.DFO_API.Util
{
    public class RedisService
    {
        const string redisServer = "localhost:6379";
        public ServiceStack.Redis.RedisClient redisClient;
        public RedisService()
        {
            redisClient = new RedisClient(redisServer);
        }

        public List<string> GetAll()
        {
            return redisClient.GetAllKeys();
        }

        public User GetById(int id)
        {
            return redisClient.Get<User>(id.ToString());
        }

        public bool CreateUser(User user)
        {
            return redisClient.Set<User>(user.Id.ToString(), user);
        }

        public bool UpdateUser(User user) 
        {
            return redisClient.Set<User>(user.Id.ToString(), user);
        }

        public void DeleteUser(string user)
        {
            redisClient.Remove(user);
        }

    }
}
