//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetArchi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Modélisateurs
    {
        public int id_model { get; set; }
        public int xid { get; set; }
    
        public virtual Personnes Personnes { get; set; }
    }
}
