using MusicalOcean.Core.Models;

namespace MusicalOcean.DataAccess.Repositories
{
    public interface IUsersRepository
    {
        Task<Guid> Create(User user);
        Task<Guid> Delete(Guid id);
        Task<List<User>> Get();
        Task<Guid> Update(Guid id, string name, string email, string password, DateTime createAt, DateTime updateAt);
    }
}