using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECOM.PortalWWW.Controllers
{
    public class SklepController : Controller
    {
        private readonly FirmaContext _context;

        public SklepController(FirmaContext context)
        {
            _context = context;
        }
        
        /// w zmiennej id bedzie przekazywane id categorii kliknietego rodzaju towaru.
        public async Task<IActionResult> Index(int? id)
        {
            // Za pomoca view baga przekazujemy do widoku wszystkie rodzaje towarow.
            ViewBag.Rodzaje = await _context.Rodzaj.ToListAsync();
            // Przy pierwszym wejsciu do sklepu id rodzaju towaru bedzie puste, zatem domyslnie podstawimy tam pierwszy rodzaj.
            if(id == null)
            {
                var pierwszy = await _context.Rodzaj.FirstAsync();
                id = pierwszy.IdRodzaju;
            }
            // do widoku przekazujemy wszystkie to wary danego kliknietego rodzaju.
            return View(await _context.Towar.Where(item =>item.RodzajId == id).ToListAsync());
        }

        //to jest funkcja ktora wystawia dane do widoku wyswietlajacego szczegoly towaru.
        public async Task<IActionResult> Details(int id) // w parametrze id jest okreslone id towaru ktorego szczegoly mamy wyswietlic.
        {
            ViewBag.Rodzaje = await _context.Rodzaj.ToListAsync();
            //do widoku przekazujemy towar o danym kliknietym id.
            return View(await _context.Towar.FirstOrDefaultAsync(item => item.IdTowaru == id));
        }
    }
}
