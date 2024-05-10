using MusicalOcean.Core.Models;
using MusicalOcean.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicalOcean.Application.Services
{
    public class UsersService(IUsersRepository usersRepository)
        : IUsersService
    {
        private readonly IUsersRepository _usersRepository = usersRepository;

        public async Task<List<User>> GetAllUsers()
        {
            return await _usersRepository.Get();
        }

        public async Task<Guid> CreateUser(User user)
        {
            return await _usersRepository.Create(user);
        }

        public async Task<Guid> UpdateUser(Guid id, string name, string email,
            string password, DateTime createAt, DateTime updateAt)
        {
            return await _usersRepository.Update(id, name, email, password,
                createAt, updateAt);
        }

        public async Task<Guid> DeleteUser(Guid id)
        {
            return await _usersRepository.Delete(id);
        }
    }
}
