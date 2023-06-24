using System.ComponentModel.DataAnnotations;
using API.Extensions;

namespace API.Entities
{
    public class AppUser
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; }
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Photo> Photo { get; set; } = new();

     //   public int GetAge()
     //   {
      //      return DateOfBirth.CalculateAge();
      //  }
    }
}