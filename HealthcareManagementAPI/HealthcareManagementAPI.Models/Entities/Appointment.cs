using HealthcareManagementAPI.Models.Common;
using HealthcareManagementAPI.Models.Enums;

namespace HealthcareManagementAPI.Models.Entities
{
    public class Appointment : BaseEntity
    {
        public int AppointmentId { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string Reason { get; set; } = string.Empty;

        public AppointmentStatus Status { get; set; }

        // Navigation Properties
        public Patient Patient { get; set; } = null!;

        public Doctor Doctor { get; set; } = null!;
    }
}