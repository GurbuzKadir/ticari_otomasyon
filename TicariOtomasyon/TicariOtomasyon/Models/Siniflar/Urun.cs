using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunID { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(30)]
        public string UrunAdi { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(30)]
        public string Marka { get; set; }

        public short Stok { get; set; }
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public bool Durum { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(4000)]
        [AllowHtml]
        public string Detay { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(1500)]
        [AllowHtml]
        public string Aciklama { get; set; }

        public int Kategoriid { get; set; }
        public virtual Kategori Kategori { get; set; }

        public ICollection<SatisHareket> SatisHarekets  { get; set; }

    }
}