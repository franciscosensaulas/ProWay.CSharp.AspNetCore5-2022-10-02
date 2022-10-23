using Repository.Entities;

namespace Repository.Repositories.Livros
{
    public interface ILivroRepository
    {
        void Apagar(int id);
        Livro Cadastrar(Livro livro);
        void Editar(Livro livro);
        Livro? ObterPorId(int id);
        List<Livro> ObterTodos();
    }
}
