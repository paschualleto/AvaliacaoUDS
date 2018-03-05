using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebProjeto.DataProvider;
using WebProjeto.DataProvider.Context;
using WebProjeto.DataProvider.Models;
using WebProjeto.DataProvider.Repository;
using WebProjeto.DataProvider.Service;

namespace WebProjeto.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutoService produtoService;

        //private WebProjetoContext db = new WebProjetoContext();

        public ProdutoController()
        {
            produtoService = new ProdutoService();
        }

        // GET: ProdutoModels
        public ActionResult Produto()
        {
            return View(produtoService.ListaProdutos());
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult PersisteProduto([Bind(Include = "Id,Codigo,Nome,PrecoUnitario")] ProdutoModel produtoModel)
        {
            var retorno = produtoService.Salvar(produtoModel);

            return Json(new { Resultado = retorno }); 
        }

        public ActionResult RemoverProduto([Bind(Include = "Id,Codigo,Nome,PrecoUnitario")] ProdutoModel produtoModel)
        {
            var retorno = produtoService.Remover(produtoModel);

            return Json(retorno );
        }

        public ActionResult RecuperaProduto([Bind(Include = "Id,Codigo,Nome,PrecoUnitario")] ProdutoModel produtoModel)
        {
            return Json(produtoService.ListarPorId(produtoModel));
        }

        public ActionResult RecuperaTodosProdutos()
        {
            return Json(produtoService.ListaProdutos());
        }
    }
}
