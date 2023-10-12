using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApi.Models
{
    public class AppUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string username { get; set; }
        public string Password { get; set; }
        public string email { get; set; }
        public bool isAdmin { get; set; }
    }
}
