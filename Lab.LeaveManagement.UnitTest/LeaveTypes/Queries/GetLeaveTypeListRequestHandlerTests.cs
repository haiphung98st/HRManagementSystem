using AutoMapper;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Lab.LeaveManagement.Application.Contracts.Persistence;
using Lab.LeaveManagement.Application.DTOs.LeaveType;
using Lab.LeaveManagement.Application.Features.LeaveType.Handlers.Queries;
using Lab.LeaveManagement.Application.Features.LeaveType.Requests.Queries;
using Lab.LeaveManagement.Application.Profiles;
using Moq;
using Shouldly;
using Xunit;

namespace HR.LeaveManagement.Application.UnitTests.LeaveTypes.Queries
{
    public class GetLeaveTypeListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        public GetLeaveTypeListRequestHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfiles>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypeListRequestHandle(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveTypeDto>>();

            result.Count.ShouldBe(3);
        }
    }
}
