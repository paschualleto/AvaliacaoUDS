using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProjeto.DataProvider.Models
{
    public class PessoaModel : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha o campo data de nascimento")]
        public string DataNascimento { get; set; }
    }
}
