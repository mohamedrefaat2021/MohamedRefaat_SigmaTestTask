using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohamedRefaat_SigmaTestTask.Infra.Data.Models.Candidate
{
    public class Candidate
    {

       
        public string FirstName { get; set; } = string.Empty; // Required
        public string LastName { get; set; } = string.Empty; // Required
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; // Required, Unique
        public string CallTimeInterval { get; set; } = string.Empty;
        public string LinkedInProfile { get; set; } = string.Empty;
        public string GitHubProfile { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty; // Required
    }
}
