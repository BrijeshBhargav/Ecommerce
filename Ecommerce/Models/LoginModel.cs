using System.ComponentModel.DataAnnotations;
using System.Web;
namespace Ecommerce.Models
{

    public class LoginModel
    {
        [Required(ErrorMessage = "Email can't be empty")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}", ErrorMessage = "Invalid email")]
        public string EmailID { get; set; }
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Password must contain at least six characters,a capital letter,a symbol,and a number")]
        public string Password { get; set; }
    }
    public class Register
    {
        public string name { get; set; }
        public string emailid { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
    }
    public class Products
    {
        [Required]
        public int P_ID { get; set; }
        [Required]
        public string P_Name { get; set; }


        [Required]
        public int P_Price { get; set; }
        public string Names { get; set; }
        public string ContentType { get; set; }

        public byte[] Data { get; set; }


    }
    public class Uploads
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
