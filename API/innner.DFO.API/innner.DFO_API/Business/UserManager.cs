using innner.DFO_API.Model;
using innner.DFO_API.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace innner.DFO_API.Business
{
    public class UserManager : IUserManager
    {
        public RedisService redisService;

        public UserManager()
        {
            redisService = new RedisService();
        }
        public List<User> GetAll()
        {
            var listStringUsers = redisService.GetAll();
            List<User> listUsers = new List<User>();

            if (listStringUsers.Count > 0)
            {
                foreach(var user in listStringUsers)
                {
                    int id = 0;

                    if (int.TryParse(user, out id))
                    {
                        User deserealized = this.GetById(id);

                        if (deserealized != null)
                        {
                            listUsers.Add(new User
                            {
                                Id = deserealized.Id,
                                Endereco = deserealized.Endereco,
                                Nome = deserealized.Nome,
                                Idade = deserealized.Idade
                            });
                        }
                    }
                    
                }
            }

            return listUsers;
        }

        public User GetById(int id)
        {
            return redisService.GetById(id);
        }
        public bool CreateUser(User user)
        {
            return redisService.CreateUser(user);
        }
        public bool UpdateUser(User user)
        {
            return redisService.UpdateUser(user);
        }
        public bool DeleteUser(User user)
        {
            bool result;
            try
            {
                redisService.DeleteUser(user.Id.ToString());
                result = true;
            }
            catch(Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
