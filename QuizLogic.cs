using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizzgame4
{
   
    /// Клас с основната логика на куиза, следва логиката от Form1.cs
    /// Логиката: верен отговор -> score++, грешен отговор -> if (score > 0) score--
    
    public class QuizLogic
    {
        public int Score { get; private set; }
        public int TotalQuestions { get; private set; }
        public int CorrectAnswers { get; private set; }

        
        /// Инициализиране на играта – подаваме само брой въпроси (без животи, както в Form1).
        
        public QuizLogic(int totalQuestions)
        {
            if (totalQuestions <= 0) throw new ArgumentException("TotalQuestions must be positive.");

            TotalQuestions = totalQuestions;
            Score = 0;
            CorrectAnswers = 0;
        }

        
        /// Проверява дали отговорът е верен (без значение от главни/малки букви)
        /// и актуализира точки според логиката от Form1.cs:
        /// - Верен отговор: score++ (ред 40 в Form1)
        /// - Грешен отговор: if (score > 0) score-- (ред 55-57 в Form1)
        
        public bool SubmitAnswer(string userAnswer, string correctAnswer, int pointsPerCorrect = 1)
        {
            if (correctAnswer == null)
                throw new ArgumentNullException(nameof(correctAnswer));

            bool isCorrect = string.Equals(
                userAnswer?.Trim(),
                correctAnswer.Trim(),
                StringComparison.InvariantCultureIgnoreCase);

            if (isCorrect)
            {
                // Верен отговор: score++ (като в Form1.cs ред 40)
                Score += pointsPerCorrect;
                CorrectAnswers++;
            }
            else
            {
                // Грешен отговор: if (score > 0) score-- (като в Form1.cs ред 55-57)
                if (Score > 0)
                {
                    Score -= pointsPerCorrect;
                }
            }

            return isCorrect;
        }

        
        /// Пресмята процент верни отговори (като в Form1.cs ред 69).
        
        public double GetSuccessRate()
        {
            if (TotalQuestions == 0) return 0;
            return (double)CorrectAnswers / TotalQuestions * 100.0;
        }

        
        /// Пресмята процент от резултата (score), както в Form1.cs ред 69.
        
        public int CalculatePercentage()
        {
            if (TotalQuestions == 0) return 0;
            return (int)Math.Round((double)(Score * 100) / TotalQuestions);
        }
    }
}

