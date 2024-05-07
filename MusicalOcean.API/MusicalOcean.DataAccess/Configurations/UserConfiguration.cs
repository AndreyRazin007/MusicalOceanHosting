using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicalOcean.DataAccess.Entities;

namespace MusicalOcean.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        private const int MAX_LENGTH_NAME = 20;

        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Name)
                .HasMaxLength(MAX_LENGTH_NAME)
                .IsRequired();

            builder.Property(user => user.Email)
                .IsRequired();

            builder.Property(user => user.Password)
                .IsRequired();

            builder.Property(user => user.CreateAt)
                .IsRequired();

            builder.Property(user => user.UpdateAt)
                .IsRequired();
        }
    }
}
