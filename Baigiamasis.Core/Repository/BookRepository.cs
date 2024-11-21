using Baigiamasis.Core.Contracts.IRepository;
using Baigiamasis.Core.Models.Knygos;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis.Core.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString;
        public BookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Methods

        public void AddBook(Book book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                if(book is DigitalBook)
                {
                    connection.Execute("INSERT INTO Entities (CreationDate, Title, Author, Category, RentalPrice, FileFormat, FileSizeMB) VALUES (@CreationDate, @Title, @Author, 'Digital', @RentalPrice, @FileFormat, @FileSizeMB)", book);
                }
                else
                {
                    connection.Execute("INSERT INTO Entities (CreationDate, Title, Author, Category, RentalPrice, NumberOfCopies, ISBN) VALUES (@CreationDate, @Title, @Author, 'Print', @RentalPrice, @NumberOfCopies, @ISBN)", book);
                }
            }
        }

        public List<Book> GetAllBooks()
        {
            List<Book> allBooks = new List<Book>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                allBooks.AddRange(connection.Query<DigitalBook>("SELECT * FROM Entities WHERE Category = 'Digital'").ToList());

                allBooks.AddRange(connection.Query<PrintBook>("SELECT * FROM Entities WHERE Category = 'Print'").ToList());
            }
            return allBooks;
        }

        public List<Book> GetBooksByCategory(string category)
        {
            category = category.ToLower();
            List<Book> booksByCategory = new List<Book>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                if(category == "digital")
                {
                    booksByCategory.AddRange(connection.Query<DigitalBook>("SELECT * FROM Entities WHERE Category = 'Digital'").ToList());
                }
                else if(category == "print")
                {
                    booksByCategory.AddRange(connection.Query<PrintBook>("SELECT * FROM Entities WHERE Category = 'Print'").ToList());
                };
            }
            return booksByCategory;
        }

        public Book GetBookById(int id)
        {
            //Book bookById = new Book();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                try
                {
                    DigitalBook bookById = new DigitalBook();
                    bookById = connection.QueryFirst<DigitalBook>("SELECT * FROM Entities WHERE Id = @Id AND Category = 'Digital'", new { Id = id });
                    return bookById;
                }
                catch
                {
                    PrintBook bookById = new PrintBook();
                    bookById = connection.QueryFirst<PrintBook>("SELECT * FROM Entities WHERE Id = @Id AND Category = 'Print'", new { Id = id });
                    return bookById;
                }
            }
        }

        public void RemoveBook(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("DELETE FROM Entities WHERE Id = @id", new { id });
            }
        }
    }
}
