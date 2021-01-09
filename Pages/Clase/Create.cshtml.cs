using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Goron_Melisa_Proiect_Medii.Data;
using Goron_Melisa_Proiect_Medii.Models;

namespace Goron_Melisa_Proiect_Medii.Pages.Clase
{
    public class CreateModel : PageModel
    {
        private readonly Goron_Melisa_Proiect_Medii.Data.Goron_Melisa_Proiect_MediiContext _context;

        public CreateModel(Goron_Melisa_Proiect_Medii.Data.Goron_Melisa_Proiect_MediiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] //Legarea proprietatilor – nu mai este necesara conversia datelor HTTP catre tipul modelului
        public Clasa Clasa { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)//se verifica erorile de validare
            {
                return Page();
            }

            _context.Clasa.Add(Clasa);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");//Daca nu exista erori se salveaza datele si se redirecteaza pagina
        }//Daca exista erori se reafiseaza pagina cu mesaje de validare
    }
}
