using Microsoft.AspNetCore.Mvc;
using MusicalOcean.Application.Services;
using MusicalOcean.API.Contracts;

namespace MusicalOcean.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController(IUsersService usersService) : ControllerBase
    {
        private readonly IUsersService _usersService = usersService;

        [HttpGet]
        public async Task<ActionResult<List<UsersResponse>>> GetUsers()
        {
            var users = await _usersService.GetAllUsers();

            var response = users.Select(user => new UsersResponse(user.Id,
                user.Name, user.Email, user.Password,
                user.CreateAt, user.UpdateAt));

            return Ok(response);
        }
    }
}
