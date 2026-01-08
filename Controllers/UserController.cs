using Microsoft.AspNetCore.Mvc;
using RegistrationForm.Dto;
using RegistrationForm.Exceptions;
using RegistrationForm.Model;
using RegistrationForm.Services;

namespace RegistrationForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService service) : ControllerBase
    {

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] CreateUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await service.RegisterUser(request);
                return NoContent();
            }
            catch (DuplicateEmailException ex)
            {
                return Conflict(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while registering the user", Error = ex.Message });
            }
        }

        [HttpGet("email/{query}")]
        public async Task<ActionResult<List<User>>> GetUsersByEmail(string query)
        {
            var users = await service.GetUsersByEmail(query);
            if (users.Count == 0)
            {
                return NotFound(new { Message = "No users found." });
            }
            return Ok(users);
        }

        [HttpGet("users")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await service.GetUsers());
        }

        [HttpPut("update/")]
        public async Task<ActionResult> UpdateUser(UpdateUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await service.UpdateUser(request);
                return NoContent();
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (DuplicateEmailException ex)
            {
                return Conflict(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while updating the user", Error = ex.Message });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                await service.DeleteUser(id);
                return NoContent();
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting the user", Error = ex.Message });
            }
        }
    }
}
