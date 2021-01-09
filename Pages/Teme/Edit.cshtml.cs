using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Goron_Melisa_Proiect_Medii.Data;
using Goron_Melisa_Proiect_Medii.Models;

namespace Goron_Melisa_Proiect_Medii.Pages.Teme
{
    public class EditModel : TemaDisciplinePageModel
    {
        private readonly Goron_Melisa_Proiect_Medii.Data.Goron_Melisa_Proiect_MediiContext _context;

        public EditModel(Goron_Melisa_Proiect_Medii.Data.Goron_Melisa_Proiect_MediiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tema Tema { get; set; }//Legarea proprietatilor – nu mai este necesara conversia datelor HTTP catre tipul modelului

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tema = await _context.Tema
                .Include(b => b.Clasa)
                .Include(b => b.TemaDiscipline).ThenInclude(b => b.Disciplina)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Tema == null)
            {
                return NotFound();
            }

            //apelam PopulareDisciplineAtribuite pentru o obtine informatiile necesare checkbox-urilor folosind clasa DisciplineAsignate
            PopulareDisciplineAtribuite(_context, Tema);

            //ViewData["ClasaID"] = new SelectList(_context.Set<Clasa>(), "ID", "NumeClasa");
            ViewData["ClasaID"] = new SelectList(_context.Clasa, "ID", "NumeClasa");
            return Page();
        }

        

        public async Task<IActionResult> OnPostAsync(int? id, string[]
disciplineSelectate)

        {
            if (id == null)
            {
                return NotFound();
            }
            var temaToUpdate = await _context.Tema
            .Include(i => i.Clasa)
            .Include(i => i.TemaDiscipline)
            .ThenInclude(i => i.Disciplina)
            .FirstOrDefaultAsync(s => s.ID == id);

            if (temaToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Tema>(
            temaToUpdate,
            "Tema",
            i => i.Titlu, i => i.Elev,
            i => i.DataPublicarii, i => i.Clasa))
            {
                UpdateTemeDisipline(_context, disciplineSelectate, temaToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            //Apelam UpdateTemeDisiplina pentru a aplica informatiile din checkboxuri la entitatea Teme care este editata
            UpdateTemeDisipline(_context, disciplineSelectate, temaToUpdate);
            PopulareDisciplineAtribuite(_context, temaToUpdate);
            return Page();
        }
    }
}
