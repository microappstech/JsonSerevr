using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApi.Models
{
    public class Categories
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string type { get; set; }

        [NotMapped]
        public ICollection<Sections> Sections { get; set; }
    }
    public class CategoriesDto 
    {
        public string name { get; set; }
        public string image { get; set; }
        public string type { get; set; }
    }
}
