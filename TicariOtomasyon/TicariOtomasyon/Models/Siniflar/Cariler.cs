using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CariID { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter girilebilir.")]//Tüm alanlara uygulanacak
        [Required(ErrorMessage ="Bu alan zorunludur!")]//Tüm alanlara uygulanacak
        public string CariAd { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(30,ErrorMessage = "En fazla 30 karakter girilebilir.")]
        [Required(ErrorMessage = "Bu alan zorunludur!")]
        public string CariSoyad { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(15, ErrorMessage = "En fazla 15 karakter girilebilir.")]
        [Required(ErrorMessage = "Bu alan zorunludur!")]
        public string CariSehir { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girilebilir.")]
        [Required(ErrorMessage = "Bu alan zorunludur!")]
        public string CariMail { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(11, ErrorMessage = "En fazla 11 karakter girilebilir.")]//Tüm alanlara uygulanacak
        [Required(ErrorMessage = "Bu alan zorunludur!")]//Tüm alanlara uygulanacak
        public string CariTelefon { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(500, ErrorMessage = "En fazla 500 karakter girilebilir.")]//Tüm alanlara uygulanacak
        [Required(ErrorMessage = "Bu alan zorunludur!")]//Tüm alanlara uygulanacak
        public string CariAdres { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter girilebilir.")]//Tüm alanlara uygulanacak
        [Required(ErrorMessage = "Bu alan zorunludur!")]//Tüm alanlara uygulanacak
        public string Sifre { get; set; }

        public bool Durum { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }


    }
}