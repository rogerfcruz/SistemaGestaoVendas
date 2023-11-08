using GestaoVendasMVC.Data;
using GestaoVendasMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace GestaoVendasMVC.Services
{
    public class VendedorService
    {
        private readonly AppDBContext _dbContext;

        public VendedorService(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public List<VendedorModel> FindAll()
        {
            return _dbContext.Vendedor.ToList();
        }

        public VendedorModel FindById(int id)
        {
            return _dbContext.Vendedor.FirstOrDefault(x => x.Id == id);
        }

        public void Create(VendedorModel obj)
        {
            _dbContext.Add(obj);
            _dbContext.SaveChanges();
        }

        public void Edit(VendedorModel obj)
        {
            if(_dbContext.Vendedor.Any(x => x.Id == obj.Id))
            {
                _dbContext.Update(obj);
                _dbContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var obj = _dbContext.Vendedor.Find(id);
            if (obj != null)
            {
                _dbContext.Remove(obj);
                _dbContext.SaveChanges();
            }
        }
    }
}