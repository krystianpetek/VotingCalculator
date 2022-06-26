namespace VotingCalculatorAPI.RestModels
{
    /// <summary>
    /// Class <c>RestVotingResponse</c> model, is a model in response in to list number of votes with first and last name candidate
    /// </summary>
    public class RestVotingResponse
    {
        /// <summary>
        /// Candidate first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Candidate last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Number of votes to this candidate
        /// </summary>
        public int NumberOfVotes { get; set; }
    }
}
