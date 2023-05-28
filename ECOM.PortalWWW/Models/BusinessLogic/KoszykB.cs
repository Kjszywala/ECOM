using Firma.Data.Data;
using Firma.Data.Data.Sklep;

namespace ECOM.PortalWWW.Models.BusinessLogic
{
    // To jest klasa ktora bedzie zawierala operacje biznesowe na koszyku.
    public class KoszykB
    {
        private readonly FirmaContext _context;
        public string IdSesjiKoszyka { get; set; }

        public KoszykB(FirmaContext context, HttpContext httpContext)
        {
            _context = context;
            IdSesjiKoszyka = GetIdSesjiKoszyka(httpContext);
        }

        // tworzymy funkcje ktora okresla identyfikator przegladarki
        private string GetIdSesjiKoszyka(HttpContext httpContext)
        {
            // jezeli w sesji id sesji koszyka jest puste czyli nie ma okreslonego identyfikatora przegladarki
            // to najpierw sprawdzamy czy mozemy ten identyfikator przeczytac z kontextu
            // jezeli w kontexcie name nie jest nullem to wtedy ten name staje sie idsesjikoszyka
            // ale gdyby byl nulem wygenerujemy unikalny numer przegladarki przy pomocy guida.
            // i ustawimy go do id sessji koszyka.
            if(httpContext.Session.GetString("IdSesjiKoszyka") == null)
            {
                if (!string.IsNullOrEmpty(httpContext.User.Identity.Name))
                {
                    httpContext.Session.SetString("IdSesjiKoszyka", httpContext.User.Identity.Name);
                }
                else
                {
                    Guid tempIdSesjiKoszyka = Guid.NewGuid();
                    httpContext.Session.SetString("IdSesjiKoszyka", tempIdSesjiKoszyka.ToString());
                }
            }
            return httpContext.Session.GetString("IdSesjiKoszyka").ToString();
        }
        
        //utworzymy tearz funkcje ktora bedzie dodawala nowe towary do koszyka.
        public void DodajDoKoszyka(Towar towar)
        {
            //najpierw sprawdzamy czy taki towar w koszyku juz nie istnieje.
            //var elementKoszyka = _context.Towar.Where(item=>item.Equals(towar));
            var elementKoszyka = (from element in _context.ElementKoszyka where element.IdSesjiKoszyka == this.IdSesjiKoszyka && element.IdTowaru == towar.IdTowaru select element).FirstOrDefault();
            if(elementKoszyka == null)
            {
                //jezeli brak tego towaru w koszyku 
                _context.ElementKoszyka.Add(elementKoszyka);
            }
            else
            {
                //jezeli jest w koszyku.
            }
        }
    }
}
