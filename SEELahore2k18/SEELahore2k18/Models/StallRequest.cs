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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class StallRequest
    {
        public int Id { get; set; }
        [DisplayName("Stall Name")]
        public string StallName { get; set; }
        public string StallDetails { get; set; }
        public string Logo { get; set; }
        public Nullable<int> RequestStatusId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string OwnerName { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0]{1})\)?([0-9]{3})\)?([0-9]{3})?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]

        public string ContactNo { get; set; }


        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "The email address is not valid")]
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Profession { get; set; }
        public string Institute { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual RequestStatu RequestStatu { get; set; }
        public virtual StallCategory StallCategory { get; set; }
    }
}
