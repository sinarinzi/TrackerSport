using Microsoft.EntityFrameworkCore;
using Examen2_ASP.Models;

namespace Examen2_ASP.Models.Db
{
    public class TrackerSportContext : DbContext
    {
        public DbSet<Exercice> Exercices { get; set; }
        public DbSet<Action> Actions { get; set; }

        public TrackerSportContext(DbContextOptions<TrackerSportContext> options) : base(options)
        {

        }

       
    }
}
