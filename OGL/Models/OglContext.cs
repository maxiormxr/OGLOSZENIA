using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OGL.Models
{
    // Możesz dodać dane profilu dla użytkownika, dodając więcej właściwości do klasy Uzytkownik. Odwiedź stronę https://go.microsoft.com/fwlink/?LinkID=317594, aby dowiedzieć się więcej.


    public class OglContext : IdentityDbContext
    {
        public OglContext()
            : base("DefaultConnection")
        {

        }
        public static OglContext Create()
        {
            return new OglContext();
        }
        public DbSet<Kategoria> Kategorie { get; set; }
        public DbSet<Ogloszenie> Ogloszenia { get; set; }
        public DbSet<Uzytkownik> Uzytkownik { get; set; }
        public DbSet<Ogloszenie_Kategoria> Ogloszenie_Kategoria { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Ogloszenie>().HasRequired(x => x.Uzytkownik).WithMany(x => x.Ogloszenia).
                HasForeignKey(x => x.UzytkownikId).WillCascadeOnDelete(true);
        }
    }
}