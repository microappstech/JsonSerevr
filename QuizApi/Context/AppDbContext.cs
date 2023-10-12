using Microsoft.EntityFrameworkCore;
using QuizApi.Models;

namespace QuizApi.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> appContext):base(appContext)
        {            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Quiz>()
                .HasOne(i => i.Section)
                .WithMany(i => i.Quizzes)
                .HasForeignKey(i => i.SectionId)
                .HasPrincipalKey(i => i.Id);
            
            builder.Entity<Question>()
                .HasOne(i => i.Quiz)
                .WithMany(i => i.Questions)
                .HasForeignKey(i => i.quizid)
                .HasPrincipalKey(i => i.id);


            builder.Entity<Response>()
                .HasOne(i => i.Question)
                .WithMany(i => i.Responses)
                .HasForeignKey(i => i.questionId)
                .HasPrincipalKey(i => i.id);

            builder.Entity<Sections>()
                .HasOne(i => i.Categorie)
                .WithMany(i => i.Sections)
                .HasForeignKey(i => i.CategoryId)
                .HasPrincipalKey(i => i.id);






            base.OnModelCreating(builder);
        }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Sections> Sections { get; set; }

    }
}
