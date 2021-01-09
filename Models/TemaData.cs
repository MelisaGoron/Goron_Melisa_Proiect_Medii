using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goron_Melisa_Proiect_Medii.Models
{
    public class TemaData
    {
        public IEnumerable<Tema> Teme { get; set; }
        public IEnumerable<Disciplina> Discipline { get; set; }
        public IEnumerable<TemaDisciplina> TemaDiscipline { get; set; }
    }
}
