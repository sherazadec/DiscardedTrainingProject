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
    
    public partial class RéponsesQuestionnaireProjet
    {
        public int idRep { get; set; }
        public string Reponses { get; set; }
        public int xidQuest { get; set; }
    
        public virtual QuestionnaireCréationProjet QuestionnaireCréationProjet { get; set; }
    }
}
