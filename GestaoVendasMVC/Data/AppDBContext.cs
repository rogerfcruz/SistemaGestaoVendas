using GestaoVendasMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoVendasMVC.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {            
        }

        public DbSet<LoginModel> Login { get; set; }
        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<VendedorModel> Vendedor { get; set; }
    }
}
