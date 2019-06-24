using DemoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DemoWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [RoutePrefix("")]
    public class PatientController : ApiController
    {
            testEntities db ;
        public PatientController()
        {
            db = new testEntities();
        }
        [HttpGet]
        public HttpResponseMessage PatientList() {
            List<Patient> customerList = db.Patients.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, customerList);
        }
        [HttpPost]
        public HttpResponseMessage AddPatient([FromBody]Patient patient)
        {
            try
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, patient);
            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError);
                throw;
            }
            
            
        }
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}