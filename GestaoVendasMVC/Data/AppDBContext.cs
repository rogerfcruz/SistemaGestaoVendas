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
    }
}
