using Lab.LeaveManagement.Application.DTOs.LeaveType;
using Lab.LeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LeaveManagement.Application.Features.LeaveType.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<BaseCommandReponse>
    {
        public CreateLeaveTypeDto LeaveTypeDto { get; set; }
    }
}
