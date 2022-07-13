using Lab.LeaveManagement.Application.Models.Identity;

namespace Lab.LeaveManagement.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Registration(RegistrationRequest request);
    }
}
