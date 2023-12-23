using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InterviewTask.Data.Entities
{
    [Table("Client")]

    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ClientName {  get; set; }

        [Required]
        public string ClientAddress {get; set;}

    }
}
