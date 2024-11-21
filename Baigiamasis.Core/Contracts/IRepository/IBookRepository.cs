using Baigiamasis.Core.Models.Knygos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis.Core.Contracts.IRepository
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        List<Book> GetBooksByCategory(string category);
        Book GetBookById(int id);
        void AddBook(Book book);
        void RemoveBook(int id);
    }
}
