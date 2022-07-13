using AutoMapper;
using Lab.LeaveManagement.Application.DTOs.LeaveAllocation;
using Lab.LeaveManagement.Application.Features.LeaveAllocation.Requests.Queries;
using Lab.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LeaveManagement.Application.Features.LeaveAllocation.Handlers.Queries
{
    public class GetLeaveAllocationListRequestHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAlloationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationListRequestHandler(ILeaveAllocationRepository leaveAlloationRepository,IMapper mapper)
        {
            _leaveAlloationRepository = leaveAlloationRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAlloationRepository.GetAll();
            return _mapper.Map<List<LeaveAllocationDto>>(leaveAllocation);
        }
    }
}
