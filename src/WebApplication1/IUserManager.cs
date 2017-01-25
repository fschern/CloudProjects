using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1
{
  public interface IUserManager
  {
    void AddUser(User user);
    User GetUser(int id);
    IEnumerable<User> GetAllUsers();
  }
}
