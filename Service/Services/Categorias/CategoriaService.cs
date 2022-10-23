using Repository.Entities;
using Repository.Repositories.Categorias;
using Service.ViewModels.Categorias;

namespace Service.Services.Categorias
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public void Alterar(CategoriaEditarViewModel viewModel)
        {
            var categoria = _categoriaRepository.ObterPorId(viewModel.Id);

            if (categoria == null)
                return;

            categoria.Nome = viewModel.Nome.Trim();

            _categoriaRepository.Editar(categoria);
        }

        public void Apagar(int id)
        {
            _categoriaRepository.Apagar(id);
        }

        public CategoriaIndexViewModel Cadastrar(CategoriaCadastrarViewModel viewModel)
        {
            var categoria = new Categoria
            {
                Nome = viewModel.Nome.Trim()
            };

            _categoriaRepository.Cadastrar(categoria);

            var categoriaIndexViewModel = new CategoriaIndexViewModel()
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            };

            return categoriaIndexViewModel;
        }

        public CategoriaIndexViewModel? ObterPorId(int id)
        {
            var categoria = _categoriaRepository.ObterPorId(id);

            return new CategoriaIndexViewModel
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            };
        }

        public List<CategoriaIndexViewModel> ObterTodos()
        {
            var categorias = _categoriaRepository.ObterTodos();

            var categoriaIndexViewModels = categorias
                .Select(x => new CategoriaIndexViewModel
                {
                    Id = x.Id,
                    Nome = x.Nome
                })
                .ToList();

            return categoriaIndexViewModels;
        }
    }
}
