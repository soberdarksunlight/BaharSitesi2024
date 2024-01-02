using WebApplication1.Models;

namespace WebApplication1
{
    internal class DbInitializer
    {
        internal static void Initialize(BaharSitesiDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();
            if (dbContext.Daires.Any()) return;

            List<Daire> daires = new List<Daire>();
            Daire daire;

            for (int i = 1; i <= 12; i++)//floor yani katı
            {
                for (int j = 1; j <= 4; j++)//daire 
                {
                    int k = (i - 1) * 4 + j;
                    daire = new Daire()
                    {
                        Blok = "A",
                        Kat = i,
                        DaireNo = k
                    };

                    daires.Add(daire);
                    daire = new Daire()
                    {
                        Blok = "B",
                        Kat = i,
                        DaireNo = k
                    };
                    daires.Add(daire);

                }
            }

            dbContext.Daires.AddRange(daires);
            dbContext.SaveChanges();
        }
    }
}
