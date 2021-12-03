using DevMarcos.UI.Site.Data;
using DevMarcos.UI.Site.Modulos.Produtos.Models;
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

        private readonly MeuDbContext _contexto;

        public CadastroController(MeuDbContext contexto)
        {
            _contexto = contexto;
        }

        [Route("lista")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Busca")]
        public IActionResult Busca()
        {
            // exemplo busca pelo ID 
            //var produto = _contexto.Produtos.Find(produto.Id);

            // Exemplo busca por uma Categoria, retorna o primeiro registro
            var produto = _contexto.Produtos.FirstOrDefault(p => p.Categoria == "Programação");

            //Busca todos os produtos de um fabricante, retona uma coleção de Produtos
            //var produtos = _contexto.Produtos.Where(a => a.Fabricante == "CodificandoNetCore");

            //Busca todos os produtos  
           // var produtos = _contexto.Produtos.ToList();

            return View();
        }

        [Route("Cadastro")]
        public IActionResult Cadastro()
        {
            var produto = new Produto
            {
                Nome       = "Livro NetCore",
                Fabricante  = "CodificandoNetCore",
                Categoria   = "Programação",
                Valor       = 59.99
            };

            // Adiciona o Produto na memória
            _contexto.Produtos.Add(produto);

            //grava os dados no banco
            _contexto.SaveChanges(); // SaveChanges retorna o número de linhas afetadas

            // Exemplo atualiza um produto
            /*
            produto.Valor = 70.00;
            _contexto.Produtos.Update(produto);
            _contexto.SaveChanges();
            */


            // exemplo Deleta um registro
            /*
            _contexto.Produtos.Remove(produto);
            _contexto.SaveChanges();
            */

            return View();
        }
    }
}
