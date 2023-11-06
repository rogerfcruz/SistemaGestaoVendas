using GestaoVendasMVC.Data;
using GestaoVendasMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace GestaoVendasMVC.Services
{
    public class ClienteService
    {
        private readonly AppDBContext _dbContext;

        public ClienteService(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public List<ClienteModel> FindAll()
        {
            return _dbContext.Cliente.ToList();
        }

        public ClienteModel FindById(int id)
        {
            return _dbContext.Cliente.FirstOrDefault(x => x.Id == id);
        }

        public void Create(ClienteModel cliente)
        {
            _dbContext.Add(cliente);
            _dbContext.SaveChanges();
        }

        public void Edit(ClienteModel cliente)
        {
            if(_dbContext.Cliente.Any(x => x.Id == cliente.Id))
            {
                _dbContext.Update(cliente);
                _dbContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var obj = _dbContext.Cliente.Find(id);
            if (obj != null)
            {
                _dbContext.Remove(obj);
                _dbContext.SaveChanges();
            }
        }
    }
}