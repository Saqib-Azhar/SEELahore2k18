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
    
    using System.ComponentModel; public partial class TalentGala
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Institute { get; set; }
        public string Degree { get; set; }
        public string CGPA_Numbers { get; set; }
        public string TotalNumbers { get; set; }
        public string CNIC { get; set; }
        public string ContactNo_ { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<int> CurrentSemester_Year { get; set; }
        public Nullable<int> RequestStatusId { get; set; }
    
        public virtual RequestStatu RequestStatu { get; set; }
    }
}