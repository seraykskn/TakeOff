using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataModel

{
     [Table("User")]
    public class User
    {
        public User()
         {

         }
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Surname { get; set; }

        [Required]
        public string Mail { get; set; }

        [Required]
        public string Password { get; set; }

        public int YetkiId { get; set; }
        public Yetki Yetki { get; set; }

        public ICollection<Message> Messages { get; set; }
        public ICollection<Travel> Travels { get; set; }
        public ICollection<Product> Products { get; set; }
       



    }
}
