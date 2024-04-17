using System.ComponentModel.DataAnnotations;

namespace StudentData.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]  
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} characters", MinimumLength = 8)]
        [RegularExpression(@"^([a-zA-Z0-9@*#]{8,15})$", ErrorMessage = "Password must contain: Minimum 8 characters, at least 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number, and 1 Special Character")]
        public string Password { get; set; }


        //[Display(Name = "Confirm password")]
        //[Required(ErrorMessage = "Please enter confirm password")]
        //[Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again!")]
        //[DataType(DataType.Password)]
        //public string Confirmpwd { get; set; }



        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please Select the gender")]
        public string Gender { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        public string Email { get; set; }

        //[DataType(DataType.PhoneNumber)]
        //[Display(Name = "Phone Number")]
        //[Required(ErrorMessage = "Phone Number Required!")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})", ErrorMessage = "Entered phone format is not valid.")]
        //public string PhoneNumber { get; set; }

        //public List<Student> student { get; set; }
    }
}
