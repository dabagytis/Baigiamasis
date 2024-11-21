using Baigiamasis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis.Core.Contracts.IServices
{
    public interface IRentalService
    {
        List<Rental> GetAllRentals();
        void AddRental(Rental rental);
        void EndRental(int id);
        List<Rental> GetActiveRentalsByUser(int userId);
        List<Rental> GetAllRentalsByUser(int userId);
        List<User> GetAllUsersByBook(int bookId);
    }
}
