using AutoMapper;
using HealthcareManagementAPI.Business.contracts;
using HealthcareManagementAPI.Models.DTOs.Patient;
using HealthcareManagementAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareManagementAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        private readonly IMapper _mapper;

        public PatientController(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
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

            var Response = _mapper.Map<List<PatientResponseDto>>(patients);

            return Ok(new
            {
                message = "patient data retrived successfully",
                Data = patients

            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetPatientById(int id)
        {
            var patient = await _patientRepository.GetPatientById(id);
            if (patient == null)
            {
                return NotFound(new
                {
                    message = "Patient Not Found"
                });
            }
            var response = _mapper.Map<PatientResponseDto>(patient);

            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> AddPatient(CreatePatientRequestDto request)
        {
            var patientExists = await _patientRepository.IsPatientExistsAsync(request.FirstName,request.LastName,request.DateOfBirth);

            if (patientExists)
            {
                return BadRequest(new
                {
                    message = "Patient already exists."
                });
            }

            var patient = _mapper.Map < Patient>(request);

            var createPatient = await _patientRepository.CreatePatientAsync(patient);

            var response = _mapper.Map<PatientResponseDto>(createPatient);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>UpdatePatient(int id,UpdatePatientRequestDto request)
        {
            var existingPatient= await _patientRepository.GetPatientById(id);


            if (existingPatient == null)
            {
                return NotFound(new
                {
                    Message = "Patient not found"
                });
            }

            _mapper.Map(request, existingPatient);

            await _patientRepository.UpdatePatientAsync(existingPatient);

            var response = _mapper.Map<PatientResponseDto>(existingPatient);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _patientRepository.GetPatientById(id);

            if (patient == null)
            {
                return NotFound(new
                {
                    Message = "Patient not found"
                });
            }

            await _patientRepository.DeletePatientAsync(patient);

            return Ok(new
            {
                Message = "Patient deleted successfully"
            });
        }
    }
}
