using Lab.LeaveManagement.Application.DTOs.LeaveRequest;
using Lab.LeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LeaveManagement.Application.Features.LeaveRequest.Requests.Commands
{
    public class CreateLeaveRequestCommand : IRequest<BaseCommandReponse>
    {
        public CreateLeaveRequestDto LeaveRequestDto { get; set; }
    }
}
