using AutoMapper;
using HealthcareManagementAPI.Models.DTOs.Patient;
using HealthcareManagementAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareManagementAPI.Business.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<CreatePatientRequestDto, Patient>().ReverseMap();

            CreateMap<Patient, PatientResponseDto>().ReverseMap();

            CreateMap<UpdatePatientRequestDto, Patient>().ReverseMap();
        }
    }
}
