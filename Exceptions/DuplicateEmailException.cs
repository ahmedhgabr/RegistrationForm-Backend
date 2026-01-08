namespace RegistrationForm.Exceptions
{
    public class DuplicateEmailException : Exception
    {
        public string Email { get; }

        public DuplicateEmailException(string email) 
            : base($"A user with email '{email}' already exists.")
        {
            Email = email;
        }
    }
}
