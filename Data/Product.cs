using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web;

namespace DataModel

{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        
        [DisplayName("Upload File")]
        public string ImageUrl { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Comment { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        
        
        public int YetkiId { get; set; }
        //public Yetki Yetki { get; set; }

       
    }
}
