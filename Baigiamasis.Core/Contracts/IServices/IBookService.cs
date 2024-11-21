using Baigiamasis.Core.Models.Knygos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis.Core.Contracts.IServices
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void RemoveBook(int id);
        List<Book> SearchByCategory(string category);
    }
}
