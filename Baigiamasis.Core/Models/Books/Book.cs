using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis.Core.Models.Knygos
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public decimal RentalPrice { get; set; }

        public Book()
        {

        }

        public Book(int id, DateTime creationDate, string title, string author, string category, decimal rentalPrice): base(id, creationDate)
        {
            Title = title;
            Author = author;
            Category = category;
            RentalPrice = rentalPrice;
        }
    }
}
