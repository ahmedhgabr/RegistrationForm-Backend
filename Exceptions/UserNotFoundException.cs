namespace RegistrationForm.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message)
        {
        }

        public UserNotFoundException(int id) 
            : base($"User with ID '{id}' not found.")
        {
        }

        public UserNotFoundException(string field, string value) 
            : base($"User with {field} '{value}' not found.")
        {
        }
    }
}
