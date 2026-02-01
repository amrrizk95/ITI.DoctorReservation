using System.Net;

namespace ITI.DoctorReservation.DTOs
{
    public class AuthResponseDto
    {
        public string MessageCode { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}
