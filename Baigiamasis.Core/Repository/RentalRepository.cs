using Baigiamasis.Core.Contracts.IRepository;
using Baigiamasis.Core.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis.Core.Repository
{
    public class RentalRepository : IRentalRepository
    {
        private readonly string _connectionString;
        public RentalRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Methods

        public void AddRental(Rental rental)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute("INSERT INTO Entities (CreationDate, BookId, UserId, RentStart, RentEnd) VALUES (@CreationDate, @BookId, @UserId, @RentStart, @RentEnd)", rental);
            }
        }
        public void EndRental(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.QueryFirst<Rental>("UPDATE Entities SET RentEnd = GETDATE() WHERE Id = @Id", new { Id = id });
            }
        }

        public Rental GetRentalById(int id)
        {
            Rental rentalById = new Rental();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                rentalById = connection.QueryFirst<Rental>("SELECT * FROM Entities WHERE Id = @Id", new { Id = id });
            }
            return rentalById;
        }

        public List<Rental> GetAllRentals()
        {
            List<Rental> allRentals = new List<Rental>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                allRentals = connection.Query<Rental>("SELECT * FROM Entities WHERE RentStart != ''").ToList();
            }
            return allRentals;
        }

        public List<Rental> GetAllActiveRentals()
        {
            List<Rental> allActiveRentals = new List<Rental>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                allActiveRentals = connection.Query<Rental>("SELECT * FROM Entities WHERE RentStart < GETDATE() AND RentEnd > GETDATE()").ToList();
            }
            return allActiveRentals;
        }

        public void RemoveRental(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute("DELETE FROM Entities WHERE Id = @id", new { id });
            }
        }

        public List<Rental> GetAllRentalsByUser(int userId)
        {
            List<Rental> rentalsByUser = new List<Rental>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                rentalsByUser = connection.Query<Rental>("SELECT * FROM Entities WHERE UserId = UserId", new { UserId = userId}).ToList();
            }
            return rentalsByUser;
        }

        public List<Rental> GetAllRentalsByBook(int bookId)
        {
            List<Rental> rentalsByBook = new List<Rental>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                rentalsByBook = connection.Query<Rental>("SELECT * FROM Entities WHERE BookId = BookId", new { BookId = bookId }).ToList();
            }
            return rentalsByBook;
        }
    }
}
