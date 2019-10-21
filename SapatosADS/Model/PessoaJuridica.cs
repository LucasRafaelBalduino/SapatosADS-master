using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapatosADS.Model
{
    public class PessoaJuridica : Pessoa
    {
        public String RazaoSocial { get; set; }
        public String Cnpj { get; set; }


    }
}
