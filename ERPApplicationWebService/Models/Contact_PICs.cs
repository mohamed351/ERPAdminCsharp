//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERPApplicationWebService.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contact_PICs
    {
        public int Contact_PIC_ID { get; set; }
        public string Contact_PIC_Title { get; set; }
        public string Contact_PIC_Name { get; set; }
        public string Contact_PIC_Phone { get; set; }
        public string Contact_PIC_Phone2 { get; set; }
        public string Contact_PIC_EMail { get; set; }
        public Nullable<int> Contact_ID_FK { get; set; }
        public Nullable<System.DateTime> Created_Date { get; set; }
        public Nullable<System.DateTime> Last_update { get; set; }
        public Nullable<int> Created_by { get; set; }
        public Nullable<int> Updated_by { get; set; }
    
        public virtual Contact Contact { get; set; }
    }
}
