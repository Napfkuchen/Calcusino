using Calcusino.Data;
using System.Linq.Expressions;

namespace Calcusino.Controllers
{
    public interface IDataRepository
    {
        T FindById<T>(int id) where T : class;
        T? FindBy<T>(Expression<Func<T, bool>> predicate) where T : class;
        void Add<T>(T entity) where T : class;
    }

    public class DataRepository : IDataRepository
    {
        private readonly CalcusinoDbContext _context;

        public DataRepository(CalcusinoDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public T? FindBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var entity = _context.Set<T>().FirstOrDefault(predicate);
            return entity;
        }

        public T FindById<T>(int id) where T : class
        {
            var entity = _context.Set<T>().Find(id);
            return entity ?? throw new InvalidOperationException($"Entity of type {typeof(T)} with id {id} not found.");

        }
    }
}