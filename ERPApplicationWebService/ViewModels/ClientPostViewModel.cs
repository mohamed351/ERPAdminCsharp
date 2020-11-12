using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPApplicationWebService.ViewModels
{
  
    public class PersonalInCharge
    {
        public string title { get; set; }
        public string name { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string email { get; set; }
    }

    public class FirstBalance
    {
        public decimal contactBalance { get; set; }
        public int balanceCurrency { get; set; }
    }

    public class NetWork
    {
        public int group { get; set; }
        public DateTime ?expireDate { get; set; }
    }

    public class ClientCredit
    {
        public int Day { get; set; }
        public int Limit { get; set; }
    }

    public class ClientPostViewModel
    {
      
        public string ClientName { get; set; }
        public int Sales { get; set; }
        public string ClientPhone { get; set; }
        public string ClientPhone2 { get; set; }
        public string TaxCertificate { get; set; }
        public string CommercialRegister { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string ClientAddress { get; set; }
        public string ClientBillingAddress { get; set; }
        public string ReferenceContract { get; set; }
        public string ClientLinesBLAddress { get; set; }
        public string BankDetails { get; set; }
        public string WebSite { get; set; }
        public int? CountryID { get; set; }
        public List<PersonalInCharge> PersonalInCharge { get; set; }
        public List<FirstBalance> FirstBalance { get; set; }
        public List<NetWork> NetWork { get; set; }
        public bool PreventClientFromOperation { get; set; }
        public ClientCredit ClientCredit { get; set; }
        public int Accts { get; set; }
        public bool IsRevalue { get; set; }
        public string Image { get; set; }

       
    }


}