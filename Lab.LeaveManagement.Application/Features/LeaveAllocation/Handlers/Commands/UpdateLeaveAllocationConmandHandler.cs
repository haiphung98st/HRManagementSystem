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
    public class UpdateLeaveAllocationConmandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAlloationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationConmandHandler(ILeaveAllocationRepository leaveAlloationRepository,ILeaveTypeRepository leaveTypeRepository ,IMapper mapper )
        {
            _leaveAlloationRepository = leaveAlloationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validatorResult = await validator.ValidateAsync(request.updateLeaveAllocationDto);
            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult);

            var leaveAllocation = await _leaveAlloationRepository.Get(request.updateLeaveAllocationDto.Id);
            _mapper.Map(request.updateLeaveAllocationDto, leaveAllocation);
            await _leaveAlloationRepository.Update(leaveAllocation);
            return Unit.Value;
        }
    }
}
