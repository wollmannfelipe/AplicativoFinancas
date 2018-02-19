using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BancoDeDadosFinancas
{
    [Table("TipoMovimento")]
    public class TipoMovimento
    {
        [Key]
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public char CreditoDebito { get; set; }

        public virtual ICollection<Movimento> Movimentos { get; set; }
    }
}