using ITI.DoctorReservation.Modles;
using ITI.DoctorReservation.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ITI.DoctorReservation.Repositories
{
    public class DoctorRepository : IRepository<Doctor>
    {
        private readonly DoctorsDbContext _context;
        public DoctorRepository(DoctorsDbContext context)
        {
            _context = context;
        }
        public async Task<Doctor> AddAsync(Doctor entity)
        {
            _context.Doctors.Add(entity);

            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor?> GetByIdAsync(int id)
        {
            try
            {
                var doctor = await _context.Doctors.FindAsync(id);
                return doctor;
            }
            catch (Exception e)
            {

                throw;
            }
          
        }

        public async Task<Doctor?> UpdateAsync(Doctor entity)
        {
            var existingDoctor =  _context.Doctors.FirstOrDefault(d => d.Id == entity.Id);
            existingDoctor.Name = entity.Name;
            existingDoctor.Specialty = entity.Specialty;
            existingDoctor.PhoneNumber = entity.PhoneNumber;
            existingDoctor.Description = entity.Description;
            await _context.SaveChangesAsync();
            return existingDoctor;
        }
    }
}
