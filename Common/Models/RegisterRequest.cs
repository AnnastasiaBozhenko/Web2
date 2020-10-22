namespace Common.Models
{
    public class RegisterRequest
    {
        public RegisterRequest()
        {

        }

        public RegisterRequest(int number)
        {
            Id = $"Bozhenko_{number}";
        }
        public string Id { get; set; }
    }
}
