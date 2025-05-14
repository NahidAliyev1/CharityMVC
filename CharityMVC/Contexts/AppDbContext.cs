using CharityMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CharityMVC.Contexts
{
    public class AppDbContext:DbContext
    {
        public DbSet<OurCauses> OurCauses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-GTVND9D\SQLEXPRESS;Database=OurcausesDb;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
