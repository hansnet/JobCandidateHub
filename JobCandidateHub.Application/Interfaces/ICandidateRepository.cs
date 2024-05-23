using JobCandidateHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateHub.Application.Interfaces
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> GetAllCandidatesAsync();

        Task<Candidate> GetCandidateByIdAsync(string id);

        Task<Candidate> AddCandidateAsync(Candidate candidate);

        Task<Candidate> UpdateCandidateAsync(Candidate candidate);

        Task DeleteCandidateAsync(string id);
    }
}
