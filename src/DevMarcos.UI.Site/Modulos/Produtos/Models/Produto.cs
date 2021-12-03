using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevMarcos.UI.Site.Modulos.Produtos.Models
{
    public class Produto
    {
        public Produto()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Nome { get; set; }
        public string Fabricante { get; set; }

        public string Categoria { get; set; }

        public double Valor { get; set; }
    }
}
