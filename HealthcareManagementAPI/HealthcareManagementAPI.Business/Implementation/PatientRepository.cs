using HealthcareManagementAPI.Business.contracts;
using HealthcareManagementAPI.DataAccess;
using HealthcareManagementAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            return await _context.Patients.ToListAsync();
        }
    }
}
