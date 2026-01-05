using RegistrationForm.Dto;
using RegistrationForm.Model;

namespace RegistrationForm.Services
{
    public interface IUserService
    {
        // Create
        Task<bool> RegisterUser(CreateUserRequest request);

        // Read
        Task<List<User>> GetUsersByEmail(string query);
        Task<List<User>> GetUsers();

        // Update
        Task<bool> UpdateUser(UpdateUserRequest request);

        // Delete
        Task<bool> DeleteUser(string email);

    }
}
