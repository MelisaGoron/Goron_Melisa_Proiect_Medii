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
    public class DeleteModel : PageModel
    {
        private readonly Goron_Melisa_Proiect_Medii.Data.Goron_Melisa_Proiect_MediiContext _context;

        public DeleteModel(Goron_Melisa_Proiect_Medii.Data.Goron_Melisa_Proiect_MediiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tema Tema { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tema = await _context.Tema.FirstOrDefaultAsync(m => m.ID == id);

            if (Tema == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tema = await _context.Tema.FindAsync(id);

            if (Tema != null)
            {
                _context.Tema.Remove(Tema);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
