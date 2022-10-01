using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class KargoDetay
    {
        [Key]
        public int KargoDetayid { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(200)]
        public string Aciklama { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        public string TakipKodu { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(60)]
        public string Personel { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(60)]
        public string Alici { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        public string Tarih { get; set; }

        public bool Durum { get; set; }
    }
}