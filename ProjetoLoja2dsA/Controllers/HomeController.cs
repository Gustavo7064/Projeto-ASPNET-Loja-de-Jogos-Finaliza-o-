using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjetoLoja2dsA.Models;

namespace ProjetoLoja2dsA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Carrinho()
        {
            return View(); // Vai procurar Views/Home/Carrinho.cshtml
        }

        public IActionResult AdicionarCarrinho(int idJogo)
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");

            if (usuarioId == null)
            {
                // não logado → manda para login
                return RedirectToAction("Login", "Usuario");
            }

            // TODO: lógica de adicionar no carrinho usando usuarioId e idJogo

            return RedirectToAction("Carrinho");
        }

        public class ProdutoController : Controller
{
    public IActionResult Jogos()
    {
        return View();
    }
}




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
