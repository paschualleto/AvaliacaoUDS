using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProjeto.DataProvider.Models
{
    public class ItemPedidoModel : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Produto")]
        public string Produto { get; set; }
        public int IdVenda { get; set; }
        [Required(ErrorMessage = "Preencha o campo quantidade")]
        public double Quantidade { get; set; }
        [Required(ErrorMessage = "Preencha o campo preço unitário")]
        public double PrecoUnitario { get; set; }
        [Required(ErrorMessage = "Preencha o campo desconto")]
        public double PercDesconto { get; set; }
        [Required(ErrorMessage = "Preencha o campo total item")]
        public double TotalItem { get; set; }
    }
}
