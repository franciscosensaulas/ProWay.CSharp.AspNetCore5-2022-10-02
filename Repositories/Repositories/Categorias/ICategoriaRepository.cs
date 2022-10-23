using Repository.Entities;

namespace Repository.Repositories.Categorias
{
    public interface ICategoriaRepository
    {
        Categoria? ObterPorId(int id);
        List<Categoria> ObterTodos();
        Categoria Cadastrar(Categoria categoria);
        void Editar(Categoria categoria);
        void Apagar(int id);
    }
}