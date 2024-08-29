using Microsoft.AspNetCore.Mvc;

namespace Calcusino.Controllers
{
    internal interface IDataRepository
    {
        T FindById<T>(int id);
        object Add<T>(T entity);
    }
}