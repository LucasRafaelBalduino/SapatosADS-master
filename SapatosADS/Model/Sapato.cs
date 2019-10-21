using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapatosADS.Model
{

    [Table("Sapatos")]
    public class Sapato
    {
        public int Id { get; set; }

        [Required]
        public Modelo Modelo { get; set; }

        public Boolean Cadarco { get; set; }

        public String Material { get; set; }

        public String Cor { get; set; }

        [Required]
        public Decimal Preco { get; set; }

        public String Fotografia { get; set; }

        [Required]
        public int Tamanho { get; set; }

    }
}
