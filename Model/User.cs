using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RegistrationForm.Model
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$")]
        [StringLength(100, MinimumLength = 2)]
        public required string Name { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        [MaxLength(150)]
        public required string Email { get; set; } // unique index

        [Phone]
        [RegularExpression(@"^\d{11}$")]
        public string? Phone { get; set; } = null;

        [Required]
        [Range(0, 100)]
        public required int Age { get; set; }
    }
}
