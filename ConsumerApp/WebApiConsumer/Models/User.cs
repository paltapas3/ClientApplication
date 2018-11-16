using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApiConsumer.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter Pan")]
        [MaxLength(10 ,ErrorMessage ="MAX Length should be 10 digit")]
        [MinLength(10,ErrorMessage ="Min Length should be 10 digit")]
        public string Pan { get; set; }

        [Required(ErrorMessage = "Please enter A/C type")]
        public string Account_Type { get; set; }

        [Required(ErrorMessage = "Please enter Balance")]
        public int Balance { get; set; }

        [Required(ErrorMessage = "Please enter Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Date of Birth")]
        public string DOB { get; set; }

        [Required(ErrorMessage = "Please enter Account Number")]
        public int AccountNumber { get; set; }
    }
}