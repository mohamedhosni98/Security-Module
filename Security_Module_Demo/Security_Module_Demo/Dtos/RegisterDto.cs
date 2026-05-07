using System.ComponentModel.DataAnnotations;

namespace Security_Module_Demo.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage ="Name is Required")]
        [StringLength(20)]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(20)]
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(40)]
        public string User_Name { get; set; }
        [Required(ErrorMessage ="Email Is Required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
