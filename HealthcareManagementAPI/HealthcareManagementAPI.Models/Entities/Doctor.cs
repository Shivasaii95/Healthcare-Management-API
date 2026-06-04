using HealthcareManagementAPI.Models.Common;

namespace HealthcareManagementAPI.Models.Entities
{
    public class Doctor : BaseEntity
    {
        public int DoctorId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Specialization { get; set; } = string.Empty;

        public int ExperienceYears { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public decimal ConsultationFee { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}