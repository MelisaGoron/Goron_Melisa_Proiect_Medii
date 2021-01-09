using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Goron_Melisa_Proiect_Medii.Models
{
    public class Disciplina
    {
        public int ID { get; set; }//cs pentru Tema
        [Display(Name = "Nume disciplină")]
        public string NumeDisciplina { get; set; }
        //public ICollection<Tema> Teme { get; set; }//propritate pentru navigare

        public ICollection<TemaDisciplina> TemaDiscipline { get; set; }
    }
}
