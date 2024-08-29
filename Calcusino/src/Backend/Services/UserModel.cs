namespace Calcusino.Controllers
{    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Punktestand { get; set; }
        public int Spielzeit { get; set; }
        public bool OnlineStatus { get; set; }
    }
}