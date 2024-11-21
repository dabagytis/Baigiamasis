using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis.Core.Models.Knygos
{
    public class PrintBook : Book
    {
        public int NumberOfCopies { get; set; }
        public string ISBN { get; set; }

        public PrintBook()
        {

        }

        public PrintBook(int id, DateTime creationDate, string title, string author, string category, decimal rentalPrice, int numberOfCopies, string isbn): base(id, creationDate, title, author, category, rentalPrice)
        {
            NumberOfCopies = numberOfCopies;
            ISBN = isbn;
        }
    }
}
