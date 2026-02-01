using BCrypt.Net;
using ITI.DoctorReservation.DTOs;
using ITI.DoctorReservation.Modles;
using ITI.DoctorReservation.Repositories.Interfaces;
using ITI.DoctorReservation.Services.Interfaces;
using System.Net;

namespace ITI.DoctorReservation.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJwtService _jwtService;
        private readonly IUserRepository _repository;
        public AuthService(IUserRepository repository, IJwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }
        public async Task<AuthResponseDto> Login(LoginRequestDto loginDto)
        {
            // validate user is exist
            var user = await _repository.GetByUserName(loginDto.Username);
            if (user == null)
            {
                return new AuthResponseDto 
                { 
                    StatusCode=HttpStatusCode.BadRequest,
                    MessageCode= "IVALID_CREDENTIALS"
                };
            }
            // validate password
            var isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.HashedPassword);
            if (!isPasswordValid)
            {
                return new AuthResponseDto
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    MessageCode = "IVALID_CREDENTIALS"
                };
            }
            var token= _jwtService.GenerateToken(user);
            return new AuthResponseDto
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddMinutes(30),
            };
            //var user=await _repository.GetAllAsync();
            // generate token

        }

        public async Task<AuthResponseDto> Register(RegisterRequestDto registerDto)
        {
            // hash password
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
            // add user 

            var user =await _repository.AddAsync(new User
            {
                UserName = registerDto.Username,
                HashedPassword = hashedPassword,
                Role = "User",
                Email = registerDto.Email,              
            });
            // generate token

            var token = _jwtService.GenerateToken(user);

            return new AuthResponseDto
            {
                Token = token,
               Expiration= DateTime.UtcNow.AddMinutes(30),
            };

        }
    }
}
