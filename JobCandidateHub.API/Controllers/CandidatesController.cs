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
            var existingUser = await _candidateRepository.GetAllCandidatesAsync();
            if (existingUser.Any(u => u.Email == value.Email))
            {
                return BadRequest(new { message = "Email already exists." });
            }

            var candidate = _mapper.Map<Candidate>(value);
            candidate = await _candidateRepository.AddCandidateAsync(candidate);

            return CreatedAtAction("Get", new { id = candidate.Id });
        }

        // PUT api/<CandidatesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CandidatesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
