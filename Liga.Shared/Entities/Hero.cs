using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Liga.Shared.Entities
{
    public class Hero
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede tener mas de {1} Caracteres")]
        [Display(Name = "Name Hero")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede tener mas de {1} Caracteres")]
        [Display(Name = "Power")]
        public string Power { get; set; } = null!;

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        [MaxLength(300, ErrorMessage = "El Campo {0} no puede tener mas de {1} Caracteres")]
        [Display(Name = "Url")]
        public string Url { get; set; } = null!;

        public int TotalWeaks => Weaknesses == null ? 0 : Weaknesses.Count;

        //Relation
        public ICollection<Weakness> Weaknesses { get; set; }
    }
}
