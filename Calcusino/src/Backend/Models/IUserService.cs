using Microsoft.AspNetCore.Mvc;

namespace Calcusino.Controllers
{
    public interface IUserService
    {
        UserModel GetUserById(int id);
        void CreateUser(UserModel user);
        object CreateUser(string userName);
        // Weitere methoden wie UpdateUser, DeleteUser...
    }

    public class UserService : IUserService
    {
        private readonly IDataRepository _repository;

        private UserService(IDataRepository repository)
        {   
            _repository = repository;   
        }

        public UserModel GetUserById(int id)
        {   
            return _repository.FindById<UserModel>(id); 
        }

        public void CreateUser(UserModel user)
        {   
            object value = _repository.Add(user);
            // Weitere Logik wie Validierungen, Event-Triggering...
        }

        internal object CreateUser(string userName)
        {
            throw new NotImplementedException();
        }

        object IUserService.CreateUser(string userName)
        {
            throw new NotImplementedException();
        }

        // Weitere methoden wie UpdateUser, DeleteUser...
    }
}