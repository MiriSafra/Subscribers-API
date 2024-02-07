using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Data.Entities
{
    [Table("subscriber ")]
    public  class Subscribers
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [MinLength(2)]
        public string FirstName { get; set; }
        [MinLength(2)]
        public string LastName { get; set; }
        [RegularExpression("^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,})$", ErrorMessage = "the email is not valid")]
        public string? Email { get; set; }
        [MaxLength(10)]
        [MinLength(5)]  
        public string Password { get; set; }

        public static object AnyAsync(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
