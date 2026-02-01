using ITI.DoctorReservation.Modles;

namespace ITI.DoctorReservation.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);

    }
}
