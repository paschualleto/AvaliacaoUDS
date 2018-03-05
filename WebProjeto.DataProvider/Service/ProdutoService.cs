using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using WebProjeto.DataProvider.Models;
using WebProjeto.DataProvider.Repository;

namespace WebProjeto.DataProvider.Service
{
    public class ProdutoService
    {
        private ProdutoRepository produtoRepository;
        private List<string> mensagens;

        private System.Web.ModelBinding.ModelStateDictionary modelState;

        public ProdutoService()
        {
            produtoRepository = new ProdutoRepository();
        }

        public IEnumerable<ProdutoModel> ListaProdutos()
        {
            return produtoRepository.Localizar();
        }

        public ProdutoModel ListarPorId(ProdutoModel model)
        {
            return produtoRepository.LocalizarPorId(model);
        }

        public string Salvar(ProdutoModel model)
        {
            if (!ValidaProduto(model))
            {
                return "AVISO";
            }

            bool salvou = false;
            try
            {
                if (model.Id == 0)
                {
                    salvou = produtoRepository.Salvar(model);
                }
                else
                {
                    salvou = produtoRepository.Atualizar(model);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return "OK";
        }

        public string Remover(ProdutoModel model)
        {
            bool excluiu = false;
            try
            {
                excluiu = produtoRepository.Remover(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return "OK";
        }

        protected bool ValidaProduto(ProdutoModel model)
        {
            
            if (string.IsNullOrEmpty(model.Nome))
            {
                return false;
            }

            if (string.IsNullOrEmpty(model.Codigo)) {
                return false;
            }

            if (model.PrecoUnitario <= 0 ) {
                return false;
            }

            return true;
        }

    }
}
