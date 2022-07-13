using AutoMapper;
using Lab.LeaveManagement.Application.DTOs.LeaveType;
using Lab.LeaveManagement.Application.Features.LeaveType.Requests.Queries;
using Lab.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LeaveManagement.Application.Features.LeaveType.Handlers.Queries
{
    public class GetLeaveTypeDetailRequestHandle : IRequestHandler<GetLeaveTypeDetailRequest, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeReponsitory;
        private readonly IMapper _mapper;

        public GetLeaveTypeDetailRequestHandle(ILeaveTypeRepository leaveTypeReponsitory, IMapper mapper)
        {
            _leaveTypeReponsitory = leaveTypeReponsitory;
            _mapper = mapper;
        }

        public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeReponsitory.Get(request.Id);
            return _mapper.Map<LeaveTypeDto>(leaveType);
        }
    }
}
