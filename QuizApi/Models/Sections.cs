using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace QuizApi.Models
{
    public class Sections
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }
        public Categories Categorie { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
    }
    public class SectionsDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}
