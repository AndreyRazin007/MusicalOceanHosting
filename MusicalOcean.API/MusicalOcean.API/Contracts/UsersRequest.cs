using System;

namespace MusicalOcean.API.Contracts
{
    public record UsersRequest(
        string Name,
        string Email,
        string Password,
        DateTime CreateAt,
        DateTime UpdateAt);
}
