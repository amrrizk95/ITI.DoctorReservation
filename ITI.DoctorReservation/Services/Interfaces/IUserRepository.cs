using ITI.DoctorReservation.Modles;
using ITI.DoctorReservation.Repositories.Interfaces;

namespace ITI.DoctorReservation.Services.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        Task<User> GetByUserName(string userName);
    }
}
