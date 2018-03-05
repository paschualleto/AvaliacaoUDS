using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProjeto.DataProvider.Models
{
    public class PedidoModel : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo pessoa")]
        public string Pessoa { get; set; }
        [Required(ErrorMessage = "Preencha o campo Número")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "Preencha o campo Data da Venda")]
        public string DataVenda { get; set; }
        public double TotalVenda { get; set; }
    }
}
