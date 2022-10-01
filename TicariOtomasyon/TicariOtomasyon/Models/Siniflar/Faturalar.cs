using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaID { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        public string FaturaSeriNo { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        public string FaturaSiraNo { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        public string FaturaTarih { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(60)]
        public string VergiDairesi { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(5)]
        public string FaturaSaat { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string TeslimEden { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string TeslimAlan { get; set; }

        public decimal Toplam { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}