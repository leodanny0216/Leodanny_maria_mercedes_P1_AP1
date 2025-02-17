namespace Leodanny_maria_mercedes_P1_AP1.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Modelo> Modelo { get; set; }
    }
}
