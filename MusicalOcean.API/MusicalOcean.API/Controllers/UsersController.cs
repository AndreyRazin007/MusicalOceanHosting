using Microsoft.AspNetCore.Mvc;
using MusicalOcean.Application.Services;
using MusicalOcean.API.Contracts;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;

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

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUser(
            [FromBody] UsersRequest request)
        {
            var (user, error) = Core.Models.User.Create(
                Guid.NewGuid(),
                request.Name,
                request.Email,
                request.Password,
                request.CreateAt,
                request.UpdateAt);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var userId = await _usersService.CreateUser(user);

            return Ok(userId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateUsers(Guid id,
            [FromBody] UsersRequest request)
        {
            var userId = await _usersService.UpdateUser(id,
                request.Name, request.Email, request.Password,
                request.CreateAt, request.UpdateAt);

            return Ok(userId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteUser(Guid id)
        {
            return Ok(await _usersService.DeleteUser(id));
        }
    }
}
