using FluentValidation;

namespace Lab.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeDtoValadator : AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeDtoValadator()
        {
            Include(new ILeaveTypeDtoValidator());
        }
    }
}
