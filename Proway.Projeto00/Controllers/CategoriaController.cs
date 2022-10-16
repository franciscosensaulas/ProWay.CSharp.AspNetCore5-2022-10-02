using Microsoft.AspNetCore.Mvc;
using Proway.Projeto00.Database;
using Proway.Projeto00.Entities;
using Proway.Projeto00.Models.Categorias;

namespace Proway.Projeto00.Controllers
{
    [Route("categorias")]
    public class CategoriaController : Controller
    {
        private readonly ProjetoContext _projetoContext;

        public CategoriaController(ProjetoContext projetoContext)
        {
            _projetoContext = projetoContext;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            // Select no banco de dados buscando
            // da tabela de categorias todos os registros
            var categorias = _projetoContext.Set<Categoria>().ToList();


            return View("Index", categorias);
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            var categoriaCadastrarViewModel = new CategoriaCadastrarViewModel();

            return View(categoriaCadastrarViewModel);
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(CategoriaCadastrarViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            // Persistir a categoria na tabela de categorias
            var categoria = new Categoria
            {
                Nome = viewModel.Nome.Trim()
            };

            _projetoContext.Set<Categoria>().Add(categoria);
            _projetoContext.SaveChanges();

            return RedirectToAction("ObterTodos");
        }

        [HttpGet("apagar/{id}")]
        public IActionResult Apagar(int id)
        {
            var categoria = _projetoContext
                .Set<Categoria>()
                .Where(x => x.Id == id)
                .FirstOrDefault();
            
            if(categoria != null)
            {
                _projetoContext.Set<Categoria>().Remove(categoria);
                _projetoContext.SaveChanges();
            }

            return RedirectToAction("ObterTodos");
        }

        [HttpGet("editar/{id}")]
        public IActionResult Editar(int id)
        {
            var categoriaExistente = _projetoContext
                .Set<Categoria>()
                .FirstOrDefault(x => x.Id == id);

            if(categoriaExistente == null)
            {
                return RedirectToAction("ObterTodos");
            }

            var categoriaEditarViewModel = new CategoriaEditarViewModel
            {
                Id = id,
                Nome = categoriaExistente.Nome
            };

            return View(categoriaEditarViewModel);
        }

        [HttpPost("editar/{id}")]
        public IActionResult Editar(int id, CategoriaEditarViewModel categoriaEditarViewModel)
        {
            var categoriaExistente = _projetoContext
                .Set<Categoria>()
                .FirstOrDefault(x => x.Id == id);

            if (categoriaExistente == null)
                return RedirectToAction("ObterTodos");

            categoriaExistente.Nome = categoriaEditarViewModel.Nome.Trim();

            _projetoContext.Set<Categoria>().Update(categoriaExistente);
            _projetoContext.SaveChanges();

            return RedirectToAction("ObterTodos");
        }
    }
}
