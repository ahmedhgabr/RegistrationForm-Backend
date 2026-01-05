namespace RegistrationForm.Model
{
    public class User
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public required int Age { get; set; }
    }
}
