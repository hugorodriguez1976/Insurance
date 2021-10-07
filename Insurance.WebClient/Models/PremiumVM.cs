using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Insurance.WebClient.Models
{
    public class PremiumVM
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [Required]
        [DisplayName("Date of bith")]
        public DateTime Dob { get; set; }
        
        public int Age { get; set; }

        [Required]
        [DisplayName("Occupation")]
        public int OccupationId { get; set; }

        [Required]
        [DisplayName("Death Insurance Amount")]
        [Range(1, 999999999.00)]
        public double Amount { get; set; }

        [DisplayName("Premium Amount")]
        public double PremiumAmount { get; set; }
        
        public List<SelectListItem> OccupationForList { get; set; }
    }
}