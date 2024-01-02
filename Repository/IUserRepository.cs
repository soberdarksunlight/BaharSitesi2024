using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IUserRepository
    {
        List<EvSahipleri> GetEvSahipleris();

        EvSahipleri? GetUserByCreadential(string eposta, string sifre);

        void EvSahipleri(EvSahipleri evSahipleri);
    }
}
