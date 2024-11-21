using Baigiamasis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis.Core.Contracts.IRepository
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
    }
}
