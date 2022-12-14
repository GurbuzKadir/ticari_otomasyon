using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(30)]
        public string KategoriAdi { get; set; }

        public bool Durum { get; set; }

        public ICollection<Urun> Uruns { get; set; }
        

    }
}