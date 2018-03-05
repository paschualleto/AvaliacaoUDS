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
    public class PessoaController : Controller
    {
        //private WebProjetoContext db = new WebProjetoContext();

        private PessoaService pessoaService;

        public PessoaController()
        {
            pessoaService = new PessoaService();
        }

        // GET: ProdutoModels
        public ActionResult Pessoa()
        {
            return View(pessoaService.ListaPessoas());
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult PersistePessoa([Bind(Include = "Id,Nome,DataNascimento")] PessoaModel pessoaModel)
        {
            var retorno = pessoaService.Salvar(pessoaModel);

            return Json(new { Resultado = retorno });
        }

        public ActionResult ExcluirPessoa([Bind(Include = "Id,Nome,DataNascimento")] PessoaModel pessoaModel)
        {
            var retorno = pessoaService.Remover(pessoaModel);

            return Json(retorno);
        }

        public ActionResult RecuperaPessoa([Bind(Include = "Id,Nome,DataNascimento")] PessoaModel pessoaModel)
        {
            return Json(pessoaService.ListarPorId(pessoaModel));
        }

        public ActionResult RecuperaTodasPessoa() {
            return Json(pessoaService.ListaPessoas());
        }
    }
}
