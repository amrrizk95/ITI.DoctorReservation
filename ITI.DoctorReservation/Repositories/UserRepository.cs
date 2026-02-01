using ITI.DoctorReservation.Modles;
using ITI.DoctorReservation.Repositories.Interfaces;
using ITI.DoctorReservation.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ITI.DoctorReservation.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DoctorsDbContext _context;

        public UserRepository(DoctorsDbContext context)
        {
                _context = context;
        }
        public async Task<User> AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByUserName(string userName)
        {
            var user =await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == userName||u.Email==userName);
            return user!;
        }

        public Task<User?> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
