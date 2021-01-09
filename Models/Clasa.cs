using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Goron_Melisa_Proiect_Medii.Models
{
    public class Clasa
    {
        public int ID { get; set; }//va fi cs pentru Tema
        [Display(Name = "Nume Clasa")]
        public string NumeClasa { get; set; }
        public ICollection<Tema> Teme { get; set; }//propritate pentru navigare
       
    }
}
