namespace Calcusino.Controllers
{    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Punktestand { get; set; }
        public int Spielzeit { get; set; }
        public bool OnlineStatus { get; set; }
    }
}