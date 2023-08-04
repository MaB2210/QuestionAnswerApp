namespace QuestionAnswerApp.Models
{
    public static class DataHelper
    {
        private static List<QuestionModel> _questions;

        public static List<QuestionModel> GetQuestions()
        {
            if (_questions == null)
            {
                _questions = new List<QuestionModel>()
                {
                    new QuestionModel(1, "IT", "Load Balancer", "What is Load Balancer?", DateTime.Now),
                    new QuestionModel(2, "Programming", "C#", "What is MVC", DateTime.Now),
                    new QuestionModel(3, "DevOps", "CloudOps", "What is GCP?", DateTime.Now),
                    new QuestionModel(4, "SQL", "Create Table", "How to create Table?", DateTime.Now),
                };

                _questions[0].Answers.Add(new AnswerModel(1, "This is Load Balancer", "N/A", DateTime.Now, 0));

                _questions[1].Answers.Add(new AnswerModel(3, "Model View and Controller", "N/A", DateTime.Now, 1));

            }

            return _questions;
        }
    }

}
