using Repository.Entities;
using Repository.Repositories.Livros;
using Service.ViewModels.Livros;

namespace Service.Services.Livros
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public LivroIndexViewModel Cadastrar(LivroCadastrarViewModel viewModel)
        {
            var livro = ConstruirLivro(viewModel);

            _livroRepository.Cadastrar(livro);

            return ConstruirLivroIndexViewModel(livro);
        }

        public List<LivroIndexViewModel> ObterTodos()
        {
            var livros = _livroRepository.ObterTodos();

            return livros
                .Select(x => new LivroIndexViewModel
                {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    Preco = x.Preco,
                    Categoria = x.Categoria.Nome
                })
                .ToList();
        }

        private LivroIndexViewModel ConstruirLivroIndexViewModel(Livro livro)
        {
            return new LivroIndexViewModel
            {
                Categoria = livro.Categoria.Nome,
                Titulo = livro.Titulo,
                Preco = livro.Preco,
                Id = livro.Id
            };
        }

        private Livro ConstruirLivro(LivroCadastrarViewModel viewModel)
        {
            return new Livro
            {
                CategoriaId = viewModel.CategoriaId.GetValueOrDefault(),
                Titulo = viewModel.Titulo,
                Isbn = viewModel.Isbn,
                Preco = viewModel.Preco.GetValueOrDefault(),
                QuantidadePaginas = viewModel.QuantidadePaginas.GetValueOrDefault(),
            };
        }
    }
}
