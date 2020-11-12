using ERPApplicationWebService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ERPApplicationWebService.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using ERPApplicationWebService.ViewModels.ERPApplicationWebService.ViewModels;


namespace ERPApplicationWebService.Controllers
{
     [Authorize]
    public class ClientsController : ApiController
    {
        ERPWeb_WorldTransEntities db = new ERPWeb_WorldTransEntities();

        public IHttpActionResult Get([FromUri]int PageSize,[FromUri] int Start)
        {
            var model = new
            {
                Data = db.Contacts.Where(a => a.Contact_Type_ID_FK == 1)
                .OrderBy(a => a.Contact_ID)
                .Skip(PageSize * Start)
                .Take(PageSize).Select(a => new { id = a.Contact_ID, Phone = a.Contact_Phone1, Fax = a.Contact_Fax, Client = a.Contact_Name, Image = a.Contact_Logo })
                .ToList().Select(a => new { a.id , a.Client , a.Fax , a.Phone , Image = Helpers.Helpers.ConvertImageFromByteArrayToBase64( a.Image)}),
                TotalCount = db.Contacts.Where(a => a.Contact_Type_ID_FK == 1).Count()
            };

          return  Ok(model);
           
        }
        /// <summary>
        /// Post Client Method
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public IHttpActionResult Post(ClientPostViewModel viewModel)
        {
            string userId =  User.Identity.GetUserId();
            var employee = db.Employees.FirstOrDefault(a => a.User_ID_FK == userId);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var contact = FillTheContact(viewModel,employee);
            FillPersonalInCharge(viewModel, contact);
            FillNetWork(viewModel, contact);
            FillFirstBalanceContact(viewModel, contact);
            db.Contacts.Add(contact);
            db.SaveChanges();

            return Ok(viewModel);
             
        }


        public IHttpActionResult GetByID([FromUri] int ?ID){
            if (ID == null)
                return BadRequest();

            var client = db.Contacts.Include(a => a.Contact_PICs)
                         .Include(a => a.Employee)
                         .Include(a => a.Contact_IN_Group)
                         .Include(a => a.FirstBlanceContacts).FirstOrDefault(a => a.Contact_ID == ID);

            if (client == null)
                return NotFound();
            

           return Ok(MapContactsToContactViewModel(client));

        }

        

        #region Methods In Post Method 
     
        private static Contact FillTheContact(ClientPostViewModel viewModel , Employee employee)
        {

           
            var contact = new Contact()
            {
                CountryID = viewModel.CountryID,
                Employee_ID_FK = viewModel.Sales,
                Contact_EMail = viewModel.Email,
                Contact_Fax = viewModel.Fax,
                Contact_Name = viewModel.ClientName,
                Commercial_Register = viewModel.CommercialRegister,
                Contact_Address = viewModel.ClientAddress,
                Contact_Billing_Address = viewModel.ClientBillingAddress,
                Contact_BL_Address = viewModel.ClientLinesBLAddress,
                Contact_Credit_Days = viewModel.ClientCredit.Day,
                Contact_Credit_Limit = viewModel.ClientCredit.Limit,
                Contact_Phone1 = viewModel.ClientPhone,
                Contact_Phone2 = viewModel.ClientPhone2,
                Ref_Contract = viewModel.ReferenceContract,
                Tax_Certificate = viewModel.TaxCertificate,
                Contact_Type_ID_FK = 1,
                Prevent_Client_F_Operation = viewModel.PreventClientFromOperation ? 1 : 0,
                Bank_Details = viewModel.BankDetails,
                Contact_WebSite = viewModel.WebSite,
                IsAirline = viewModel.IsRevalue,
                Created_Date = DateTime.Now.Date,
                Contact_Logo = Helpers.Helpers.ConvertImageFromBase64ToByteArray(viewModel.Image),
                AccID = viewModel.Accts,
                Last_update = DateTime.Now.Date,
                Created_by = employee == null ? 0 : Convert.ToInt32(employee.Employee_ID),
                Updated_by = employee == null ? 0 : Convert.ToInt32(employee.Employee_ID),
                
               
                


            };
            return contact;
        }

        private static void FillNetWork(ClientPostViewModel viewModel, Contact contact)
        {
            foreach (var item in viewModel.NetWork)
            {
                contact.Contact_IN_Group.Add(new Contact_IN_Group()
                {
                    Group_ID_FK = item.group,
                    ExpireDate = item.expireDate
                });
            }
        }

        private static void FillPersonalInCharge(ClientPostViewModel viewModel, Contact contact)
        {
            foreach (var item in viewModel.PersonalInCharge)
            {
                contact.Contact_PICs.Add(new Contact_PICs()
                {
                    Contact_PIC_Title = item.title,
                    Contact_PIC_EMail = item.email,
                    Contact_PIC_Name = item.name,
                    Contact_PIC_Phone = item.phone1,
                    Contact_PIC_Phone2 = item.phone2,
                    Created_Date = DateTime.Now.Date,
                    Last_update = DateTime.Now.Date,
                });
            }
        }

        private static void FillFirstBalanceContact(ClientPostViewModel ViewModel , Contact  contact)
        {
            foreach (var item in ViewModel.FirstBalance)
            {
                contact.FirstBlanceContacts.Add(new FirstBlanceContact()
                {
                    Contact_Balance_Currency = item.balanceCurrency,
                    Contact_Balance_Name = item.contactBalance

                });
            }

        }
        #endregion

        #region Get Methods

        private static ClientGetViewModel MapContactsToContactViewModel(Contact contact)
        {
            var ContactViewModel = new ClientGetViewModel()
            {
                ID = contact.Contact_ID,
                CountryID = contact.CountryID,
                Sales = Convert.ToInt32(contact.Employee_ID_FK),
                Email = contact.Contact_EMail,
                Fax = contact.Contact_Fax,
                ClientName = contact.Contact_Name,
                CommercialRegister = contact.Commercial_Register,
                ClientAddress = contact.Contact_Address,
                ClientBillingAddress = contact.Contact_Billing_Address,
                ClientLinesBLAddress = contact.Contact_BL_Address,
                ClientPhone = contact.Contact_Phone1,
                ClientPhone2 = contact.Contact_Phone2,
                ReferenceContract = contact.Ref_Contract,
                TaxCertificate = contact.Tax_Certificate,
                Contact_Type_ID_FK = contact.Contact_Type_ID_FK.Value,
                PreventClientFromOperation = Convert.ToBoolean(contact.Prevent_Client_F_Operation),
                BankDetails = contact.Bank_Details,
                WebSite = contact.Contact_WebSite,
                IsRevalue = contact.IsAirline,
                Image = Helpers.Helpers.ConvertImageFromByteArrayToBase64(contact.Contact_Logo),

            };
            ContactViewModel.NetWork = new List<NetWork>();
            foreach (var item in contact.Contact_IN_Group)
	        {
                ContactViewModel.NetWork.Add(new NetWork()
                {
                    group = item.Group_ID_FK,
                    expireDate = item.ExpireDate.Value
                });
	        }
            ContactViewModel.PersonalInCharge = new List<PersonalInCharge>();
            foreach (var item in contact.Contact_PICs)
            {
                ContactViewModel.PersonalInCharge.Add(new PersonalInCharge()
                {
                    email = item.Contact_PIC_EMail,
                    name = item.Contact_PIC_Name ,
                    phone1 = item.Contact_PIC_Phone,
                    phone2 = item.Contact_PIC_Phone2,
                    title= item.Contact_PIC_Title
                });
                
            }
            ContactViewModel.FirstBalance = new List<FirstBalance>();
            foreach (var item in contact.FirstBlanceContacts)
            {
                ContactViewModel.FirstBalance.Add(new FirstBalance()
                {
                    balanceCurrency = item.Contact_Balance_Currency.Value,
                    contactBalance = item.Contact_Balance_Name.Value
                });
            }


            return ContactViewModel;
           

          
           

        }


        #endregion
    }
}
