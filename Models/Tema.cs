using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Goron_Melisa_Proiect_Medii.Models
{
    public class Tema
    {
        public int ID { get; set; }

        [Required, StringLength(100, MinimumLength = 3)]
        [Display(Name = "Titlul temei")]
        public string Titlu { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$"), Required,
        StringLength(50, MinimumLength = 3)]
        [Display(Name = "Nume elev")]
        public string Elev { get; set; }

        [Display(Name = "Data publicării")]
        [DataType(DataType.Date)]
        public DateTime DataPublicarii { get; set; }

        public int ClasaID { get; set; }
        public Clasa Clasa { get; set; }
        public ICollection<TemaDisciplina> TemaDiscipline { get; set; }

    }
}
