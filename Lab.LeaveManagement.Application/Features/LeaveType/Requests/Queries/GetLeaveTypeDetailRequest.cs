using Lab.LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace Lab.LeaveManagement.Application.Features.LeaveType.Requests.Queries
{
    public class GetLeaveTypeDetailRequest : IRequest<LeaveTypeDto>
    {
        public int Id { get; set; }
    }
}
