using DevMarcos.UI.Site.Modulos.Vendas.Interfaces;
using DevMarcos.UI.Site.Modulos.Vendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevMarcos.UI.Site.Modulos.Vendas.Data
{
    public class PedidoRepository : IPedidoRepository
    {
        public Pedido ObterPedido()
        {
            return new Pedido();
        }
    }
}
