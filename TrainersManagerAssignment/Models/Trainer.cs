using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainersManagerAssignment.Models
{
    public class Trainer
    {
        public int ID { get; set; }
        [StringLength(60,MinimumLength =2,ErrorMessage ="A name cannot be longer than 60 characters")]
        [Required(ErrorMessage ="A First Name is required to proceed")]
        public string FirstName { get; set; }
        [StringLength(60, MinimumLength = 2, ErrorMessage = "A last name cannot be longer than 60 characters")]
        [Required(ErrorMessage = "A Last Name is required to proceed")]
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{ FirstName}{ LastName}";
            }
        }
        [StringLength(30,MinimumLength =2)]
        public string Subject { get; set; }
    }
}