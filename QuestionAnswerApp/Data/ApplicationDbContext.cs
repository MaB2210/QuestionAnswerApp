using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuestionAnswerApp.Models;

namespace QuestionAnswerApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<QuestionModel> Questions
        { get; set; }
        public DbSet<AnswerModel> Answers
        { get; set; }

        //public DbSet<QuestionAnswerApp.Models.AnswerModel> AnswerModel { get; set; } = default!;
    }
}