using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ECOM.Intranet.Models.CMS;

namespace ECOM.Intranet.Data
{
    public class ECOMContext : DbContext
    {
        public ECOMContext (DbContextOptions<ECOMContext> options)
            : base(options)
        {
        }

        public DbSet<ECOM.Intranet.Models.CMS.Strona> Strona { get; set; } = default!;

        public DbSet<ECOM.Intranet.Models.CMS.Aktualnosc> Aktualnosc { get; set; }
    }
}
