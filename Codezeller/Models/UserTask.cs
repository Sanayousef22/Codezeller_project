//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class UserTask
    {
        public int id { get; set; }
        public int userID { get; set; }
        public bool open { get; set; }
        public int taskID { get; set; }
    
        public virtual task task { get; set; }
        public virtual User User { get; set; }
    }
}
