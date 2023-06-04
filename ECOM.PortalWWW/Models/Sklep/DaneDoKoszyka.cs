using Firma.Data.Data.Sklep;

namespace ECOM.PortalWWW.Models.Sklep
{
	// to jest klasa pomocnicza ktora bedzie sluzyla do tego zeby poprawnie
	// wyswietlac koszyk.
	public class DaneDoKoszyka
	{
        // w celu wyswietlenia koszyka mam liste elementow koszyka oraz jego sumaryczna wartosc.
        public List<ElementKoszyka> ElementyKoszyka { get; set; }
        public decimal Razem { get; set; }

    }
}
