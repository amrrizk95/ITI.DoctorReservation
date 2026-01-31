using ITI.DoctorReservation.DTOs;
using ITI.DoctorReservation.Modles;
using ITI.DoctorReservation.Repositories.Interfaces;
using ITI.DoctorReservation.RequestModels;
using ITI.DoctorReservation.Services;
using ITI.DoctorReservation.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ITI.DoctorReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var doctors = await _doctorService.GetAllDoctors();
            return Ok(doctors);
        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            // fixing this bug 
            var doctor = _doctorService.GetDoctorById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDoctorDto doctorDto)
        {
          
            var doctor = await _doctorService.Create(doctorDto);

            return Ok(doctor);
        }


        [HttpPut]
        public IActionResult Update( [FromBody] UpdateDoctorDto doctorDto)
        {
    
            var existingDoctor = _doctorService.Update(doctorDto);
            return Ok(existingDoctor);
        }
    }
}
