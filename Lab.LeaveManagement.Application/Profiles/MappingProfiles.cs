using AutoMapper;
using Lab.LeaveManagement.Application.DTOs;
using Lab.LeaveManagement.Application.DTOs.LeaveAllocation;
using Lab.LeaveManagement.Application.DTOs.LeaveRequest;
using Lab.LeaveManagement.Application.DTOs.LeaveType;
using Lab.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LeaveManagement.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<LeaveAllocation,LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveRequest,LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest,LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveType,LeaveTypeDto>().ReverseMap();

            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
        }
    }
}
