using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApi.Models
{
    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? description { get; set; }
        public int quizid { get; set; }
        public Quiz Quiz { get; set; }
        public ICollection<Response> Responses { get; set; }

    }
    public class QuestionDto
    {
        public string? description { get; set; }
        public int quizid { get; set; }

    }
}
