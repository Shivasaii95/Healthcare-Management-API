using HealthcareManagementAPI.Business.contracts;
using HealthcareManagementAPI.DataAccess;
using HealthcareManagementAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public async Task<Patient> CreatePatientAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);

            await _context.SaveChangesAsync();

            return patient;
        }
    }
}
