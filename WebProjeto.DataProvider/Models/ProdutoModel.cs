using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProjeto.DataProvider.Models
{
    public class ProdutoModel : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo código")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha o campo Preço Unitário")]
        public decimal PrecoUnitario { get; set; }
    }
}
