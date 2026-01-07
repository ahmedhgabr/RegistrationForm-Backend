using System.ComponentModel.DataAnnotations;

namespace RegistrationForm.Dto
{
    public class UpdateUserRequest
    {
        public required int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name cannot contain numbers or special characters")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string? UpdatedName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        public string? UpdatedEmail { get; set; }
        
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone must be exactly 11 digits")]
        public string? UpdatedPhone { get; set; } = null;

        [Range(0, 100, ErrorMessage = "Age must be between 0 and 100")]
        public int? UpdatedAge { get; set; }
    }
}
