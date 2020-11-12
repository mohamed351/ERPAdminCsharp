using ERPApplicationWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERPApplicationWebService.Controllers
{
    public class CurrenciesController : ApiController
    {
        ERPWeb_WorldTransEntities db = new ERPWeb_WorldTransEntities();
       
        public IEnumerable<Currency> Get()
        {

            return db.Currencies.ToList();
        }
        public IHttpActionResult Post([FromBody]Currency curreny)
        {
            if (ModelState.IsValid)
            {
                db.Currencies.Add(curreny);
                db.SaveChanges();
                return Ok<Currency>(curreny);
            }
            else
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Get(int? ID)
        {
            if (ID == null)
                return BadRequest();

            var currency = db.Currencies.FirstOrDefault(a => a.crrID == ID);
            if (currency == null)
            {
                return NotFound();
            }
            return Ok<Currency>(currency);

        }
        public IHttpActionResult Put([FromUri]int? ID,[FromBody] Currency currency) {
            if (ID == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
           var currentCurrency =  db.Currencies.FirstOrDefault(a => a.crrID == ID);
           if (currency == null)
           {
               return NotFound();
           }
           currentCurrency.crrNAME = currency.crrNAME;
           currentCurrency.crrNAMEE = currency.crrNAMEE;
           currentCurrency.crrSymbol = currency.crrSymbol;
           currentCurrency.DfltCrncy = currency.DfltCrncy;
           currentCurrency.Fdate = currency.Fdate;
           currentCurrency.ROE = currency.ROE;
          

           //db.Entry<Currency>(currency).State = System.Data.Entity.EntityState.Modified;
           db.SaveChanges();

           return Ok(currency);

        }

        public IHttpActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return BadRequest();
            }
            var currentCurrency = db.Currencies.FirstOrDefault(a => a.crrID == ID);
            if (currentCurrency == null)
            {
                return NotFound();
            }

            db.Currencies.Remove(currentCurrency);
            return Ok(currentCurrency);

        }




    }
}
