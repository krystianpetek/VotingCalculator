using System;
using System.ComponentModel.DataAnnotations;

namespace VotingCalculatorAPI.Models
{
    /// <summary>
    /// Class <c>Candidate</c> model, is a database voting model
    /// </summary>
    public class Candidate
    {
        /// <summary>
        /// Candidate Identifier
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Candidate first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Candidate last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// List that has a relation to the <c>Voting</c> class, many to one relationship
        /// </summary>
        public List<Voting> VotingsList { get; set; } = new List<Voting>();

        /// <summary>
        /// Date of registration to the candidate
        /// </summary>
        private DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}
