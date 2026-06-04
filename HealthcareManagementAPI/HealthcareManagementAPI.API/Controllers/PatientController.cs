using HealthcareManagementAPI.Business.contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareManagementAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {

            var patients = await _patientRepository.GetAllPatientsAsync();

            if (patients == null || !patients.Any())
            {
                return NotFound(new
                {
                    message = " no patients found"
                });
            }

            return Ok(new
            {
                message = "patient data retrived succussfully",
                Data = patients

            });
        }

    }
}
