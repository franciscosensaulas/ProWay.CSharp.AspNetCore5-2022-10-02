using Service.ViewModels.Livros;

namespace Service.Services.Livros
{
    public interface ILivroService
    {
        LivroIndexViewModel Cadastrar(LivroCadastrarViewModel viewModel);
        List<LivroIndexViewModel> ObterTodos();
    }
}