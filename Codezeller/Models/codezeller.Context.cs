﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Codezeller.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class codezellerEntities : DbContext
    {
        public codezellerEntities()
            : base("name=codezellerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Languge> Languges { get; set; }
        public virtual DbSet<task> tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserTask> UserTasks { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BlogContent> BlogContents { get; set; }
    }
}
