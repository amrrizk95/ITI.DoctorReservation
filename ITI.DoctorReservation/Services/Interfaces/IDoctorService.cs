using ITI.DoctorReservation.DTOs;

namespace ITI.DoctorReservation.Services.Interfaces
{
    public interface IDoctorService
    {

        Task<IEnumerable<DoctorDto>> GetAllDoctors();
        Task<DoctorDto> GetDoctorById(int id);
        Task<DoctorDto> Create(CreateDoctorDto createDoctorDto);
        Task<DoctorDto> Update(UpdateDoctorDto updateDoctorDto);
    }
}
