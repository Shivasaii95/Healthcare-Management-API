using HealthcareManagementAPI.Business.contracts;
using HealthcareManagementAPI.DataAccess;
using HealthcareManagementAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthcareManagementAPI.Business.Implementation
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext Context)
        {
            _context = Context;
        }

        public async  Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients.Where(x=>!x.IsDeleted).ToListAsync();
        }


        public async Task<Patient?> GetPatientById(int id)
        {
            return await _context.Patients.FirstOrDefaultAsync(x =>
                                                x.PatientId == id && !x.IsDeleted);
        }

        public async Task<bool> IsPatientExistsAsync(string firstName,string lastName,DateTime dateOfBirth)
        {
            var isExist = await _context.Patients.AnyAsync(x => !x.IsDeleted && x.FirstName == firstName
                                                                  && x.LastName == lastName && x.DateOfBirth == dateOfBirth);
            return isExist;
        }

        public async Task<Patient> CreatePatientAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);

            await _context.SaveChangesAsync();

            return patient;
        }

        public async Task  UpdatePatientAsync(Patient patient)
        {
            patient.UpdatedDate = DateTime.UtcNow;
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePatientAsync(Patient patient)
        {
            patient.IsDeleted = true;

            patient.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }
    }
}
