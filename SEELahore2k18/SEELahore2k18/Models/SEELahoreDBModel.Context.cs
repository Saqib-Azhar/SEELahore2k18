﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SEELahoreEntities : DbContext
    {
        public SEELahoreEntities()
            : base("name=SEELahoreEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AmbassadorCategory> AmbassadorCategories { get; set; }
        public virtual DbSet<Ambassador> Ambassadors { get; set; }
        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<CompetitionCoordinator> CompetitionCoordinators { get; set; }
        public virtual DbSet<CompetitionRegistration> CompetitionRegistrations { get; set; }
        public virtual DbSet<ContactU> ContactUs { get; set; }
        public virtual DbSet<EventDate> EventDates { get; set; }
        public virtual DbSet<EventSegment> EventSegments { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Institute> Institutes { get; set; }
        public virtual DbSet<ProudPartner> ProudPartners { get; set; }
        public virtual DbSet<RequestStatu> RequestStatus { get; set; }
        public virtual DbSet<SeasonGallery> SeasonGalleries { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<SEELahoreTeam> SEELahoreTeams { get; set; }
        public virtual DbSet<StallCategory> StallCategories { get; set; }
        public virtual DbSet<StallRequest> StallRequests { get; set; }
        public virtual DbSet<TalentGala> TalentGalas { get; set; }
        public virtual DbSet<VolunteerCategory> VolunteerCategories { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }
    }
}
