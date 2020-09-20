using Entities.Entities;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class ContextBase : IdentityDbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options): base(options)
        {
        }

        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConnection());
                base.OnConfiguring(optionsBuilder);
            }
        }
        
        private string GetStringConnection()
        {
            var stringConexao = "Data Source=DESKTOP-2CIR9JE\\SQLEXPRESS;Initial Catalog=Finance;Integrated Security=True";
            return stringConexao;
        }
        
    }
}
