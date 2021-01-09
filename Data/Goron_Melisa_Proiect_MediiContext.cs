using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Goron_Melisa_Proiect_Medii.Models;

namespace Goron_Melisa_Proiect_Medii.Data
{
    public class Goron_Melisa_Proiect_MediiContext : DbContext
    {
        public Goron_Melisa_Proiect_MediiContext (DbContextOptions<Goron_Melisa_Proiect_MediiContext> options)
            : base(options)
        {
        }

        public DbSet<Goron_Melisa_Proiect_Medii.Models.Tema> Tema { get; set; }

        public DbSet<Goron_Melisa_Proiect_Medii.Models.Disciplina> Disciplina { get; set; }

        public DbSet<Goron_Melisa_Proiect_Medii.Models.Clasa> Clasa { get; set; }

        public DbSet<Goron_Melisa_Proiect_Medii.Models.TemaDisciplina> TemaDisciplina { get; set; }
    }
}
