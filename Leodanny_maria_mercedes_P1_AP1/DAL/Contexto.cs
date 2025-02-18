using System;
using System.ComponentModel.DataAnnotations;
using Leodanny_maria_mercedes_P1_AP1.Models;
using Microsoft.EntityFrameworkCore;
 
namespace Leodanny_maria_mercedes_P1_AP1.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    
        public DbSet<reportes> Reportes { get; set; } // Nuevo modelo agregado
    }
}
