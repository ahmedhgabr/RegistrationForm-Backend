using RegistrationForm.Model;

namespace RegistrationForm.Services
{
    public interface IUserService
    {
        // Create
        Task RegisterUser(User user);

        // Read
        Task<List<User>> GetUsersByEmail(string query);
        Task<List<User>> GetUsers();

        // Update
        Task<User> UpdateUser(User user);
        Task<User> UpdateUser(String email);

        // Delete
        Task DeleteUser(string email);

    }
}
