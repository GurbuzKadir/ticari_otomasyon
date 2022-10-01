using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Duyuru
    {
        [Key]
        public int DuyuruID { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girilebilir.")]//Tüm alanlara uygulanacak
        [Required(ErrorMessage = "Bu alan zorunludur!")]//Tüm alanlara uygulanacak
        public string DuyuruBaslik { get; set; }

        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Bu alan zorunludur!")]
        [StringLength(1500, ErrorMessage = "En fazla 1500 karakter girilebilir.")]
        [AllowHtml]
        public string DuyuruDetay { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        public string Tarih { get; set; }
        public bool Durum { get; set; }
    }
}