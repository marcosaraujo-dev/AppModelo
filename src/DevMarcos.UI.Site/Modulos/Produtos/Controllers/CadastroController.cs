using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevMarcos.UI.Site.Modulos.Produtos.Controllers
{
    [Area("Produtos")]
    [Route("produtos")]
    public class CadastroController : Controller
    {
        [Route("lista")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Busca")]
        public IActionResult Busca()
        {
            return View();
        }
    }
}
