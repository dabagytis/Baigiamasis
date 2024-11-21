using Baigiamasis.Core.Contracts.IRepository;
using Baigiamasis.Core.Contracts.IServices;
using Baigiamasis.Core.Models.Knygos;
using Baigiamasis.Core.Services;
using Moq;

namespace Baigiamasis.Tests
{
    public class BookServiceTest
    {
        [Fact]
        public void AddDigitalBookTest()
        {
            // Arrange
            DigitalBook bookSample1 = new DigitalBook
            {
                Id = 1,
                CreationDate = DateTime.Now,
                Title = "Harry Potter",
                Author = "J.K. Rowling",
                Category = "Digital",
                RentalPrice = 10,
                FileFormat = "pdf",
                FileSizeMB = 50,
            };

            Mock<IBookRepository> bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(x => x.AddBook(bookSample1));
            IBookService bookService = new BookService(bookRepositoryMock.Object);

            //Act
            bookService.AddBook(bookSample1);

            //Assert
            bookRepositoryMock.Verify(x => x.AddBook(It.IsAny<Book>()), Times.Once);
            bookRepositoryMock.Verify(x => x.AddBook(It.IsAny<DigitalBook>()), Times.Once);
            bookRepositoryMock.Verify(x => x.AddBook(It.IsAny<PrintBook>()), Times.Never);
        }

        [Fact]
        public void AddPrintBookTest()
        {
            // Arrange
            PrintBook bookSample2 = new PrintBook
            {
                Id = 2,
                CreationDate = DateTime.Now,
                Title = "The Shining",
                Author = "Stephen King",
                Category = "Print",
                RentalPrice = 15,
                NumberOfCopies = 3,
                ISBN = "444333222",
            };

            Mock<IBookRepository> bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(x => x.AddBook(bookSample2));
            IBookService bookService = new BookService(bookRepositoryMock.Object);

            //Act
            bookService.AddBook(bookSample2);

            //Assert
            bookRepositoryMock.Verify(x => x.AddBook(It.IsAny<Book>()), Times.Once);
            bookRepositoryMock.Verify(x => x.AddBook(It.IsAny<DigitalBook>()), Times.Never);
            bookRepositoryMock.Verify(x => x.AddBook(It.IsAny<PrintBook>()), Times.Once);
        }

        [Fact]
        public void GetAllBooksTest()
        {
            //Arrange
            DigitalBook bookSample1 = new DigitalBook
            {
                Id = 1,
                CreationDate = DateTime.Now,
                Title = "Harry Potter",
                Author = "J.K. Rowling",
                Category = "Digital",
                RentalPrice = 10,
                FileFormat = "pdf",
                FileSizeMB = 50,
            };

            PrintBook bookSample2 = new PrintBook
            {
                Id = 2,
                CreationDate = DateTime.Now,
                Title = "The Shining",
                Author = "Stephen King",
                Category = "Print",
                RentalPrice = 15,
                NumberOfCopies = 3,
                ISBN = "444333222",
            };
            List<Book> booksExpected = new List<Book>();
            booksExpected.Add(bookSample1);
            booksExpected.Add(bookSample2);


            Mock<IBookRepository> bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(x => x.GetAllBooks()).Returns(booksExpected);
            IBookService bookService = new BookService(bookRepositoryMock.Object);

            //Act
            var result = bookService.GetAllBooks();

            //Assert
            bookRepositoryMock.Verify(x => x.GetAllBooks(), Times.Once);

            Assert.Contains<Book>(bookSample1, result);
            Assert.Contains<Book>(bookSample2, result);
            Assert.Equal(result.Count, booksExpected.Count);
        }

        [Fact]
        public void GetBookByIdTest()
        {
            //Arrange
            DigitalBook bookSample1 = new DigitalBook
            {
                Id = 1,
                CreationDate = DateTime.Now,
                Title = "Harry Potter",
                Author = "J.K. Rowling",
                Category = "Digital",
                RentalPrice = 10,
                FileFormat = "pdf",
                FileSizeMB = 50,
            };

            PrintBook bookSample2 = new PrintBook
            {
                Id = 2,
                CreationDate = DateTime.Now,
                Title = "The Shining",
                Author = "Stephen King",
                Category = "Print",
                RentalPrice = 15,
                NumberOfCopies = 3,
                ISBN = "444333222",
            };

            Mock<IBookRepository> bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(x => x.GetBookById(1)).Returns(bookSample1);
            bookRepositoryMock.Setup(x => x.GetBookById(2)).Returns(bookSample2);
            IBookService bookService = new BookService(bookRepositoryMock.Object);

            //Act
            var resultBook1 = bookService.GetBookById(1);
            var resultBook2 = bookService.GetBookById(2);
            var resultNull = bookService.GetBookById(3);

            //Assert
            Assert.Equal(resultBook1, bookSample1);
            Assert.Equal(resultBook2, bookSample2);
            Assert.Null(resultNull);
        }

        [Fact]
        public void RemoveBookTest()
        {
            //Arrange
            DigitalBook bookSample1 = new DigitalBook
            {
                Id = 1,
                CreationDate = DateTime.Now,
                Title = "Harry Potter",
                Author = "J.K. Rowling",
                Category = "Digital",
                RentalPrice = 10,
                FileFormat = "pdf",
                FileSizeMB = 50,
            };

            PrintBook bookSample2 = new PrintBook
            {
                Id = 2,
                CreationDate = DateTime.Now,
                Title = "The Shining",
                Author = "Stephen King",
                Category = "Print",
                RentalPrice = 15,
                NumberOfCopies = 3,
                ISBN = "444333222",
            };

            Mock<IBookRepository> bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(x => x.RemoveBook(1));
            IBookService bookService = new BookService(bookRepositoryMock.Object);

            //Act
            bookService.RemoveBook(1);

            //Assert
            bookRepositoryMock.Verify(x => x.RemoveBook(1), Times.Once);
        }

        [Fact]
        public void SearchByCategoryTest()
        {
            //Arrange
            DigitalBook bookSample1 = new DigitalBook
            {
                Id = 1,
                CreationDate = DateTime.Now,
                Title = "Harry Potter",
                Author = "J.K. Rowling",
                Category = "Digital",
                RentalPrice = 10,
                FileFormat = "pdf",
                FileSizeMB = 50,
            };

            PrintBook bookSample2 = new PrintBook
            {
                Id = 2,
                CreationDate = DateTime.Now,
                Title = "The Shining",
                Author = "Stephen King",
                Category = "Print",
                RentalPrice = 15,
                NumberOfCopies = 3,
                ISBN = "444333222",
            };

            Mock<IBookRepository> bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(x => x.GetBooksByCategory("Digital")).Returns(new List<Book> { bookSample1 });
            bookRepositoryMock.Setup(x => x.GetBooksByCategory("Print")).Returns(new List<Book> { bookSample2 });
            IBookService bookService = new BookService(bookRepositoryMock.Object);

            //Act
            var resultBook1 = bookService.SearchByCategory("Digital");
            var resultBook2 = bookService.SearchByCategory("Print");

            //Assert
            Assert.Contains(bookSample1, resultBook1);
            Assert.Contains(bookSample2, resultBook2);
        }
    }
}