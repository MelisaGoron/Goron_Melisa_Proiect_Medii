using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//clasa pentru disciplinele asignate unei teme
namespace Goron_Melisa_Proiect_Medii.Models
{
    public class DisciplineAtribuite
    {
        public int DisciplinaID { get; set; }
        public string Nume { get; set; }
        public bool Assigned { get; set; }
    }
}
