using Firma.Data.Data;
using Firma.Data.Data.Sklep;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ECOM.Intranet.Controllers
{
    // klasa basecontroller zawiera funkcje abstrakcyjna zatem musi byc abstrakcyjna.
    public abstract class BaseController<TEntity> : Controller
    {
        protected readonly FirmaContext _context;

        public BaseController(FirmaContext context)
        {
            _context = context;
        }

        // ta funkcja jest abstrakcyjna poniewaz nie ma bloku
        // bedzie ona napisana dopiero w klasach abstrkcyjnych.
        // Zwraca ona wszystkie obiekty danego typu tentity lub
        // typu ktory dziedziczy z tentity do wyswietlenia
        public abstract Task<List<TEntity>> GetEntityList();

        // index wyswietla wszytskie obiekty.
        public async Task<IActionResult> Index()
        {
            //var model = await _context.Towar.Include(t => t.Rodzaj).ToListAsync();

            return View(await GetEntityList());
        }

        //sluzy do obslugi komboboxow
        public virtual Task SetSelectList()
        {
            // null bo moze nie miec selectow.
            return null;
        }

        // pierwszy create pojawia sie z zaladwaniem vidoku
        public async Task<IActionResult> CreateAsync()
        {   
            await SetSelectList();
            return View();
        }
        
        // drugi create wywola sie gdy wcisniemy create/zapisz.
        [HttpPost]
        public async Task<IActionResult> Create(TEntity towar)
        {
            await _context.AddAsync(towar);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
