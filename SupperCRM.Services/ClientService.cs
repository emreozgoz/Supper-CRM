using SupperCRM.DataAccess;
using SupperCRM.DataAccess.Abstact;
using SupperCRM.Entities;
using SupperCRM.Models;
using System.Xml.Linq;

namespace SupperCRM.Services
{
    public interface IClientService
    {
        void Create(string name, string email);
        void Create(CreateCustomerModel model);
        void Delete(int id);
        List<Client> GetAll();
        Client GetById(int id);
        List<Client> ListBySearch(string keyword);
        void Update(int id, EditCustomerModel model);
    }

    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }
        public List<Client> GetAll()
        {
            return _repository.GetAll();
        }
        public void Create(string name, string email)
        {
            Client client = new Client
            {
                Name = name,
                Email = email,
                CreatedAt = DateTime.Now,
            };
            _repository.Add(client);
        }

        public void Create(CreateCustomerModel model)
        {
            Client client = new Client
            {
                Name = model.Name,
                Email = model.Email,
                Description = model.Description,
                Locked = model.Locked,
                Phone = model.Phone,
                isCorporate = model.isCorporate,
                CreatedAt = DateTime.Now,
            };
            _repository.Add(client);
        }

        public Client GetById(int id)
        {
            return _repository.Get(id);
        }

        public void Update(int id, EditCustomerModel model)
        {
            Client client = GetById(id);
            client.Name = model.Name;
            client.Email = model.Email;
            client.Description = model.Description;
            client.Phone = model.Phone;
            client.Locked = model.Locked;
            client.isCorporate = model.isCorporate;

            _repository.Update(client);

        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Client> ListBySearch(string keyword)
        {
            return _repository.GetAll(x => x.Name.Contains(keyword) || x.Email.Contains(keyword) || x.Phone.Contains(keyword) || x.Description.Contains(keyword));
        }
    }
}