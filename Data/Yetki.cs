using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataModel
{
    [Table("Yetki")]
    public class Yetki
    {
        [Key]
        public int YetkiId { get; set; }

        public string YetkiAdi { get; set; }

        public ICollection<User> User { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Travel> Travels { get; set; }

    }
}
