using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.Sklep
{
    public class Rodzaj :TEntity
    {
        [Key]
        public int IdRodzaju { get; set; }

        [Required(ErrorMessage = "Nazwa is required")] // pole jest wymagane.
        [MaxLength(30, ErrorMessage = "Nazwa can include maximum 30 characters.")] // maksymalna dlugosc.
        public string Nazwa { get; set; }

        public string Opis { get; set; }

        public List<Towar> Towar { get; set; } // to jest realizacja relacji jeden do wielu.
                                            // jeden rodzaj ma wiele towarow danego rodzaju.
    }
}
