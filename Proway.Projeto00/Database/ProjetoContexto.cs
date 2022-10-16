using Microsoft.EntityFrameworkCore;
using Proway.Projeto00.Mapeamento;

namespace Proway.Projeto00.Database
{
    public class ProjetoContext : DbContext
    {
        public ProjetoContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Registrar os mapeamentos das tabelas com suas colunas
            // e propriedades da entidade
            modelBuilder.ApplyConfiguration(new CategoriaMapeamento());
        }
    }
}
// DbFirst
// CodeFirst