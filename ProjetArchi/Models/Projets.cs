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
    
    public partial class Projets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Projets()
        {
            this.Archives = new HashSet<Archives>();
            this.Participe = new HashSet<Participe>();
        }
    
        public int id_proj { get; set; }
        public int avancement { get; set; }
        public System.DateTime date_début { get; set; }
        public Nullable<System.DateTime> date_fin { get; set; }
        public int id_mod { get; set; }
        public int id_client { get; set; }
        public int id_archi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Archives> Archives { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Participe> Participe { get; set; }
    }
}
