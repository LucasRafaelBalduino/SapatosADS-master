using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapatosADS.Model
{
    public class PessoaFisica : Pessoa
    {
        public String Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
