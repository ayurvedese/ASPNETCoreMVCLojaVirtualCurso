using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class ProdutoController : Controller
    {
        //Lembrando que o nome do método é exatamente o nome que vai ter na URL e que fará parte do controller e tem haver com a chamada com o respectivo link da aplicação
        //Neste caso inicialmente para acessar e ver este conteúdo eu colocaria: https://localhost:44324/Produto/Visualizar
        
        /*
         *Todo controller precisa de um ActionResult e de um IActionResult
         */
        public ActionResult Visualizar()
        {
            Produto prod = GetProduto();
            
            return View(prod);
            //return new ContentResult(){ Content = "<h3>Produto -> Visualizar</h3>", ContentType = "text/html"};
        }

        private Produto GetProduto()
        {
            return new Produto()
            {
                id = 1,
                nome = "Xbox",
                descricao = "Melhor console",
                valor = 1630.25M

            };
        }
    }
}
