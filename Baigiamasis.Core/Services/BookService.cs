using Baigiamasis.Core.Contracts.IRepository;
using Baigiamasis.Core.Contracts.IServices;
using Baigiamasis.Core.Models.Knygos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // Methods

        public void AddBook(Book book)
        {
            _bookRepository.AddBook(book);
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public void RemoveBook(int id)
        {
            _bookRepository.RemoveBook(id);
        }

        public List<Book> SearchByCategory(string category)
        {
            return _bookRepository.GetBooksByCategory(category);
        }
    }
}
