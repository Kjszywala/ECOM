using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Data.Sklep
{
    // Koszyk sklada sie z elementow koszyka w ktorym jest okreslone ktore towary zamawia klient.
    public class ElementKoszyka
    {
        [Key]
        public int IdElementuKoszyka { get; set; }
        public string IdSesjiKoszyka { get; set; } // Identyfikator przegladarki ktora dodaje cos do koszyka.
        public int IdTowaru { get; set; }
        public Towar Towar { get; set; }
        public int Ilosc { get; set; }
        public DateTime DataUtworzenia { get; set; }
    }
}
