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
            var patient = _mapper.Map<Patient>(request);

            var createPatient = await _patientRepository.CreatePatientAsync(patient);

            var response = _mapper.Map<PatientResponseDto>(createPatient);

            return Ok(response);
        }
    }
}
