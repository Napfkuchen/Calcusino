namespace Calcusino.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Punktestand { get; set; }
        public int Spielzeit { get; set; }
        public bool OnlineStatus { get; set; }
    }
}