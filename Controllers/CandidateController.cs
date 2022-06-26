using Microsoft.AspNetCore.Mvc;
using VotingCalculatorAPI.Models;
using VotingCalculatorAPI.RestModels;

namespace VotingCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private CandidateDbContext context;
        public CandidateController(CandidateDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RestCandidateResponse>> Get()
        {
            var candidateForVoting = context.Candidates.Select(candidate =>
               new RestCandidateResponse()
               {
                   VoteId = candidate.Id,
                   FirstName = candidate.FirstName,
                   LastName = candidate.LastName
               }).OrderBy(order => order.LastName).ToList();

            if (candidateForVoting.Count == 0)
                return NotFound("Candidate list is null.");

            return candidateForVoting;
        }

        [HttpPost]
        public IActionResult Post([FromBody] RestCandidateRequest requestCandidate)
        {
            if (requestCandidate == null)
                return BadRequest("Wrong .");

            Candidate responseCandidate = new Candidate()
            {
                Id = Guid.NewGuid(),
                FirstName = requestCandidate.FirstName,
                LastName = requestCandidate.LastName
            };

            context.Candidates.Add(responseCandidate);
            context.SaveChanges();
            return Created(responseCandidate.Id.ToString(), responseCandidate.Id);
        }

    }
}
