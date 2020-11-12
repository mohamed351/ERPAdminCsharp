using ERPApplicationWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERPApplicationWebService.Controllers
{
    public class CountriesController : ApiController
    {
        ERPWeb_WorldTransEntities db = new ERPWeb_WorldTransEntities();

        /// <summary>
        /// Get Top 5 Countries
        /// </summary>
        /// <param name="name">country Name or Character that contains the Name</param>
        /// <returns>Collection of Countries </returns>
        public IHttpActionResult Get(string name = "")
        {
             name = name == null ? "" : name;
            var query = db.Countries.Where(a => a.Country_Name.Contains(name))
                 .OrderBy(a => a.Country_Name)
                 .Skip(0)
                 .Take(5)
                 .Select(a => new { a.Country_ID, a.Country_Name })
                 .ToList();
            return Ok(query.ToList());
        }

    }
}
