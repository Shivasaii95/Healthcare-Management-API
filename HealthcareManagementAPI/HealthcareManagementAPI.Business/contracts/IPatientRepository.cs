using HealthcareManagementAPI.Models.Entities;

namespace HealthcareManagementAPI.Business.contracts
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();

        Task<Patient?> GetPatientById(int id);

        Task<Patient> CreatePatientAsync(Patient patient);
    }
}