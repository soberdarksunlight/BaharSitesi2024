using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{

    public class Aidat
    {
        public int Id { get; set; }
        public decimal Tutar { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }

        [NotMapped]
        public string AidatDönemi { get {
                return $"{BaslangicTarihi.Year} Yılı {BaslangicTarihi.Month} Ayı Dönemi";
            } }
        

    }
}
