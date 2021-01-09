using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goron_Melisa_Proiect_Medii.Models
{
    public class TemaDisciplina
    {
        public int ID { get; set; }

        public int TemaID { get; set; }
        public Tema Tema { get; set; }
        public int DisciplinaID { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}
