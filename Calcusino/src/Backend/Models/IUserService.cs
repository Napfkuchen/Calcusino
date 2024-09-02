namespace Calcusino.Controllers
{
    public interface IUserService
    {
        UserModel GetUserById(int id);
        void CreateUser(UserModel user);
        object CreateUser(string userName);
    }

    public class UserService : IUserService
    {
        private readonly IDataRepository _repository;

        public UserService(IDataRepository repository)
        {   
            _repository = repository;   
        }

        public UserModel GetUserById(int id)
        {
            return _repository.FindById<UserModel>(id);
        }

        public void CreateUser(UserModel user)
        {
            _repository.Add(user);
        }
                public object CreateUser(string userName)
        {
            // Prüfen, ob der Benutzername bereits existiert
            var existingUser = _repository.FindBy<UserModel>(u => u.UserName == userName);

            if (existingUser != null)
            {
                // Wenn der Benutzername bereits existiert, werfen wir eine Ausnahme
                throw new InvalidOperationException($"Ein Benutzer mit dem Benutzernamen {userName} existiert bereits.");
            }

            // Wenn der Benutzername nicht existiert, erstellen wir einen neuen Benutzer
            var newUser = new UserModel
            {
                UserName = userName,
                Password = "defaultPassword",
                Email = $"{userName}@example.com",
                Punktestand = 0,
                Spielzeit = 0,
                OnlineStatus = false
            };

            // Speichern des neuen Benutzers in der Datenbank
            _repository.Add(newUser);

            return newUser;
        }
    }
}