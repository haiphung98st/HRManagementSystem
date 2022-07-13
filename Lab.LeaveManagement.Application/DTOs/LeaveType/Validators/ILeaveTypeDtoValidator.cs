using FluentValidation;

namespace Lab.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    internal class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} has been exceed 50 characters");

            RuleFor(x => x.DefaultDays)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .GreaterThan(0).WithMessage("{PropertyName} must greater than 0")
            .LessThan(100).WithMessage("{PropertyName} must less than 100");
        }

    }
}