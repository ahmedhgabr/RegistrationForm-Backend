using RegistrationForm.Model;

namespace RegistrationForm.Services
{
    public class UserService : IUserService
    {
        public Task RegisterUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsersByEmail(string query)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }


        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(string email)
        {
            throw new NotImplementedException();
        }
        public Task DeleteUser(string email)
        {
            throw new NotImplementedException();
        }
    }
}
