using AutoMapper;
using Lab.LeaveManagement.MVC.Models;
using Lab.LeaveManagement.MVC.Services.Bases;

namespace Lab.LeaveManagement.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateLeaveTypeDto, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();

        }
    }
}
