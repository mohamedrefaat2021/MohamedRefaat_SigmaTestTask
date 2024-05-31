using MohamedRefaat_SigmaTestTask.Infra.Data.Models.Candidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohamedRefaat_SigmaTestTask.Domain.IRepository
{
    public interface ICandidateRepository
    {
        Task AddCandidateAsync(Candidate candidate);
        Task UpdateCandidateAsync(Candidate candidate);
        Task<Candidate> GetCandidateByEmailAsync(string email);
    }
}
