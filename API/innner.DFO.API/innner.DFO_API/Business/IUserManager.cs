using innner.DFO_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace innner.DFO_API.Business
{
    public interface IUserManager
    {
        List<User> GetAll();
        User GetById(int Id);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
    }
}
