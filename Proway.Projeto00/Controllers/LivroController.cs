using Microsoft.AspNetCore.Mvc;
using Service.Services.Livros;

namespace Proway.Projeto00.Controllers
{
    [Route("livros")]
    public class LivroController : Controller
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var livros = _livroService.ObterTodos();

            return View(livros);
        }
    }
}
