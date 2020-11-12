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
    
    public partial class Acct
    {
        public int id { get; set; }
        public long AccID { get; set; }
        public string AccName { get; set; }
        public string AccNameE { get; set; }
        public string AccKind { get; set; }
        public string AccKindE { get; set; }
        public string ctgry1 { get; set; }
        public string ctgry2 { get; set; }
        public string ctgry3 { get; set; }
        public string ctgry4 { get; set; }
        public string ctgry5 { get; set; }
        public string ctgry6 { get; set; }
        public string ctgry1e { get; set; }
        public string ctgry2e { get; set; }
        public string ctgry3e { get; set; }
        public string ctgry4e { get; set; }
        public string ctgry5e { get; set; }
        public string ctgry6e { get; set; }
        public Nullable<int> catg1id { get; set; }
        public Nullable<int> catg2id { get; set; }
        public Nullable<int> catg3id { get; set; }
        public Nullable<int> catg4id { get; set; }
        public Nullable<int> catg5id { get; set; }
        public Nullable<int> catg6id { get; set; }
        public Nullable<double> FDebit { get; set; }
        public Nullable<double> FCredit { get; set; }
        public Nullable<double> Debit { get; set; }
        public Nullable<double> Credit { get; set; }
        public Nullable<double> Balance { get; set; }
        public Nullable<int> TrnsBool { get; set; }
        public Nullable<double> Depreciate { get; set; }
        public Nullable<int> Flag { get; set; }
        public Nullable<int> InitZero { get; set; }
        public Nullable<int> currID { get; set; }
        public Nullable<double> Rate { get; set; }
        public Nullable<int> COSTCAT { get; set; }
        public Nullable<double> FDebitCurr { get; set; }
        public Nullable<double> FCreditCurr { get; set; }
        public Nullable<double> DebitCurr { get; set; }
        public Nullable<double> CreditCurr { get; set; }
        public Nullable<double> BalanceCurr { get; set; }
        public string Notes { get; set; }
        public Nullable<int> KINDID { get; set; }
        public Nullable<double> FBALANCE { get; set; }
        public Nullable<double> FBALANCECURR { get; set; }
        public string REGION { get; set; }
        public Nullable<double> YrBal { get; set; }
        public Nullable<bool> IsCshBnk { get; set; }
        public Nullable<byte> IsClntVndr { get; set; }
        public Nullable<int> EndAccKy { get; set; }
        public Nullable<bool> IsMain { get; set; }
        public Nullable<long> MainAccID { get; set; }
        public Nullable<bool> IsRevalue { get; set; }
        public Nullable<long> NtsAccID { get; set; }
        public Nullable<int> BranchID { get; set; }
        public Nullable<bool> isbank { get; set; }
        public Nullable<bool> iscash { get; set; }
        public Nullable<long> mirroraccid { get; set; }
    }
}