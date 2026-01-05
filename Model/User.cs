namespace RegistrationForm.Model
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; } = null;
        public required int Age { get; set; }
    }
}
