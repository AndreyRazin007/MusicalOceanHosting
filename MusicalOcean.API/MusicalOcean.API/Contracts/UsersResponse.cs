namespace MusicalOcean.API.Contracts
{
    public record UsersResponse(
        Guid Id,
        string Name,
        string Email,
        string Password,
        DateTime CreateAt,
        DateTime UpdateAt);
}
