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
    
    public partial class RequestStatu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequestStatu()
        {
            this.CompetitionRegistrations = new HashSet<CompetitionRegistration>();
            this.StallRequests = new HashSet<StallRequest>();
            this.VolunteersAndAmbassadors = new HashSet<VolunteersAndAmbassador>();
        }
    
        public int Id { get; set; }
        public string Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompetitionRegistration> CompetitionRegistrations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StallRequest> StallRequests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VolunteersAndAmbassador> VolunteersAndAmbassadors { get; set; }
    }
}
