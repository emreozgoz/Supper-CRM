using SupperCRM.DataAccess.Abstact;
using SupperCRM.DataAccess.Context;
using SupperCRM.Entities;

namespace SupperCRM.DataAccess
{
    public interface IClientRepository : IRepository<Client>
    {
    }
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly DatabaseContext _dbContext;
        public ClientRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}