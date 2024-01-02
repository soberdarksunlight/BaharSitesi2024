using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class BaharSitesiDbContext : DbContext
    {
        public BaharSitesiDbContext(DbContextOptions<BaharSitesiDbContext> options) : base(options)
        {

        }

        public DbSet<Aidat> Aidats { get; set; }
        public DbSet<Daire> Daires { get; set; }
        public DbSet<DaireAidat> DaireAidats { get; set; }
        public DbSet<EvSahipleri> EvSahipleris { get; set; }

        
    }
}
