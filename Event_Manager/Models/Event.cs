using System;
using System.ComponentModel.DataAnnotations;

namespace Event_Manager.Models
{
    public class Event
    {
        public int Id { get; set;  }

        [Required(ErrorMessage = "The field Name is required.")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field Location is required.")]
        [StringLength(50)]
        public string Location { get; set; }

        [Required(ErrorMessage = "The field Start Date is required.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "The field EndDate is required.")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}