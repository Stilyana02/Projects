using System;
namespace quizzgame4
{
    public class QuizEngine
    {
        public int QuestionNumber { get; private set; } = 1;
        public int TotalQuestions { get; private set; } = 21;
        public int Score { get; private set; } = 0;
        public int CorrectAnswer { get; private set; }

        public void SetCorrectAnswer(int ans) => CorrectAnswer = ans;

        public bool SubmitAnswer(int selected)
        {
            if (selected == CorrectAnswer)
            {
                Score++;
                return true;
            }
            else
            {
                if (Score > 0) Score--;
                return false;
            }
        }

        public void NextQuestion() => QuestionNumber++;
        public int CalculatePercentage() => (int)Math.Round((double)(Score * 100) / TotalQuestions);
    }
}