using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Email;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult ContatoAcao()
        {
            Contato c = new Contato();

            c.Nome = HttpContext.Request.Form["nome"];
            c.Email = HttpContext.Request.Form["email"];
            c.Texto = HttpContext.Request.Form["texto"];
            return new ContentResult() {Content = String.Format("Dados enviados com sucesso. <br/> Nome: {0}. <br/> E-mail: {1}. <br/> Texto: {2}",
                c.Nome, c.Email, c.Texto), ContentType = "text/html"};

            ContatoEmail.EnviarContatoPorEmail(c);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CadastroCliente()
        {
            return View();
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}
