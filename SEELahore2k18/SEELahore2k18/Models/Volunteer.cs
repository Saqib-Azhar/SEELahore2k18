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
    
    using System.ComponentModel;    public partial class Volunteer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Contact No.")] public string ContactNo { get; set; }
        public string FacebookId { get; set; }
        public string EmailId { get; set; }
        public string CNIC { get; set; }
        [DisplayName("Institute")] public Nullable<int> InstituteId { get; set; }
        [DisplayName("Status")] public Nullable<int> StatusId { get; set; }
        [DisplayName("Created At")] public Nullable<System.DateTime> CreatedAt { get; set; }
        public string Address { get; set; }
        [DisplayName("City Of Residence")] public string CityOfResidence { get; set; }
        public string Degree { get; set; }
        [DisplayName("Previous Experiance")] public string PreviousExperiance { get; set; }
       [DisplayName("Volunteer Category")]  public Nullable<int> VolunteerCategoryId { get; set; }
        public Nullable<bool> Hostelite { get; set; }
    
        public virtual Institute Institute { get; set; }
        public virtual RequestStatu RequestStatu { get; set; }
        public virtual VolunteerCategory VolunteerCategory { get; set; }
    }
}
