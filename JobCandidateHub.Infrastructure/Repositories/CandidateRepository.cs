using JobCandidateHub.Application.Interfaces;
using JobCandidateHub.Domain.Entities;
using JobCandidateHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHub.Infrastructure.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly AppDbContext _context;

        public CandidateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Candidate> AddCandidateAsync(Candidate candidate)
        {
            candidate.Id = Guid.NewGuid().ToString(); //making sure the Id is set
            await _context.Candidates.AddAsync(candidate);

            await _context.SaveChangesAsync();

            return candidate;
        }

        public Task DeleteCandidateAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Candidate>> GetAllCandidatesAsync()
        {
            return await _context.Candidates.ToListAsync();
        }

        public Task<Candidate> GetCandidateByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Candidate> UpdateCandidateAsync(Candidate candidate)
        {
            throw new NotImplementedException();
        }
    }
}
