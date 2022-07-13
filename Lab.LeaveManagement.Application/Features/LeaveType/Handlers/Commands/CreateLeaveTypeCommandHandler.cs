using AutoMapper;
using Lab.LeaveManagement.Application.DTOs.LeaveType.Validators;
using Lab.LeaveManagement.Application.Features.LeaveType.Requests.Commands;
using Lab.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.LeaveManagement.Application.Responses;

namespace Lab.LeaveManagement.Application.Features.LeaveType.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandReponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeReponsitory;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeReponsitory, IMapper mapper)
        {
            _leaveTypeReponsitory = leaveTypeReponsitory;
            _mapper = mapper;
        }
        public async Task<BaseCommandReponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new Responses.BaseCommandReponse();
            var validator = new CreateLeaveTypeDtoValadator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var leaveType = _mapper.Map<Domain.LeaveType>(request.LeaveTypeDto);

                leaveType = await _leaveTypeReponsitory.Add(leaveType);

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = leaveType.Id;
            }

            return response;
        }
    }
}
