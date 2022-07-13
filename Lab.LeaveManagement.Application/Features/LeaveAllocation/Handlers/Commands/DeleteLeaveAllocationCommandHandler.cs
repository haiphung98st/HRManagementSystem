using AutoMapper;
using Lab.LeaveManagement.Application.Exceptions;
using Lab.LeaveManagement.Application.Features.LeaveAllocation.Requests.Commands;
using Lab.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LeaveManagement.Application.Features.LeaveAllocation.Handlers.Commands
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand>
    {
        private readonly ILeaveAllocationRepository _leaveAlloationRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAlloationRepository, IMapper mapper)
        {
            _leaveAlloationRepository = leaveAlloationRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAlloationRepository.Get(request.Id);
            if (leaveAllocation == null)
                throw new NotFoundException(nameof(leaveAllocation), request.Id);
            await _leaveAlloationRepository.Delete(leaveAllocation);
            return Unit.Value;  
        }
    }
}
