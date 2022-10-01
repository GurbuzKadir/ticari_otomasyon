using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipid { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(30)]
        public string TakipKodu { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(200)]
        public string Aciklama { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        public string Tarih { get; set; }
    }
}