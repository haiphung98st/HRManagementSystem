using AutoMapper;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Lab.LeaveManagement.Application.Contracts.Persistence;
using Lab.LeaveManagement.Application.DTOs.LeaveType;
using Lab.LeaveManagement.Application.Features.LeaveType.Handlers.Commands;
using Lab.LeaveManagement.Application.Features.LeaveType.Requests.Commands;
using Lab.LeaveManagement.Application.Profiles;
using Moq;
using Shouldly;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace HR.LeaveManagement.Application.UnitTests.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private readonly CreateLeaveTypeDto _leaveTypeDto;
        private readonly CreateLeaveTypeCommandHandler _handler;

        public CreateLeaveTypeCommandHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();
            
            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfiles>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);

            _leaveTypeDto = new CreateLeaveTypeDto
            {
                DefaultDays = 15,
                Name = "Test DTO"
            };
        }

        [Fact]
        public async Task Valid_LeaveType_Added()
        {
            var result = await _handler.Handle(new CreateLeaveTypeCommand() { LeaveTypeDto = _leaveTypeDto }, CancellationToken.None);

            var leaveTypes = await _mockRepo.Object.GetAll();

            result.ShouldBeOfType<int>();

            leaveTypes.Count.ShouldBe(3);
        }

        [Fact]
        public async Task InValid_LeaveType_Added()
        {
            _leaveTypeDto.DefaultDays = -1;

            ValidationException ex = await Should.ThrowAsync<ValidationException>
                ( async () =>
                        await _handler.Handle(new CreateLeaveTypeCommand() { LeaveTypeDto = _leaveTypeDto }, CancellationToken.None) 
                );

            var leaveTypes = await _mockRepo.Object.GetAll();
            
            leaveTypes.Count.ShouldBe(3);

            ex.ShouldNotBeNull();
        }
    }
}
