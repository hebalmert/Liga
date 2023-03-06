using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Liga.Shared.Entities
{
    public class Weakness
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede tener mas de {1} Caracteres")]
        [Display(Name = "Weakness")]
        public string Weak { get; set; } = null!;

        public int HeroId { get; set; }

        public Hero Hero { get; set; }


    }
}
