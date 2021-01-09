using Goron_Melisa_Proiect_Medii.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Pentru paginile Create si Edit al entitatii Tema am creat o clasa care mosteneste PageModel
//PopulareDisciplineAtribuite citeste entitatile Discipline si populeaza lista ListaDisciplineAtribuite.
namespace Goron_Melisa_Proiect_Medii.Models
{
    public class TemaDisciplinePageModel : PageModel //using Microsoft.AspNetCore.Mvc.RazorPages;
    {
        public List<DisciplineAtribuite> ListaDisciplineAtribuite;
        public void PopulareDisciplineAtribuite(Goron_Melisa_Proiect_MediiContext context, //using Goron_Melisa_Proiect_Medii.Data;
        Tema tema)
        {
            //se citesc entitatile Discipline:
            var toateDisciplinele = context.Disciplina;//se face o variabila cu toate doisciplinele
            var disciplineleUneiTeme = new HashSet<int>(
            tema.TemaDiscipline.Select(c => c.TemaID));//creez o colectie

            //se poluleaza lista ListaDisciplineAtribuite cu Disciplinele asignate fiecarei Teme 
            ListaDisciplineAtribuite = new List<DisciplineAtribuite>();
            foreach (var dis in toateDisciplinele)
            {
                ListaDisciplineAtribuite.Add(new DisciplineAtribuite
                {
                    DisciplinaID = dis.ID,
                    Nume = dis.NumeDisciplina,
                    Assigned = disciplineleUneiTeme.Contains(dis.ID)
                });//creez lista cu disciplinele atribuite fiecarei teme
            }
        }

        //Se adauga in clasa TemeDisciplina, Disciplinele aferente fiecarei Teme
        public void UpdateTemeDisipline(Goron_Melisa_Proiect_MediiContext context,
        string[] disciplineSelectate, Tema temaToUpdate)
        {
            if (disciplineSelectate == null)
            {
                temaToUpdate.TemaDiscipline = new List<TemaDisciplina>();
                return;
            }
            var disciplineSelectateHS = new HashSet<string>(disciplineSelectate);//colectie
            var disciplineleUneiTeme = new HashSet<int>
            (temaToUpdate.TemaDiscipline.Select(c => c.Disciplina.ID));//colectie pt disciplinele unei teme

            foreach (var dis in context.Disciplina)
            {
                if (disciplineSelectateHS.Contains(dis.ID.ToString()))
                {
                    if (!disciplineleUneiTeme.Contains(dis.ID))
                    {
                        temaToUpdate.TemaDiscipline.Add(
                        new TemaDisciplina
                        {
                            TemaID = temaToUpdate.ID,
                            DisciplinaID = dis.ID
                        });
                    }
                }
                else
                {
                    if (disciplineleUneiTeme.Contains(dis.ID))
                    {
                        TemaDisciplina courseToRemove
                        = temaToUpdate
                        .TemaDiscipline
                        .SingleOrDefault(i => i.DisciplinaID == dis.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}

