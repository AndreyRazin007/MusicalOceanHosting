using Microsoft.EntityFrameworkCore;
using MusicalOcean.DataAccess.Entities;

namespace MusicalOcean.DataAccess
{
    public class MusicalOceanDbContext(DbContextOptions<MusicalOceanDbContext> options)
        : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }
    }
}
