using Repository.Database;
using Repository.Entities;

namespace Repository.Repositories.Categorias
{
    public class CategoriaRepository : ICategoriaRepository
    {
        // private -> somente na classe
        // internal -> publico porém somente dentro do mesmo projeto
        // public -> acessar de qualquer parte
        // protected -> private porém classes filhas conseguem acessar


        private readonly ProjetoContext _context;

        public CategoriaRepository(ProjetoContext context)
        {
            _context = context;
        }

        public void Apagar(int id)
        {
            var categoria = _context.Set<Categoria>().FirstOrDefault(x => x.Id == id);

            if (categoria == null)
                return;

            _context.Set<Categoria>().Remove(categoria);
            _context.SaveChanges();
        }

        public Categoria Cadastrar(Categoria categoria)
        {
            _context.Set<Categoria>().Add(categoria);
            _context.SaveChanges();

            return categoria;
        }

        public void Editar(Categoria categoria)
        {
            _context.Set<Categoria>().Update(categoria);
            _context.SaveChanges();
        }

        public Categoria? ObterPorId(int id)
        {
            var categoria = _context.Set<Categoria>().FirstOrDefault(x => x.Id == id);

            return categoria;
        }

        public List<Categoria> ObterTodos()
        {
            var categorias = _context.Set<Categoria>().ToList();

            return categorias;
        }
    }
}
