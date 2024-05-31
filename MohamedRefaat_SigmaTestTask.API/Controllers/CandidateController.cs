using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MohamedRefaat_SigmaTestTask.Domain.IRepository;
using MohamedRefaat_SigmaTestTask.Infra.Data.Models.Candidate;

namespace MohamedRefaat_SigmaTestTask.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateRepository _repository;
        private readonly IMemoryCache _cache;

        public CandidatesController(ICandidateRepository repository, IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        [HttpPost]
        public async Task<IActionResult> UpsertCandidate([FromBody] Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCandidate = await _repository.GetCandidateByEmailAsync(candidate.Email);
            if (existingCandidate != null)
            {
                existingCandidate.FirstName = candidate.FirstName;
                existingCandidate.LastName = candidate.LastName;
                existingCandidate.PhoneNumber = candidate.PhoneNumber;
                existingCandidate.CallTimeInterval = candidate.CallTimeInterval;
                existingCandidate.LinkedInProfile = candidate.LinkedInProfile;
                existingCandidate.GitHubProfile = candidate.GitHubProfile;
                existingCandidate.Comments = candidate.Comments;
               

                await _repository.UpdateCandidateAsync(existingCandidate);
            }
            else
            {
                await _repository.AddCandidateAsync(candidate);
            }

            _cache.Remove(candidate.Email); // Invalidate cache

            return Ok(candidate);
        }
    }

}
