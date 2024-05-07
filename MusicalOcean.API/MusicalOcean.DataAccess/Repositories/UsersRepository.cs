using Microsoft.EntityFrameworkCore;
using MusicalOcean.Core.Models;
using MusicalOcean.DataAccess.Entities;

namespace MusicalOcean.DataAccess.Repositories
{
    public class UsersRepository(MusicalOceanDbContext context) : IUsersRepository
    {
        private readonly MusicalOceanDbContext _context = context;

        public async Task<List<User>> Get()
        {
            var userEntities = await _context.Users
                .AsNoTracking()
                .ToListAsync();

            var users = userEntities
                .Select(user => User.Create(user.Id, user.Name, user.Email,
                    user.Password, user.CreateAt, user.UpdateAt).User)
                .ToList();

            return users;
        }

        public async Task<Guid> Create(User user)
        {
            var userEntity = new UserEntity()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                CreateAt = user.CreateAt,
                UpdateAt = user.UpdateAt
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return userEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name, string email,
            string password, DateTime createAt, DateTime updateAt)
        {
            await _context.Users
                .Where(user => user.Id == id)
                .ExecuteUpdateAsync(user => user
                    .SetProperty(user => user.Name, user => name)
                    .SetProperty(user => user.Email, user => email)
                    .SetProperty(user => user.Password, user => password)
                    .SetProperty(user => user.CreateAt, user => createAt)
                    .SetProperty(user => user.UpdateAt, user => updateAt));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Users
                .Where(user => user.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
