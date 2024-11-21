using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis.Core.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }

        public BaseEntity()
        {

        }

        public BaseEntity(int id, DateTime creationDate)
        {
            Id = id;
            CreationDate = creationDate;
        }
    }
}
