using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Goron_Melisa_Proiect_Medii.Data;
using Goron_Melisa_Proiect_Medii.Models;

namespace Goron_Melisa_Proiect_Medii.Pages.Teme
{
    public class CreateModel : TemaDisciplinePageModel
    {
        private readonly Goron_Melisa_Proiect_Medii.Data.Goron_Melisa_Proiect_MediiContext _context;

        public CreateModel(Goron_Melisa_Proiect_Medii.Data.Goron_Melisa_Proiect_MediiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()//– initializeaza starea paginii
        {
           // ViewData["ClasaID"] = new SelectList(_context.Set<Clasa>(), "ID", "NumeClasa");
            ViewData["ClasaID"] = new SelectList(_context.Clasa, "ID", "NumeClasa");

            var tema = new Tema();
            tema.TemaDiscipline = new List<TemaDisciplina>();
            PopulareDisciplineAtribuite(_context, tema);

            return Page();//Will process and return the result of the current page.
        }


        [BindProperty]
        public Tema Tema { get; set; }


        public async Task<IActionResult> OnPostAsync(string[] disciplineSelectate) //– ruleaza cand exista cereri POST (cand utilizatorul trimite un formular)
        {
            var newTema = new Tema();
            if (disciplineSelectate != null)
            {
                newTema.TemaDiscipline = new List<TemaDisciplina>();
                foreach (var dis in disciplineSelectate)
                {
                    var disToAdd = new TemaDisciplina
                    {
                        DisciplinaID = int.Parse(dis)
                    };
                    newTema.TemaDiscipline.Add(disToAdd);
                }
            }
            if (await TryUpdateModelAsync<Tema>(
            newTema,
            "Tema",
           i => i.Titlu, i => i.Elev,
           i => i.DataPublicarii, i => i.ClasaID))
            {
                _context.Tema.Add(newTema);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulareDisciplineAtribuite(_context, newTema);
            return Page();

        }
    }
}
