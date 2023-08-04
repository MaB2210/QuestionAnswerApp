using System.ComponentModel.DataAnnotations;

namespace QuestionAnswerApp.Models
{
    public class AnswerModel
    {
        public AnswerModel() { }

        public AnswerModel(int id, string answer, string additionalComments, DateTime dateAdded, int questionID)
        {
            Id = id;
            Answer = answer;
            AdditionalComments = additionalComments;
            DateAdded = dateAdded;
            QuestionID = questionID;
        }

        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Answer { get; set; }

        [StringLength(50)]
        public string AdditionalComments { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public int QuestionID { get; set; }

        public QuestionModel Question { get; set; }
    }
}
