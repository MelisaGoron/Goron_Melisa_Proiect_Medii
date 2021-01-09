using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Goron_Melisa_Proiect_Medii.Data;
using Goron_Melisa_Proiect_Medii.Models;

namespace Goron_Melisa_Proiect_Medii.Pages.Teme
{
    public class IndexModel : PageModel
    {
        private readonly Goron_Melisa_Proiect_Medii.Data.Goron_Melisa_Proiect_MediiContext _context;

        public IndexModel(Goron_Melisa_Proiect_Medii.Data.Goron_Melisa_Proiect_MediiContext context)
        {
            _context = context;
        }

        public IList<Tema> Tema { get;set; }
        public TemaData TemaD { get; set; }
        public int TemaID { get; set; }
        public int DisciplinaID { get; set; }

        public async Task OnGetAsync(int? id, int? disciplinaID)
        {
            TemaD = new TemaData();//creez ob de tipul TemaData

            TemaD.Teme = await _context.Tema
                .Include(b => b.Clasa)
                .Include(b => b.TemaDiscipline)
                .ThenInclude(b => b.Disciplina)
                .AsNoTracking()
                .OrderBy(b => b.Titlu)
                .ToListAsync();

            if (id != null)
            {
                TemaID = id.Value;
                Tema tema = TemaD.Teme
                .Where(i => i.ID == id.Value).Single();
                TemaD.Discipline = tema.TemaDiscipline.Select(s => s.Disciplina);
            }

        }
    }
}
