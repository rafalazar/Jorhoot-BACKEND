using Microsoft.EntityFrameworkCore;

namespace SurveyAPI.Models
{
    public class EfDataContext : DbContext
    {
        public EfDataContext(DbContextOptions<EfDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Option> Options { get; set; }
    }
}
