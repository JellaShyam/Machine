//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class AMS_Event_Latest
    {
        public int Id { get; set; }
        public System.DateTime EventDateTime { get; set; }
        public string SiteId { get; set; }
        public int AMSEventId { get; set; }
    
        public virtual AMS_Event AMS_Event { get; set; }
    }
}