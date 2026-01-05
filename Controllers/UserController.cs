using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationForm.Model;
using RegistrationForm.Services;

namespace RegistrationForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService service) : ControllerBase
    {


        [HttpGet("email/{query}")]
        public async Task<ActionResult<List<User>>> GetUsersByEmail(string query)
        {
            var users = await service.GetUsersByEmail(query);
            if (users.Count == 0)
            {
                return NotFound("No users found.");
            }
            return Ok(users);
        }

        [HttpGet("users")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await service.GetUsers());
        }

    }
}
