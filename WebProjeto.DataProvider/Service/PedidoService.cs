using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProjeto.DataProvider.Models;
using WebProjeto.DataProvider.Repository;

namespace WebProjeto.DataProvider.Service
{
    public class PedidoService
    {
        private PedidoRepository pedidoRepository;
        private List<string> mensagens;

        //private System.Web.ModelBinding.ModelStateDictionary modelState;

        public PedidoService()
        {
            pedidoRepository = new PedidoRepository();
        }

        public IEnumerable<PedidoModel> ListaPedido()
        {
            return pedidoRepository.Localizar();
        }

        public PedidoModel ListarPorId(PedidoModel model)
        {
            return pedidoRepository.LocalizarPorId(model);
        }

        public string Salvar(PedidoModel model)
        {
            if (!ValidaPedido(model))
            {
                return "AVISO";
            }

            bool salvou = false;
            try
            {
                if (model.Id == 0)
                {
                    salvou = pedidoRepository.Salvar(model);
                }
                else
                {
                    salvou = pedidoRepository.Atualizar(model);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return "OK";
        }

        public string Remover(PedidoModel model)
        {
            bool excluiu = false;
            try
            {
                excluiu = pedidoRepository.Remover(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return "OK";
        }

        protected bool ValidaPedido(PedidoModel model)
        {

            if (string.IsNullOrEmpty(model.Pessoa))
            {
                return false;
            }

            if (model.Numero <= 0)
            {
                return false;
            }

            if (string.IsNullOrEmpty(model.DataVenda)) {
                return false;
            }

            return true;
        }
    }
}
