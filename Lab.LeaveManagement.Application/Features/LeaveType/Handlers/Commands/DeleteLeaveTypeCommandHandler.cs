using AutoMapper;
using Lab.LeaveManagement.Application.Exceptions;
using Lab.LeaveManagement.Application.Features.LeaveType.Requests.Commands;
using Lab.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LeaveManagement.Application.Features.LeaveType.Handlers.Commands
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeReponsitory;
        private readonly IMapper _mapper;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeReponsitory, IMapper mapper)
        {
            _leaveTypeReponsitory = leaveTypeReponsitory;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveTypeReponsitory.Get(request.Id);
            if (leaveRequest == null)
                throw new NotFoundException(nameof(LeaveType), request.Id);
            await _leaveTypeReponsitory.Delete(leaveRequest);
            return Unit.Value;
        }
    }
}
