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
    public class GetLeaveTypeListRequestHandle : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeReponsitory;
        private readonly IMapper _mapper;

        public GetLeaveTypeListRequestHandle(ILeaveTypeRepository leaveTypeReponsitory, IMapper mapper)
        {
            _leaveTypeReponsitory = leaveTypeReponsitory;
            _mapper = mapper;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeReponsitory.GetAll();
            return _mapper.Map<List<LeaveTypeDto>>(leaveType);
        }
    }
}
