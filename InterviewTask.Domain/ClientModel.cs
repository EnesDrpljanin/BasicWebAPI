using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask.Domain
{
    public class ClientModel
    {
        public int Id { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public string ClientAddress { get; set; }
    }
}
