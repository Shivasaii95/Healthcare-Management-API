using HealthcareManagementAPI.Models.Common;
using HealthcareManagementAPI.Models.Enums;

namespace HealthcareManagementAPI.Models.Entities
{
    public class Patient : BaseEntity
    {
        public int PatientId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;


        public ICollection<Appointment>  Appointments { get; set; } = new List<Appointment>();
    }
}