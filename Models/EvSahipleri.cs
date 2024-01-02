using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class EvSahipleri
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TelefonNo { get; set; }
        public string EPosta { get; set; }
        public string Sifre { get; set; }
        public string? Sorumlu {  get; set; }

        [ForeignKey("DaireId")]
        public Daire Daire { get; set; }
        public int DaireId {  get; set; }

        public bool RememberMe {  get; set; }
    }
}
