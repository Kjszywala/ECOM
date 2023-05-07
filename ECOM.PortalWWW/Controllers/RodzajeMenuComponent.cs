using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECOM.PortalWWW.Controllers
{
    // Celem tego komponentu bedzie wyswietlenie w czesci layoutu wszystkich rodzajow towarow podlinkowanych do towaru danego rodzaju.
    public class RodzajeMenuComponent : ViewComponent
    {
        private readonly FirmaContext _context;

        public RodzajeMenuComponent(FirmaContext context)
        {
            _context = context;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Zwracamy widok RodzajeMenuComponent do ktorego przekazujemy kolekcje rodzajow towarow.
            return View("RodzajeMenuComponent", await _context.Rodzaj.ToListAsync());
        }
    }
}
