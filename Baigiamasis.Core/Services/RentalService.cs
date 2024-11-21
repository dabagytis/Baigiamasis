using Baigiamasis.Core.Contracts.IRepository;
using Baigiamasis.Core.Contracts.IServices;
using Baigiamasis.Core.Models;
using Baigiamasis.Core.Models.Knygos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis.Core.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        public RentalService(IRentalRepository rentalRepository, IUserRepository userRepository, IBookRepository bookRepository)
        {
            _rentalRepository = rentalRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        // Method

        public void AddRental(Rental rental) // reikia taisyti, pamirsau NumberOfCopies kintamaji ir punkta atlikau klaidingai
        {
            Book targetBook = _bookRepository.GetBookById(rental.BookId);
            List<Rental> allActiveRentals = _rentalRepository.GetAllActiveRentals();
            bool bookTaken = false;
            
            if(rental.RentStart < rental.RentEnd)
            {
                if (targetBook is PrintBook)
                {
                    foreach (Rental a in allActiveRentals)
                    {
                        if (a.BookId == targetBook.Id)
                        {
                            bookTaken = true;
                        }
                    }
                    if (bookTaken == false)
                    {
                        _rentalRepository.AddRental(rental);
                    }

                }
                else
                {
                    _rentalRepository.AddRental(rental);
                }
            }
        }

        public void EndRental(int id)
        {
            Rental targetRental = _rentalRepository.GetRentalById(id);
            if(targetRental.RentEnd > DateTime.Now)
            {
                _rentalRepository.EndRental(id);
            }
        }

        public List<Rental> GetActiveRentalsByUser(int userId) // Uzduotyje parasyta gauti viena Nuomos Irasa, taciau atsizvelgiant kad klientas gali tureti kelis, darau su List
        {
            List<Rental> activeRentalsByUser = new List<Rental>();
            List<Rental> allActiveRentals = _rentalRepository.GetAllActiveRentals();
            foreach(Rental a in allActiveRentals)
            {
                if(a.UserId == userId)
                {
                    activeRentalsByUser.Add(a);
                }
            }
            return activeRentalsByUser;
        }

        public List<Rental> GetAllRentals()
        {
            return _rentalRepository.GetAllRentals();
        }

        public List<Rental> GetAllRentalsByUser(int userId)
        {
            return _rentalRepository.GetAllRentalsByUser(userId);
        }

        public List<User> GetAllUsersByBook(int bookId)
        {
            List<User> usersByBook = new List<User>();
            List<User> allUsers = _userRepository.GetAllUsers();
            List<Rental> rentalsByBook = _rentalRepository.GetAllRentalsByBook(bookId);
            foreach(User a in allUsers)
            {
                foreach(Rental b in rentalsByBook)
                {
                    if (a.Id == b.UserId)
                    {
                        usersByBook.Add(a);
                    }
                }
            }
            return usersByBook;
        }
    }
}
