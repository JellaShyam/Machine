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
    
    public partial class MyAppsDemoEvent
    {
        public MyAppsDemoEvent()
        {
            this.MyAppsDemoEvent_Latest = new HashSet<MyAppsDemoEvent_Latest>();
        }
    
        public int Id { get; set; }
        public string SiteId { get; set; }
        public System.DateTime EventDateTime { get; set; }
        public decimal Temperature { get; set; }
        public decimal Vibration { get; set; }
        public decimal Pressure { get; set; }
        public decimal Sensor4 { get; set; }
        public decimal Sensor5 { get; set; }
        public decimal Sensor6 { get; set; }
        public decimal Sensor7 { get; set; }
        public decimal Sensor8 { get; set; }
        public decimal Sensor9 { get; set; }
        public decimal Sensor10 { get; set; }
        public decimal Sensor11 { get; set; }
        public decimal Sensor12 { get; set; }
        public int RishMasterEventId { get; set; }
    
        public virtual ICollection<MyAppsDemoEvent_Latest> MyAppsDemoEvent_Latest { get; set; }
        public virtual RishMasterEvent RishMasterEvent { get; set; }
    }
}
