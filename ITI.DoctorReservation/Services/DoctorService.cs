using ITI.DoctorReservation.DTOs;
using ITI.DoctorReservation.Modles;
using ITI.DoctorReservation.Repositories.Interfaces;
using ITI.DoctorReservation.Services.Interfaces;
using System.Runtime.InteropServices;

namespace ITI.DoctorReservation.Services
{
    public class DoctorService: IDoctorService
    {

       private readonly IRepository<Doctor> _repoDoctor;

        public DoctorService(IRepository<Doctor> repoDoctor)
        {
            _repoDoctor=repoDoctor;
        }
        public async Task<DoctorDto> Create(CreateDoctorDto doctorDto)
        {

            /// add some logic 
            var doctorEntity = new Doctor
            {
                Name = doctorDto.Name,
                Specialty = doctorDto.Specialty,
                PhoneNumber = doctorDto.PhoneNumber,
                Description = doctorDto.Description
            };
            _repoDoctor.AddAsync(doctorEntity);
            var createdDoctorDto = new DoctorDto
            {
                Name = doctorEntity.Name,
                Specialty = doctorEntity.Specialty,
                PhoneNumber = doctorEntity.PhoneNumber,
                Description = doctorEntity.Description
            };
            return createdDoctorDto;
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctors()
        {
            var doctors = await _repoDoctor.GetAllAsync();
            var doctorDtos = doctors.Select(d => new DoctorDto
            {
                Id = d.Id,
                Name = d.Name,
                Specialty = d.Specialty,
                PhoneNumber = d.PhoneNumber,
                Description = d.Description
            });
            return doctorDtos;
        }

        public async Task<DoctorDto> GetDoctorById(int id)
        {
            var doctor = await _repoDoctor.GetByIdAsync(id);
            var doctorDto = new DoctorDto
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Specialty = doctor.Specialty,
                PhoneNumber = doctor.PhoneNumber,
                Description = doctor.Description
            };
            return doctorDto;
        }

        public async Task<DoctorDto> Update(UpdateDoctorDto doctorDto)
        {
            var doctorEntity = new Doctor
            {
                Id = doctorDto.Id,
                Name = doctorDto.Name,
                Specialty = doctorDto.Specialty,
                PhoneNumber = doctorDto.PhoneNumber,
                Description = doctorDto.Description
            };
            _repoDoctor.UpdateAsync(doctorEntity);
            var updatedDoctorDto = new DoctorDto
            {
                Id = doctorEntity.Id,
                Name = doctorEntity.Name,
                Specialty = doctorEntity.Specialty,
                PhoneNumber = doctorEntity.PhoneNumber,
                Description = doctorEntity.Description
            };
            return updatedDoctorDto;
        }
    }
}
