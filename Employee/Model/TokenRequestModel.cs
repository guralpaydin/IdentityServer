using System.ComponentModel.DataAnnotations;

namespace Employee.Model
{
    public class TokenRequestModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
