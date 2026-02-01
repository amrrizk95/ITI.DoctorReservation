using ITI.DoctorReservation.DTOs;

namespace ITI.DoctorReservation.Services.Interfaces
{
    public interface IAuthService
    {

        Task<AuthResponseDto> Login(LoginRequestDto loginDto);
        Task<AuthResponseDto>  Register(RegisterRequestDto registerDto);
    }
}
