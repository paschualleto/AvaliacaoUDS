using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebProjeto.DataProvider.Context;
using WebProjeto.DataProvider.Models;
using WebProjeto.DataProvider.Service;

namespace WebProjeto.Controllers
{
    public class ItemPedidoController : Controller
    {
        private WebProjetoContext db = new WebProjetoContext();

        private ItemPedidoService itemPedidoService;

        public ItemPedidoController()
        {
            itemPedidoService = new ItemPedidoService();
        }

        // GET: ProdutoModels
        public ActionResult ItemPedido()
        {
            return View(itemPedidoService.ListaItemPedido());
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult PersisteItemPedido([Bind(Include = "Id,Produto,IdVenda,Quantidade,PrecoUnitario,PercDesconto,TotalItem")] ItemPedidoModel itemPedidoModel)
        {
            var retorno = itemPedidoService.Salvar(itemPedidoModel);

            return Json(new { Resultado = retorno });
        }

        public ActionResult RemoverItemPedido([Bind(Include = "Id,Produto,IdVenda,Quantidade,PrecoUnitario,PercDesconto,TotalItemo")] ItemPedidoModel itemPedidoModel)
        {
            var retorno = itemPedidoService.Remover(itemPedidoModel);

            return Json(retorno);
        }

        public ActionResult RecuperaItemPedido([Bind(Include = "Id,Produto,IdVenda,Quantidade,PrecoUnitario,PercDesconto,TotalItem")] ItemPedidoModel itemPedidoModel)
        {
            return Json(itemPedidoService.ListarPorId(itemPedidoModel));
        }
    }
}
