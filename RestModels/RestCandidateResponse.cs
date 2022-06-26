namespace VotingCalculatorAPI.RestModels
{
    /// <summary>
    /// Class <c>RestCandidateResponse</c> model, is a model in response in to list all Candidate
    /// </summary>
    public class RestCandidateResponse
    {
        /// <summary>
        /// Voting Identifier
        /// </summary>
        public Guid VoteId { get; set; }
        /// <summary>
        /// Candidate first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Candidate last name
        /// </summary>
        public string LastName { get; set; }
    }
}
