using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OA_DAL.Models;
using OA_Service.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI2.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {

        private readonly ILogger<ApplicantController> _logger;
        private readonly ApplicantAppService _applicantAppService;
        private readonly IHttpClientFactory _httpClientFactory;
        

        public ApplicantController(ILogger<ApplicantController> logger, ApplicantAppService applicantAppService, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _applicantAppService = applicantAppService;
            _httpClientFactory = httpClientFactory;
        }
       /* public async Task<bool> CheckCountryNameAsync(string country) 
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://restcountries.com/v2/name/"+ country.Trim().ToLower());
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        */
        // GET: api/<ApplicantController>
        [HttpGet]
        public IActionResult Get()
        {
            var applicants = _applicantAppService.GetAllApplicants();
            if (applicants.Count == 0) 
            {
                return NotFound();
            }
            return Ok(applicants);
        }

        // GET api/<ApplicantController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var applicant = _applicantAppService.GetById(id);
            if (applicant == null) 
            {
                return NotFound();
            }
            return Ok(applicant);
        }

        // POST api/<ApplicantController>
        [HttpPost]
        public IActionResult Post(Applicant applicant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //if (!CheckCountryNameAsync(applicant.CountryOfOrigin).Result) 
                //{
                //    return BadRequest("The Country Name is invalid");
                //}
                _applicantAppService.SaveNewApplicant(applicant);
                return CreatedAtAction(nameof(Get), new { id = applicant.ID }, applicant);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ApplicantController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Applicant applicant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var applicantupdate = _applicantAppService.GetById(id);
                //if (!CheckCountryNameAsync(applicant.CountryOfOrigin).Result)
                //{
                //    return BadRequest("The Country Name is invalid");
                //}
                applicantupdate.Address = applicant.Address;
                applicantupdate.Age = applicant.Age;
                applicantupdate.CountryOfOrigin = applicant.CountryOfOrigin;
                applicantupdate.FamilyName = applicant.FamilyName;
                applicantupdate.Name = applicant.Name;
                applicantupdate.EMailAdress = applicant.EMailAdress;
                _applicantAppService.UpdateApplicant(applicantupdate);
                return CreatedAtAction(nameof(Get), new { id = applicant.ID }, applicant);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Hired/{id}")]
        public IActionResult Hired(int id) 
        {
            var applicant = _applicantAppService.GetById(id);
            if (applicant == null)
            {
                return NotFound();
            }
            try
            {
                applicant.Hired = true;
                _applicantAppService.UpdateApplicant(applicant);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("unHired/{id}")]
        public IActionResult unHired(int id)
        {
            var applicant = _applicantAppService.GetById(id);
            if (applicant == null)
            {
                return NotFound();
            }
            try
            {
                applicant.Hired = false;
                _applicantAppService.UpdateApplicant(applicant);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<ApplicantController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var applicant = _applicantAppService.GetById(id);
            if (applicant == null)
            {
                return NotFound();
            }
            try
            {
                _applicantAppService.DeleteApplicant(applicant.ID);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
