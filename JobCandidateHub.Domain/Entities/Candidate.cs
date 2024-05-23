using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateHub.Domain.Entities
{
    public class Candidate : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime TimeInterval { get; set; }

        public string LinkedIn { get; set; }

        public string Github { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}
