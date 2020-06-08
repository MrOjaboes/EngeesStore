using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using VidlyApp.Models;


namespace VidlyApp.Controllers.Api
{
    public class CustomerController : ApiController
    {
        private VidlyAppContext _db = new VidlyAppContext();
        // GET: api/Customer
        public IEnumerable<Customer> GetCustomers()
        {
            return  _db.Customers.ToList();
             
        }

        // GET: api/Customer/5
        public IHttpActionResult  GetCustomer(int id)
        {
            var customer = _db.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(customer);
            
        }

        // POST: api/Customer
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _db.Customers.Add(customer);
            _db.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customer);

        }

        // PUT: api/Customer/5
        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var CustomerInDb = _db.Customers.FirstOrDefault(c => c.Id == id);
            if (CustomerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            CustomerInDb.Name = customer.Name;
            CustomerInDb.Email = customer.Email;
            CustomerInDb.Birthdate = customer.Birthdate;
            CustomerInDb.MembershipTypeId = customer.MembershipTypeId;
            CustomerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            _db.SaveChanges();
            return Ok(customer);
        }

        // DELETE: api/Customer/5
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteCustomer(int id, Customer customer)
        {
            var CustomerInDb = _db.Customers.FirstOrDefault(c => c.Id == id);
            if (CustomerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _db.Customers.Remove(CustomerInDb);
            _db.SaveChanges();
            return Ok(customer);
        }
    }
}
