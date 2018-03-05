using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProjeto.DataProvider.Models;
using WebProjeto.DataProvider.Repository;

namespace WebProjeto.DataProvider.Service
{
    public class PessoaService
    {
        private PessoaRepository pessoaRepository;
        private List<string> mensagens;

        private System.Web.ModelBinding.ModelStateDictionary modelState;

        public PessoaService()
        {
            pessoaRepository = new PessoaRepository();
        }

        public IEnumerable<PessoaModel> ListaPessoas()
        {
            return pessoaRepository.Localizar();
        }

        public PessoaModel ListarPorId(PessoaModel model)
        {
            return pessoaRepository.LocalizarPorId(model);
        }

        public string Salvar(PessoaModel model)
        {
            if (!ValidaPessoa(model))
            {
                return "AVISO";
            }

            bool salvou = false;
            try
            {
                if (model.Id == 0)
                {
                    salvou = pessoaRepository.Salvar(model);
                }
                else
                {
                    salvou = pessoaRepository.Atualizar(model);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return "OK";
        }

        public string Remover(PessoaModel model)
        {
            bool excluiu = false;
            try
            {
                excluiu = pessoaRepository.Remover(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return "OK";
        }

        protected bool ValidaPessoa(PessoaModel model)
        {
            
            if (string.IsNullOrEmpty(model.Nome))
            {
                return false;
            }

            if (string.IsNullOrEmpty(model.DataNascimento))
            {
                return false;
            }

            return true;
        }
    }
}
