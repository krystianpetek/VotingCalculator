using Microsoft.EntityFrameworkCore;
using VotingCalculatorAPI.Models;
using VotingCalculatorAPI.RestModels;

public class CandidateDbContext : DbContext
{
    public CandidateDbContext(DbContextOptions option ) : base( option )
    {
        
    }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Voting> Votings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>().HasKey(model => model.Id);
        modelBuilder.Entity<Candidate>().HasIndex(model => model.Id).IsUnique();
        modelBuilder.Entity<Candidate>().HasMany(model=>model.VotingsList).WithOne(model=>model.Candidate).HasForeignKey( model =>model.CandidateId);
        
        modelBuilder.Entity<Voting>().HasKey(model => model.Id);
        modelBuilder.Entity<Voting>().HasIndex(model => model.Id).IsUnique();
    }
}