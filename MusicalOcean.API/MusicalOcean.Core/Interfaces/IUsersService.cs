using MusicalOcean.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicalOcean.Application.Services
{
    public interface IUsersService
    {
        Task<Guid> CreateUser(User user);
        Task<Guid> DeleteUser(Guid id);
        Task<List<User>> GetAllUsers();
        Task<Guid> UpdateUser(Guid id, string name, string email, string password, DateTime createAt, DateTime updateAt);
    }
}