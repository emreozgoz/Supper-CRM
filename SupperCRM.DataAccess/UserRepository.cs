using SupperCRM.DataAccess.Abstact;
using SupperCRM.DataAccess.Context;
using SupperCRM.Entities;

namespace SupperCRM.DataAccess
{
    public interface IUserRepository : IRepository<User>
    {
    }
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DatabaseContext _dbContext;
        public UserRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}