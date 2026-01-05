namespace RegistrationForm.Dto
{
    public class UpdateUserRequest
    {
        public required string Email { get; set; }
        public string? UpdatedName { get; set; }
        public string? UpdatedEmail { get; set; }
        public string? UpdatedPhone { get; set; } = null;
        public int? UpdatedAge { get; set; }
    }
}
