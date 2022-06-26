using System.ComponentModel.DataAnnotations;

namespace VotingCalculatorAPI.RestModels
{
    /// <summary>
    /// Class <c>RestVotingRequest</c> model, is a model in request to add new Vote
    /// </summary>
    public class RestVotingRequest
    {
        /// <summary>
        /// Candidate Identifier
        /// </summary>
        [Required]
        public Guid CandidateId { get; set; }
    }
}
