using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis.Core.Models.Knygos
{
    public class DigitalBook : Book
    {
        public string FileFormat { get; set; }
        public double FileSizeMB { get; set; }

        public DigitalBook()
        {

        }

        public DigitalBook(int id, DateTime creationDate, string title, string author, string category, decimal rentalPrice, string fileFormat, double fileSizeMB): base(id, creationDate, title, author, category, rentalPrice)
        {
            FileFormat = fileFormat;
            FileSizeMB = fileSizeMB;
        }
    }
}
