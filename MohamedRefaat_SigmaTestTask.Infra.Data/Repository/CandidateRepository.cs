using Microsoft.EntityFrameworkCore;
using MohamedRefaat_SigmaTestTask.API.Data;
using MohamedRefaat_SigmaTestTask.Domain.IRepository;
using MohamedRefaat_SigmaTestTask.Infra.Data;
using MohamedRefaat_SigmaTestTask.Infra.Data.Models.Candidate;

public class CandidateRepository : ICandidateRepository
{
    private readonly CandidateContext _context;

    public CandidateRepository(CandidateContext context)
    {
        _context = context;
    }

    public async Task AddCandidateAsync(Candidate candidate)
    {
        await _context.Candidates.AddAsync(candidate);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCandidateAsync(Candidate candidate)
    {
        _context.Candidates.Update(candidate);
        await _context.SaveChangesAsync();
    }

    public async Task<Candidate> GetCandidateByEmailAsync(string email)
    {
        return await _context.Candidates.FirstOrDefaultAsync(c => c.Email == email);
    }
}
