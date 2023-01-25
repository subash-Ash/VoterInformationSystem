using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VoterInformationSystemApplication.Models
{
    public class Voter
    {
        [Required]
        public int VoterId { get; set; }

        [Required]
        [StringLength(75, ErrorMessage = "Name should be less than 76 Characters")]

        public string VoterName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Date of Birth(MM/DD/YYYY)")]
        public Nullable<System.DateTime> DOB { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Name should be less than 15 Characters")]
        public string Gender { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string EmailId { get; set; }

        [Required]
        public Nullable<long> MobileNumber { get; set; }
    }
}