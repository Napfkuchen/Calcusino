namespace Calcusino.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Punktestand { get; set; }
        public int Spielzeit { get; set; }
        public bool OnlineStatus { get; set; }
    }
}