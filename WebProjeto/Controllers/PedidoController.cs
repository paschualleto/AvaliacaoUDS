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
    public class PedidoController : Controller
    {
        private WebProjetoContext db = new WebProjetoContext();

        private PedidoService pedidoService;

        public PedidoController()
        {
            pedidoService = new PedidoService();
        }

        // GET: ProdutoModels
        public ActionResult Pedido()
        {
            return View(pedidoService.ListaPedido());
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult PersistePedido([Bind(Include = "Id,Pessoa,Numero,DataVenda,TotalVenda")] PedidoModel pedidoModel)
        {
            var retorno = pedidoService.Salvar(pedidoModel);

            return Json(new { Resultado = retorno });
        }

        public ActionResult ExcluirPedido([Bind(Include = "Id,Pessoa,Numero,DataVenda,TotalVenda")] PedidoModel pedidoModel)
        {
            var retorno = pedidoService.Remover(pedidoModel);

            return Json(retorno);
        }

        public ActionResult RecuperaPedido([Bind(Include = "Id,Pessoa,Numero,DataVenda,TotalVenda")] PedidoModel pedidoModel)
        {
            return Json(pedidoService.ListarPorId(pedidoModel));
        }

    }
}
