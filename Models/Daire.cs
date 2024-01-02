using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Daire
    {
        public int Id { get; set; }
        public string Blok { get; set; }
        public int Kat { get; set; }
        public int DaireNo { get; set; }

        [NotMapped]
        public string DaireAciklama
        {
            get
            {
                return $"{Blok} Blok {Kat}.Kat {DaireNo}. Daire";
            }
        }
        public List<EvSahipleri> EvSahipleris { get; set; }


    }
}
