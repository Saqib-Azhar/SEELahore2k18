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
    
    using System.ComponentModel; public partial class StallCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StallCategory()
        {
            this.StallRequests = new HashSet<StallRequest>();
        }
    
        public int Id { get; set; }
        public string StallType { get; set; }
        [DisplayName("Created By")] public string CreatedBy { get; set; }
        [DisplayName("Created At")]        public Nullable<System.DateTime> CreatedAt { get; set; } 
    
        public virtual AspNetUser AspNetUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StallRequest> StallRequests { get; set; }
    }
}
