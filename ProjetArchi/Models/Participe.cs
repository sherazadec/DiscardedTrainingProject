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
    
    public partial class Participe
    {
        public int id { get; set; }
        public int xid_projet { get; set; }
        public int xid_Personnes { get; set; }
    
        public virtual Projets Projets { get; set; }
    }
}
