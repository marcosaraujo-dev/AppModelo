using DevMarcos.UI.Site.Modulos.Produtos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevMarcos.UI.Site.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options)
            : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
