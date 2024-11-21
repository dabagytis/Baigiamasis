using Baigiamasis.Core.Contracts.IRepository;
using Baigiamasis.Core.Models;
using Baigiamasis.Core.Models.Knygos;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis.Core.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Methods

        public List<User> GetAllUsers()
        {
            List<User> allUsers = new List<User>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                allUsers = connection.Query<User>("SELECT * FROM Entities WHERE Name != ''").ToList();
            }
            return allUsers;
        }

        public User GetUserById(int id)
        {
            User userById = new User();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                userById = connection.QueryFirst<User>("SELECT * FROM Entities WHERE Id = @Id", new { Id = id });
            }
            return userById;
        }
    }
}
