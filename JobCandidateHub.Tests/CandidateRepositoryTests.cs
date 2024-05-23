using JobCandidateHub.Application.Interfaces;
using JobCandidateHub.Domain.Entities;
using JobCandidateHub.Infrastructure.Data;
using JobCandidateHub.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHub.Tests
{
    public class CandidateRepositoryTests
    {
        private readonly DbContextOptions<AppDbContext> _dbContextOptions;
        private readonly AppDbContext _context;
        private readonly ICandidateRepository _repository;

        public CandidateRepositoryTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "JobCandidateTestDB")
                .Options;

            _context = new AppDbContext(_dbContextOptions);
            _repository = new CandidateRepository(_context);
        }

        private Candidate CreateTestCandidate(string id = null)
        {
            return new Candidate
            {
                Id = id ?? Guid.NewGuid().ToString(),
                FirstName = "Hans",
                LastName = "Andrew",
                Email = "hans.andrew@example.com",
                PhoneNumber = "1234567890",
                TimeInterval = DateTime.Now,
                LinkedIn = "https://linkedin.com/in/HansAndrew",
                Github = "https://github.com/HansAndrew",
                Comment = "Test Comment"
            };
        }

        [Fact]
        public async Task AddCandidateAsync_AddsCandidate()
        {
            // Arrange
            var candidate = CreateTestCandidate();

            // Act
            var result = await _repository.AddCandidateAsync(candidate);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Id);
            Assert.Equal(candidate.FirstName, result.FirstName);
            Assert.Equal(candidate.LastName, result.LastName);
            Assert.Equal(candidate.Email, result.Email);
            Assert.Equal(candidate.PhoneNumber, result.PhoneNumber);
            Assert.Equal(candidate.TimeInterval, result.TimeInterval);
            Assert.Equal(candidate.LinkedIn, result.LinkedIn);
            Assert.Equal(candidate.Github, result.Github);
            Assert.Equal(candidate.Comment, result.Comment);
        }

        [Fact]
        public async Task GetAllCandidatesAsync_ReturnsAllCandidates()
        {
            // Arrange
            _context.Candidates.Add(CreateTestCandidate(Guid.NewGuid().ToString()));
            _context.Candidates.Add(CreateTestCandidate(Guid.NewGuid().ToString()));
            await _context.SaveChangesAsync();

            // Act
            var candidates = await _repository.GetAllCandidatesAsync();

            // Assert
            Assert.Equal(2, candidates.Count());
        }

        [Fact]
        public async Task GetCandidateByIdAsync_ReturnsCandidate()
        {
            // Arrange
            var candidate = CreateTestCandidate(Guid.NewGuid().ToString());
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetCandidateByIdAsync(candidate.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(candidate.Id, result.Id);
            Assert.Equal(candidate.FirstName, result.FirstName);
            Assert.Equal(candidate.LastName, result.LastName);
            Assert.Equal(candidate.Email, result.Email);
            Assert.Equal(candidate.PhoneNumber, result.PhoneNumber);
            Assert.Equal(candidate.TimeInterval, result.TimeInterval);
            Assert.Equal(candidate.LinkedIn, result.LinkedIn);
            Assert.Equal(candidate.Github, result.Github);
            Assert.Equal(candidate.Comment, result.Comment);
        }

        [Fact]
        public async Task GetCandidateByEmailAsync_ReturnsCandidate()
        {
            // Arrange
            var candidate = CreateTestCandidate(Guid.NewGuid().ToString());
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetCandidateByEmailAsync("hans.andrew@example.com");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(candidate.FirstName, result.FirstName);
            Assert.Equal(candidate.LastName, result.LastName);
            Assert.Equal(candidate.Email, result.Email);
            Assert.Equal(candidate.PhoneNumber, result.PhoneNumber);
            Assert.Equal(candidate.LinkedIn, result.LinkedIn);
            Assert.Equal(candidate.Github, result.Github);
            Assert.Equal(candidate.Comment, result.Comment);
        }

        [Fact]
        public async Task UpdateCandidateAsync_UpdatesCandidate()
        {
            // Arrange
            var candidate = CreateTestCandidate(Guid.NewGuid().ToString());
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();

            // Act
            candidate.FirstName = "Marry";
            candidate.LastName = "Jane";
            candidate.Email = "marry.jane@example.com";
            candidate.PhoneNumber = "0987654321";
            candidate.Comment = "Updated Comment";
            var result = await _repository.UpdateCandidateAsync(candidate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(candidate.Id, result.Id);
            Assert.Equal("Marry", result.FirstName);
            Assert.Equal("Jane", result.LastName);
            Assert.Equal("marry.jane@example.com", result.Email);
            Assert.Equal("0987654321", result.PhoneNumber);
            Assert.Equal(candidate.TimeInterval, result.TimeInterval);
            Assert.Equal(candidate.LinkedIn, result.LinkedIn);
            Assert.Equal(candidate.Github, result.Github);
            Assert.Equal("Updated Comment", result.Comment);
        }

        [Fact]
        public async Task DeleteCandidateAsync_DeletesCandidate()
        {
            // Arrange
            var candidate = CreateTestCandidate(Guid.NewGuid().ToString());
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();

            // Act
            await _repository.DeleteCandidateAsync(candidate.Id);

            // Assert
            var result = await _context.Candidates.FindAsync(candidate.Id);
            Assert.Null(result);
        }
    }
}
