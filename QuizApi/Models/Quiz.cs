using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApi.Models
{
    public class Quiz
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int SectionId { get; set; }
        public Sections Section { get; set; }
        public ICollection<Question> Questions { get; set; }

    }
    public class QuizDto
    {
        public string name { get; set; }
        public string description { get; set; }
        public int SectionId { get; set; }
    }
}
