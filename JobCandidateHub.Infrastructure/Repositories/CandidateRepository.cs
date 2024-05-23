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

        public async Task DeleteCandidateAsync(string id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null)
                throw new ArgumentException("Candidate not found", nameof(candidate));

            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Candidate>> GetAllCandidatesAsync()
        {
            return await _context.Candidates.ToListAsync();
        }

        public async Task<Candidate?> GetCandidateByIdAsync(string id)
        {
            return await _context.Candidates.FindAsync(id);
        }

        public async Task<Candidate?> GetCandidateByEmailAsync(string email)
        {
            return await _context.Candidates.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Candidate> UpdateCandidateAsync(Candidate candidate)
        {
            _context.Entry(candidate).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return candidate;
        }
    }
}
