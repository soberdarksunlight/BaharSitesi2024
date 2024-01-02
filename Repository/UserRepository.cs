using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BaharSitesiDbContext _context;

        public UserRepository(BaharSitesiDbContext context)
        {
            _context = context;
        }
        public void EvSahipleri(EvSahipleri evSahipleri)
        {
            _context.EvSahipleris.Add(evSahipleri);
            _context.SaveChanges();
        }

        public List<EvSahipleri> GetEvSahipleris()
        {
            return _context.EvSahipleris.ToList();
        }

        public EvSahipleri? GetUserByCreadential(string eposta, string sifre)
        {
            return _context.EvSahipleris.FirstOrDefault(i => i.EPosta == eposta && i.Sifre == sifre);

        }
    }
}
