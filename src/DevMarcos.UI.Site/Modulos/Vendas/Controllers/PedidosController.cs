using DevMarcos.UI.Site.Modulos.Vendas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevMarcos.UI.Site.Modulos.Vendas.Controllers
{
    [Area("Vendas")]
    [Route("vendas")]
    public class PedidosController : Controller
    {

        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public IActionResult Index()
        {
            var pedido = _pedidoRepository.ObterPedido();
            return View();
        }
        


    }
}
