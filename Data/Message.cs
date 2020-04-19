using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataModel

{
    [Table("Message")]
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public User User{ get; set; }
    }
}
