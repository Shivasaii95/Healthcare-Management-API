using HealthcareManagementAPI.Models.Entities;
using System.Threading.Tasks;

namespace HealthcareManagementAPI.Business.contracts
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();

        Task<Patient?> GetPatientById(int id);

        Task<bool> IsPatientExistsAsync(string firstName, string lastName,DateTime dateOfBirth);

        Task<Patient> CreatePatientAsync(Patient patient);
        Task UpdatePatientAsync(Patient patient);

        Task DeletePatientAsync(Patient patient);
    }
}