namespace VotingCalculatorAPI.Models
{
    /// <summary>
    /// Class <c>Voting</c> model, is a database voting model
    /// </summary>
    public class Voting
    {
        /// <summary>
        /// Voting Identifier
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Candidate Identifier
        /// </summary>
        public Guid CandidateId { get; set; }
        /// <summary>
        /// Relation to the <c>Candidate</c> class, one to many relationship
        /// </summary>
        public Candidate Candidate { get; set; }
        /// <summary>
        /// Date when it was voted
        /// </summary>
        private DateTime VotingDate { get; set; } = DateTime.Now;
    }
}
