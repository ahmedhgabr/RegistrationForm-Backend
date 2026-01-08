using Microsoft.EntityFrameworkCore;
using RegistrationForm.Data;
using RegistrationForm.Dto;
using RegistrationForm.Exceptions;
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
                throw new DuplicateEmailException(request.Email);
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
            var existingUser = await context.Users.FindAsync(request.Id);
            if (existingUser == null)
            {
                throw new UserNotFoundException(request.Id);
            }

            // Check if trying to update email to one that already exists
            if (request.UpdatedEmail != null && request.UpdatedEmail != existingUser.Email)
            {
                var emailExists = await context.Users
                    .AnyAsync(u => u.Email == request.UpdatedEmail && u.Id != request.Id);
                
                if (emailExists)
                {
                    throw new DuplicateEmailException(request.UpdatedEmail);
                }
                existingUser.Email = request.UpdatedEmail;
            }

            if (request.UpdatedName != null)
                existingUser.Name = request.UpdatedName;
            
            // Handle phone: empty string = remove, null = don't change, value = update
            if (request.UpdatedPhone != null)
            {
                existingUser.Phone = string.IsNullOrWhiteSpace(request.UpdatedPhone) 
                    ? null 
                    : request.UpdatedPhone;
            }
            
            if (request.UpdatedAge.HasValue)
                existingUser.Age = request.UpdatedAge.Value;

            if (context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
            
            return true;
        }

        // Delete
        public async Task<bool> DeleteUser(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                throw new UserNotFoundException(id);
            }
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
