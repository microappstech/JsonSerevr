using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApi.Models
{
    public class Response
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string description { get; set; }
        public bool isok { get; set; }
        public int questionId { get; set; }
        public Question Question { get; set; }
    }
    public class ResponseDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string description { get; set; }
        public bool isok { get; set; }
        public int questionId { get; set; }
    }
}
