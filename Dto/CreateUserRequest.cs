using System.ComponentModel.DataAnnotations;

namespace RegistrationForm.Dto
{
    public class CreateUserRequest
    {
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name cannot contain numbers or special characters")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        public required string Email { get; set; }

        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone must be exactly 11 digits")]
        public string? Phone { get; set; } = null;

        [Required(ErrorMessage = "Age is required")]
        [Range(0, 100, ErrorMessage = "Age must be between 0 and 100")]
        public required int Age { get; set; }
    }
}
