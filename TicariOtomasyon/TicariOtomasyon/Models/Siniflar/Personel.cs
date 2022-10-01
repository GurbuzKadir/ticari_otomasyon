using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string PersonelGorsel { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(11, ErrorMessage = "En fazla 11 karakter girilebilir.")]//Tüm alanlara uygulanacak
        [Required(ErrorMessage = "Bu alan zorunludur!")]//Tüm alanlara uygulanacak
        public string PersonelTelefon { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(500, ErrorMessage = "En fazla 500 karakter girilebilir.")]//Tüm alanlara uygulanacak
        [Required(ErrorMessage = "Bu alan zorunludur!")]//Tüm alanlara uygulanacak
        public string PersonelAdres { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
        public int Departmanid { get; set; }
        public virtual Departman Departman { get; set; }
        public bool Durum { get; set; }
    }
}