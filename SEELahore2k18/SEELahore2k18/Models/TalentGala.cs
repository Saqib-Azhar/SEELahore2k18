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
    
    using System.ComponentModel;    public partial class TalentGala
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Institute")] public Nullable<int> InstituteId { get; set; }
        public string Degree { get; set; }
        [DisplayName("CGPA/Numbers")]
        public string CGPA_Numbers { get; set; }
        [DisplayName("Total Numbers")]
        public string TotalNumbers { get; set; }
        public string CNIC { get; set; }
        [DisplayName("Contact No.")]
        public string ContactNo_ { get; set; }
        public string Email { get; set; }
        [DisplayName("Created At")] public Nullable<System.DateTime> CreatedAt { get; set; }
        [DisplayName("Current Semester/Year")]
        public Nullable<int> CurrentSemester_Year { get; set; }
        public Nullable<int> RequestStatusId { get; set; }
    
        public virtual Institute Institute { get; set; }
        public virtual RequestStatu RequestStatu { get; set; }
    }
}
