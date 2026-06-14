using Microsoft.EntityFrameworkCore;
using GerenciadorCartoes.Models;

namespace GerenciadorCartoes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Isso diz ao EF para criar uma tabela chamada "Cartoes" baseada na nossa Model
        public DbSet<Cartao> Cartoes { get; set; }
    }
}