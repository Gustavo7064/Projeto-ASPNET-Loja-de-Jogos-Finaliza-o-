//IMPORTA AS BIBLIOTECAS QUE SERÃO UTILIZADAS NO PROJETO
using Microsoft.AspNetCore.Mvc;
using ProjetoLoja2dsA.Repositorio;
using ProjetoLoja2dsA.Models;
using Org.BouncyCastle.Tls;





namespace ProjetoLoja2dsA.Controllers
{

    public class UsuarioController : Controller
    {

        private readonly UsuarioRepositorio _usuarioRepositorio;

    
        public UsuarioController(UsuarioRepositorio usuarioRepositorio)
        {
            
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        
        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Nome, string email, string senha)
        {
            var usuario = _usuarioRepositorio.ObterUsuario(email);

            if (usuario != null && usuario.Senha == senha)
            {

                
                HttpContext.Session.SetInt32("UsuarioId", usuario.Id);

                
                HttpContext.Session.SetString("EmailUsuario", usuario.Email);
               

                HttpContext.Session.SetString("NomeUsuario", usuario.Nome);

                
                HttpContext.Session.SetString("UserRole", usuario.Role ?? "Cliente");
                
                string foto = "/pastafotos/avatar-default.png";

                
                HttpContext.Session.SetString("AvatarUrl", foto);

                return RedirectToAction("Index", "Home");


            }

            
            ModelState.AddModelError("", "Email / senha Inválidos");


            
            return View();
        }


            
            public IActionResult Index()
        {
            return View();
        }

        

        public IActionResult Cadastro()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepositorio.AdicionarUsuario(usuario);
                return RedirectToAction("Login");
            }
            return View(usuario);

        }

        
        [HttpGet]
        public IActionResult Editar()
        {
            
            var id = HttpContext.Session.GetInt32("UsuarioId");
            if (id == null)
                return RedirectToAction("Login");

            
            var usuario = _usuarioRepositorio.ObterPorId(id.Value);
            if (usuario == null)
                return NotFound();

            return View(usuario);
        }


        
        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepositorio.AtualizarUsuario(usuario);

                
                HttpContext.Session.SetString("NomeUsuario", usuario.Nome);
                HttpContext.Session.SetString("EmailUsuario", usuario.Email);

                TempData["MensagemSucesso"] = "Informações atualizadas com sucesso!";
                return RedirectToAction("Perfil");
            }

            TempData["MensagemErro"] = "Erro ao salvar alterações.";
            return View(usuario);
        }


        [HttpPost]
        public IActionResult Logout()
        {
            
            HttpContext.Session.Clear();

           
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Perfil()
        {
           
            var nome = HttpContext.Session.GetString("NomeUsuario");
            var email = HttpContext.Session.GetString("EmailUsuario");
            var foto = HttpContext.Session.GetString("AvatarUrl") ?? "/pastafotos/avatar-default.png";

           
            if (string.IsNullOrEmpty(nome))
            {
                return RedirectToAction("Login");
            }

          
            ViewBag.Nome = nome;
            ViewBag.Email = email;
            ViewBag.Foto = foto;
            return View();

        }


      
        [HttpGet]
        public IActionResult ListaUsuarios()
        {
            var usuarios = _usuarioRepositorio.ListarTodos();
            return View(usuarios);
        }


    }
}
