using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECOM.PortalWWW.Controllers
{
    public class OdnosnikiComponent : ViewComponent
    {
        private readonly FirmaContext _context;

        public OdnosnikiComponent(FirmaContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Zwracamy widok RodzajeMenuComponent do ktorego przekazujemy kolekcje rodzajow towarow.
            return View("OdnosnikiComponent", await _context.Strona.ToListAsync());
        }
    }
}
