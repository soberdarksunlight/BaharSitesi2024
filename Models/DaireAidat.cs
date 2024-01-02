using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class DaireAidat
    {
        public int Id { get; set; }

        [ForeignKey("DaireId")]
        public Daire Daire { get; set; }
        public int DaireId {  get; set; }
        public DateTime? ÖdemeTarihi { get; set; }
        public decimal? ÖdenenTutar {  get; set; }
        public int AidatId {  get; set; }

    }
}
