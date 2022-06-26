using Microsoft.AspNetCore.Mvc;
using VotingCalculatorAPI.Models;
using VotingCalculatorAPI.RestModels;

namespace VotingCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotingController : ControllerBase
    {
        private readonly CandidateDbContext context;
        public VotingController(CandidateDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RestVotingResponse>> Get()
        {
            var votingResult = context.Candidates.Select(candidate => new RestVotingResponse
            {
                FirstName = candidate.FirstName,
                LastName = candidate.LastName,
                NumberOfVotes = candidate.VotingsList.Count()
            }).OrderBy(order => order.LastName).ToList();

            return votingResult;
        }

        [HttpPost]
        public IActionResult Post([FromBody] RestVotingRequest requestVoting)
        {
            if (requestVoting == null)
                return BadRequest("No candidate has been selected.");

            Voting responseVoting = new Voting()
            {
                Id = Guid.NewGuid(), // każdy request to nowy obywatel
                CandidateId = requestVoting.CandidateId
            };

            var candidateForVoting = context.Candidates
                .FirstOrDefault(candidate => candidate.Id == requestVoting.CandidateId); // użyłem FirstOrDefault ponieważ w DbContext określiłem że nie będzie duplikatów
            if (candidateForVoting == null)
                return NotFound("The candidate doesn't exists.");

            var alreadyVoting = context.Votings
                .Where(vote => vote.Id == responseVoting.Id)
                .Count(); // wykona się Queryable i pobierze tylko 1 lub żadnego a nie listę wszystkich obywateli
            if (alreadyVoting != 0)
                return BadRequest("You've already voted.");

            context.Votings.Add(responseVoting);
            context.SaveChanges();
            return Created(responseVoting.Id.ToString(), $"You voted.");
        }
    }
}
