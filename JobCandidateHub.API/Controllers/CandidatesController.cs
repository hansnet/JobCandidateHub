using AutoMapper;
using JobCandidateHub.Application.DTOs;
using JobCandidateHub.Application.Interfaces;
using JobCandidateHub.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JobCandidateHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public CandidatesController(ICandidateRepository candidateRepository, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        // GET: api/<CandidatesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var candidates = await _candidateRepository.GetAllCandidatesAsync();
            return Ok(_mapper.Map<IEnumerable<CandidateDto>>(candidates));
        }

        // GET api/<CandidatesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateDto>> Get(string id)
        {
            var user = await _candidateRepository.GetCandidateByIdAsync(id);

            if (user == null)
                return NotFound(new { message = "Candidate not found." });

            return Ok(_mapper.Map<CandidateDto>(user));
        }

        // POST api/<CandidatesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CandidateDto value)
        {
            var existingCandidate = await _candidateRepository.GetCandidateByEmailAsync(value.Email);

            if (existingCandidate != null)
            {
                //Keep the existing Id so as to be able to update the rest of the details
                value.Id = existingCandidate.Id;

                // Update existing candidate details if email exists
                _mapper.Map(value, existingCandidate);

                await _candidateRepository.UpdateCandidateAsync(existingCandidate);

                return Ok(existingCandidate);
            }

            // Create a new candidate if email doesn't exist
            var candidate = _mapper.Map<Candidate>(value);
            candidate = await _candidateRepository.AddCandidateAsync(candidate);

            return CreatedAtAction("Get", new { id = candidate.Id }, candidate);

        }

        // PUT api/<CandidatesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] CandidateDto value)
        {
            if (id != value.Id)
            {
                return BadRequest(new { message = "Update failed, candidate not found" });
            }

            var product = _mapper.Map<Candidate>(value);
            await _candidateRepository.UpdateCandidateAsync(product);

            return NoContent();
        }

        // DELETE api/<CandidatesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var candidate = await _candidateRepository.GetCandidateByIdAsync(id);
            if (candidate is null)
                return NotFound(new { message = "Candidate not found" });

            await _candidateRepository.DeleteCandidateAsync(id);

            return NoContent();
        }
    }
}
