using Microsoft.EntityFrameworkCore;

namespace RehberUygulamasi.Models
{
    public class RehberContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-FND5M9B\\SQLEXPRESS;Database=RehberDB ; Trusted_Connection=True ;TrustServerCertificate=True;");
        }
        public DbSet<Rehber>rehbers { get; set; }   
        public DbSet<Admin>admins { get; set; }
    }
}
