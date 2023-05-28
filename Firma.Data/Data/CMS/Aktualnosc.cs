using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Data.CMS
{

    public class Aktualnosc : TEntity
    {
        [Key]// to co nizej jest kluczem podstawowym tabeli.
        public int IdAktualnosci { get; set; }

        [Required(ErrorMessage = "Title is required")] // pole jest wymagane.
        [MaxLength(10, ErrorMessage = "Title can include maximum 10 characters.")] // maksymalna dlugosc.
        [Display(Name = "Aktualnosci odnosnik Title")] // ta nazwe pola bedzie widzial uzytkownik.
        public string LinkTytul { get; set; }

        [Required(ErrorMessage = "Title is required")] // pole jest wymagane.
        [MaxLength(30, ErrorMessage = "Title can include maximum 10 characters.")] // maksymalna dlugosc.
        [Display(Name = "Title")] // ta nazwe pola bedzie widzial uzytkownik.
        public string Tytul { get; set; }

        [Display(Name = "Tresc")] // ta nazwe pola bedzie widzial uzytkownik.
        [Column(TypeName = "nvarchar(MAX)")] // okreslam jakiego typu to pole bedzie w bazie danych.
        public string Tresc { get; set; }

        [Display(Name = "Pozycja wyswietlania")]
        [Required(ErrorMessage = "Pozycja is required")]
        public int Pozycja { get; set; }
    }

}
