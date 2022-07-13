using AutoMapper;
using Lab.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
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
    public class CreateLeaveAllocationCommandHandlers : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveAllocationRepository _leaveTypeReponsitory;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationCommandHandlers(ILeaveAllocationRepository leaveTypeReponsitory, IMapper mapper)
        {
            _leaveTypeReponsitory = leaveTypeReponsitory;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationDtoValidator();
            var validatorResult = await validator.ValidateAsync(request.CreateLeaveAllocationDto);
            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult);
            var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request.CreateLeaveAllocationDto);
            leaveAllocation = await _leaveTypeReponsitory.Add(leaveAllocation);
            return leaveAllocation.Id;
        }
    }
}
