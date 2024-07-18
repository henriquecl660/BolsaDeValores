using BolsaDeValores.Models;
using Microsoft.EntityFrameworkCore;

namespace BolsaDeValores.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        public DbSet<Acao> Acoes { get; set; }
        public DbSet<Acionista> Acionistas { get; set; }    
        public DbSet<Carteira> Carteiras { get; set; } 
        
        public DbSet<Corretora> Corretora { get; set; }
    }
}
