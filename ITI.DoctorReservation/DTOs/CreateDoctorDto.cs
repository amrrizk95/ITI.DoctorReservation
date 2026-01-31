using System.ComponentModel.DataAnnotations;

namespace ITI.DoctorReservation.DTOs
{
    public class CreateDoctorDto
    {
        [Required]
        public string Name { get; set; }
        public string Specialty { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
    }
}
