using System.ComponentModel.DataAnnotations;

namespace VotingCalculatorAPI.RestModels
{
    /// <summary>
    /// Class <c>RestCandidateRequest</c> model, is a model in request to add new Candidate
    /// </summary>
    public class RestCandidateRequest
    {
        /// <summary>
        /// Candidate first name
        /// </summary>
        [Required, StringLength(20)]
        
        public string FirstName { get; set; }
        /// <summary>
        /// Candidate last name
        /// </summary>
        [Required, StringLength(30)]
        public string LastName { get; set; }
    }
}
