using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapatosADS.Model
{

    [Table("Pessoas")]
    public abstract class Pessoa
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Endereco { get; set; }

        // Para facilitar a listagem de compras de um cliente
        public IList<Venda> Compras { get; set; }

    }
}
