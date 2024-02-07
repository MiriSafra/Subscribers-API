using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Data.Entities
{

    [Table("Subscriber")]
    public class Subscribers
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [MinLength(2)]
        public string FirstName { get; set; }
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("/^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,})$/", ErrorMessage = "The email address you entered is invalid")]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*()]).*$")]
        public string Password { get; set; }

    }
}
