using SupperCRM.Entities.Abstract;
using System.Linq.Expressions;

namespace SupperCRM.DataAccess.Abstact
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        TEntity Add(TEntity client);
        void Delete(int id);
        TEntity Get(int id);
        List<TEntity> GetAll();
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> expression);
        void Update(TEntity model);
    }
}