using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis.Core.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public User()
        {

        }

        public User(int id, DateTime creationDate, string name, string email): base(id, creationDate)
        {
            Name = name;
            Email = email;
        }
    }
}
