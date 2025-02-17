﻿using Leodanny_maria_mercedes_P1_AP1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Leodanny_maria_mercedes_P1_AP1.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Modelo> Modelo { get; set; }
    }
}
