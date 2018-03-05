using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProjeto.DataProvider.Models;
using WebProjeto.DataProvider.Repository;

namespace WebProjeto.DataProvider.Service
{
    public class ItemPedidoService
    {
        private ItemPedidoRepository itemPedidoRepository;
        private List<string> mensagens;

        //private System.Web.ModelBinding.ModelStateDictionary modelState;

        public ItemPedidoService()
        {
            itemPedidoRepository = new ItemPedidoRepository();
        }

        public IEnumerable<ItemPedidoModel> ListaItemPedido()
        {
            return itemPedidoRepository.Localizar();
        }

        public ItemPedidoModel ListarPorId(ItemPedidoModel model)
        {
            return itemPedidoRepository.LocalizarPorId(model);
        }

        public string Salvar(ItemPedidoModel model)
        {
            if (!ValidaItemPedido(model))
            {
                return "AVISO";
            }

            bool salvou = false;
            try
            {
                if (model.Id == 0)
                {
                    salvou = itemPedidoRepository.Salvar(model);
                }
                else
                {
                    salvou = itemPedidoRepository.Atualizar(model);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return "OK";
        }

        public string Remover(ItemPedidoModel model)
        {
            bool excluiu = false;
            try
            {
                excluiu = itemPedidoRepository.Remover(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return "OK";
        }

        protected bool ValidaItemPedido(ItemPedidoModel model)
        {
            if (string.IsNullOrEmpty(model.Produto)) {
                return false;
            }

            if (model.Quantidade <= 0) {
                return false;
            }

            if (model.PercDesconto < 0) {
                return false;
            }

            return true;
        }
    }
}
