using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace QuizApi.Models
{
    public class Quiz
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int SectionId { get; set; }
        public string Image { get; set; }
        public Sections Section { get; set; }
        public ICollection<Question> Questions { get; set; }

    }
    public class QuizDto
    {
#nullable enable
        
        public string? name { get; set; }
        public string? Image { get; set; }
#nullable disable
        public string description { get; set; }
        public int SectionId { get; set; }
    }
}
