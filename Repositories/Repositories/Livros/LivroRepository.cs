using Microsoft.EntityFrameworkCore;
using Repository.Database;
using Repository.Entities;

namespace Repository.Repositories.Livros
{
    public class LivroRepository : ILivroRepository
    {
        private readonly ProjetoContext _context;
        private readonly DbSet<Livro> _dbSet;

        public LivroRepository(ProjetoContext context)
        {
            _context = context;
            _dbSet = _context.Set<Livro>();
        }

        public void Apagar(int id)
        {
            var livro = _dbSet.FirstOrDefault(x => x.Id == id);

            if (livro == null)
                return;

            _dbSet.Remove(livro);
            _context.SaveChanges();
        }

        public Livro Cadastrar(Livro livro)
        {
            _dbSet.Add(livro);
            _context.SaveChanges();

            return livro;
        }

        public void Editar(Livro livro)
        {
            _dbSet.Update(livro);
            _context.SaveChanges();
        }

        public Livro? ObterPorId(int id)
        {
            var livro = _dbSet.FirstOrDefault(x => x.Id == id);

            return livro;
        }

        public List<Livro> ObterTodos()
        {
            var livros = _dbSet
                .Include(x => x.Categoria)
                .ToList();

            return livros;
        }
    }
}
