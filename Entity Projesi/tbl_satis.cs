//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity_Projesi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class tbl_satis
    {
        public int SatisId { get; set; }
        public Nullable<int> UrunId { get; set; }
        public Nullable<int> MusteriId { get; set; }
        [Description("Toplam Tutar")]
        public Nullable<decimal> SatisFiyat { get; set; }
        public Nullable<int> SatisAdet { get; set; }
        public Nullable<System.DateTime> SatisTarih { get; set; }
    
        public virtual tbl_musteri tbl_musteri { get; set; }
        public virtual tbl_urun tbl_urun { get; set; }
    }
}