using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataModel

{
    [Table("Travel")]
    public class Travel
    {
        [Key]
        public int TravelerId { get; set; }
        [Required]
      
        public string TravelerName { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        public DateTime FlightDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string Comment { get; set; }

        [Required]  
        public string Size { get; set; }

        public int UserId{ get; set; }
        //public User User { get; set; }

        public int YetkiId { get; set; }
        public Yetki Yetki { get; set; }

        

    }
}
