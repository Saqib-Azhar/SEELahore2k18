//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SEELahore2k18.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CompetitionCoordinator
    {
        public int Id { get; set; }
        public string CoordinatorName { get; set; }
        public string Photo { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public Nullable<int> CompetitionId { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Competition Competition { get; set; }
    }
}
