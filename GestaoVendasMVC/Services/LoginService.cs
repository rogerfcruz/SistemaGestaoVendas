using GestaoVendasMVC.Data;
using GestaoVendasMVC.Models;
using System.Linq;

namespace GestaoVendasMVC.Services
{
    public class LoginService
    {
        private readonly AppDBContext _dbContext;

        public LoginService(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public LoginModel UserExists(LoginModel loginModel)
        {
            LoginModel resultado = _dbContext.Login.FirstOrDefault(obj => obj.Email == loginModel.Email && obj.Senha == loginModel.Senha);
            return resultado;
        }

        public void CreateUser(LoginModel loginModel)
        {
            _dbContext.Add(loginModel);
            _dbContext.SaveChanges();
        }
    }
}
