using Microsoft.EntityFrameworkCore;
using SupperCRM.DataAccess.Context;
using SupperCRM.Entities.Abstract;
using System.Linq.Expressions;

namespace SupperCRM.DataAccess.Abstact
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly DatabaseContext _dbContext;
        private readonly DbSet<TEntity> _set;
        public Repository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _set = _dbContext.Set<TEntity>();
        }
        public List<TEntity> GetAll()
        {
            return _set.ToList();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity,bool>> expression)
        {
            return _set.Where(expression).ToList();
        }
        public TEntity Get(int id)
        {
            return _set.Find(id);
        }
        public TEntity Add(TEntity model)
        {
            _set.Add(model);
            if (_dbContext.SaveChanges() > 0)
                return model;

            return null;
        }

        public void Update(TEntity model)
        {
            if (model.Id == 0)
                throw new ArgumentNullException(nameof(model.Id));

            var entity = _dbContext.Entry(model);
            entity.State = EntityState.Modified;
            if (_dbContext.SaveChanges() == 0)
                throw new Exception("Güncellme Yapılamadı");

        }

        public void Delete(int id)
        {
            _set.Remove(Get(id));
            if (_dbContext.SaveChanges() == 0)
                throw new Exception("Silme İşlemi Yapılamadı");
        }

    }
}