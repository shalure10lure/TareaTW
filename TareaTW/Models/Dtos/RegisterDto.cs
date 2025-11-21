namespace TareaTW.Models.Dtos
{
    public class RegisterDto
    {
        public string Username { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string Role { get; set; } = "User";
    }
}
