using Baigiamasis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis.Core.Contracts.IRepository
{
    public interface IRentalRepository
    {
        List<Rental> GetAllRentals();
        List<Rental> GetAllActiveRentals();
        void EndRental(int id);
        Rental GetRentalById(int id);
        void AddRental(Rental rental);
        void RemoveRental(int id);
        List<Rental> GetAllRentalsByUser(int userId);
        List<Rental> GetAllRentalsByBook(int bookId);
    }
}
