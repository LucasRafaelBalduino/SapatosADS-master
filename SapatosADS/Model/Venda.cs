using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapatosADS.Model
{

    [Table("Vendas")]
    public class Venda
    {
        public int Id { get; set; }

        public int QtdItems { get; set; }

        public Decimal Preco { get; set; }

        public DateTime DataVenda { get; set; }

        public Pessoa Pessoa { get; set; }

        public IList<Sapato> Sapatos { get; set; }

    }
}
