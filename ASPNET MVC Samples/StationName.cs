//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASPNET_MVC_Samples
{
    using System;
    using System.Collections.Generic;
    
    public partial class StationName
    {
        public StationName()
        {
            this.UserLogins = new HashSet<UserLogin>();
            this.VIEWDATAs = new HashSet<VIEWDATA>();
        }
    
        public int Id { get; set; }
        public string StationName1 { get; set; }
    
        public virtual ICollection<UserLogin> UserLogins { get; set; }
        public virtual ICollection<VIEWDATA> VIEWDATAs { get; set; }
    }
}
