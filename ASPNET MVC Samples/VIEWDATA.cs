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
    
    public partial class VIEWDATA
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Datetime { get; set; }
        public string Station { get; set; }
        public string Tempreture { get; set; }
        public string Humidity { get; set; }
        public string SetTempreture { get; set; }
        public string SetHumidity { get; set; }
    
        public virtual StationName StationName { get; set; }
    }
}
