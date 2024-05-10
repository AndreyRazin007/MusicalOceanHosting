using System;

namespace MusicalOcean.Core.Models
{
    public sealed class User
    {
        public Guid Id { get; }

        public string Name { get; } = string.Empty;

        public string Email { get; } = string.Empty;

        public string Password { get; } = string.Empty;

        public DateTime CreateAt { get; } = DateTime.UtcNow;

        public DateTime UpdateAt { get; } = DateTime.UtcNow;

        private User(Guid id, string name, string email, string password,
            DateTime createAt, DateTime updateAt)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            CreateAt = createAt;
            UpdateAt = updateAt;
        }

        public static (User User, string Error) Create(Guid id, string name,
            string email, string password, DateTime createAt, DateTime updateAt)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name))
            {
                error = "Имя не может быть пустым";
            }

            var user = new User(id, name, email, password, createAt, updateAt);

            return (user, error);
        }
    }
}
