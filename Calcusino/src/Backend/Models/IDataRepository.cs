namespace Calcusino.Controllers
{
    internal interface IDataRepository
    {
        T FindById<T>(int id);
    }
}