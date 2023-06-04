using ECOM.PortalWWW.Models.BusinessLogic;
using ECOM.PortalWWW.Models.Sklep;
using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;

namespace ECOM.PortalWWW.Controllers
{
	public class KoszykController : Controller
	{
		private readonly FirmaContext _context;

        public KoszykController(FirmaContext context)
        {
            _context = context;
        }

		//Ta funkcja wystawia dane do wyswietlania koszyka
        public async Task<IActionResult> Index()
		{
			KoszykB koszykB = new KoszykB(this._context, this.HttpContext);
			DaneDoKoszyka dane = new DaneDoKoszyka()
			{
				ElementyKoszyka = await koszykB.GetElementyKoszyka(),
				Razem = await koszykB.GetWartoscKoszyka()
			};
			return View(dane);
		}

		public async Task<IActionResult> DodajDoKoszyka(int id)
		{
			KoszykB koszykB = new KoszykB(this._context, this.HttpContext);
			koszykB.DodajDoKoszyka(await _context.Towar.FindAsync(id));
			return RedirectToAction("Index");
		}
	}
}
