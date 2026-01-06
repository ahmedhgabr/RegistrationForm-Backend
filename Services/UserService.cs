using Microsoft.EntityFrameworkCore;
using RegistrationForm.Data;
using RegistrationForm.Dto;
using RegistrationForm.Model;

namespace RegistrationForm.Services
{
    public class UserService(AppDBContext context) : IUserService
    {
        // Create
        public async Task<bool> RegisterUser(CreateUserRequest request)
        {
            var emailExists = await context.Users.AnyAsync(u => u.Email == request.Email);

            if (emailExists)
            {
                throw new InvalidOperationException($"A user with email '{request.Email}' already exists.");
            }
            var newUser = new User
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Age = request.Age
            };
            context.Users.Add(newUser);
            await context.SaveChangesAsync();
            return true;
        }

        // Read
        public async Task<List<User>> GetUsersByEmail(string query)
        {
            var users = await context.Users
                .Where(u => u.Email.Contains(query))
                .ToListAsync();
            return users;
        }

        public async Task<List<User>> GetUsers()
            => await context.Users.ToListAsync();

        // Update
        public async Task<bool> UpdateUser(UpdateUserRequest request)
        {
            var existingUser = await context.Users.SingleOrDefaultAsync(u => u.Email == request.Email);
            if (existingUser == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            existingUser.Name = request.UpdatedName ?? existingUser.Name;
            existingUser.Email = request.UpdatedEmail ?? existingUser.Email;
            existingUser.Phone = request.UpdatedPhone ?? existingUser.Phone;
            existingUser.Age = request.UpdatedAge ?? existingUser.Age;
            await context.SaveChangesAsync();
            return true;
        }

        // Delete
        public async Task<bool> DeleteUser(string email)
        {
            var user = await context.Users.SingleOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
