using Firma.Data.Data;
using Firma.Data.Data.Sklep;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ECOM.Intranet.Controllers
{
	public class TowarController : BaseController<Towar>
	{
		public TowarController(FirmaContext context)
			: base(context)
		{
		}

		public override async Task<List<Towar>> GetEntityList()
		{
			return await _context.Towar.Include(t => t.Rodzaj).ToListAsync();
		}

		public override async Task SetSelectList()
		{
            ViewBag.Rodzaj = new SelectList(await _context.Rodzaj.ToListAsync(), "IdRodzaju", "Nazwa");
        }
	}
}
