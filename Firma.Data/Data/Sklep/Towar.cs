using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Data.Sklep
{
    public class Towar
    {
        [Key]
        public int IdTowaru { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Kod { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Column(TypeName = "money")]
        public Decimal Cena { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "Wybierz zdjecie")]
        public string FotoUrl { get; set; }

        public string Opis { get; set; }

        //to jest realizacja klucza obcego.

        public int RodzajId { get; set; }

        public Rodzaj Rodzaj { get; set; }
    }
}
