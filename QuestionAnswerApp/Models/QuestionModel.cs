using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionAnswerApp.Models
{
    public class QuestionModel
    {
        public QuestionModel() { }

        public QuestionModel(int id, string category, string title, string question, DateTime dateAdded)
        {
            Id = id;
            Category = category;
            Title = title;
            Question = question;
            DateAdded = dateAdded;
        }

        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [StringLength(10)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Question { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }
        public List<AnswerModel> Answers { get; set; } = new List<AnswerModel>();

    }
}
