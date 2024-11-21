using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis.Core.Models
{
    public class Rental : BaseEntity
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime RentStart { get; set; }
        public DateTime RentEnd { get; set; }

        public Rental()
        {

        }

        public Rental(int id, DateTime creationDate, int bookId, int userId, DateTime rentStart, DateTime rentEnd): base(id, creationDate)
        {
            BookId = bookId;
            UserId = userId;
            RentStart = rentStart;
            RentEnd = rentEnd;
        }
    }
}
