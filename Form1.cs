using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quizzgame4
{
    public partial class Form1 : Form
    {
        //quiz game variables
        int correctAnswer = 0;
        int questionNumber = 1;
        int score = 0;
        int percentage = 0;
        int totalQuestions = 0;

        public Form1()
        {
            InitializeComponent();
            totalQuestions = 21;
            progressBar1.Maximum = totalQuestions;
            progressBar1.Value = 0;
            lbScore.Text = "Резултат: 0"; // Задаване на начален текст на етикета
            askQuestion(questionNumber);
        }

        private async void checkAnswerEvent(object sender, EventArgs e)
        {
            var senderObject = (Button)sender;
            int buttonTag = Convert.ToInt32(senderObject.Tag);

            if (buttonTag == correctAnswer)
            {
                senderObject.BackColor = Color.Green;
                score++;
            }
            else
            {
                senderObject.BackColor = Color.Red;
                // Highlight the correct answer
                foreach (Button btn in this.Controls.OfType<Button>().Where(b => b.Tag != null))
                {
                    if (Convert.ToInt32(btn.Tag) == correctAnswer)
                    {
                        btn.BackColor = Color.Green;
                    }
                }

                // Намаляне на резултата с една точка
                if (score > 0)
                {
                    score--;
                }
            }

            // Актуализиране на резултата в етикета lbScore
            lbScore.Text = "Резултат: " + score;

            await Task.Delay(1000); // Delay for 1 second to show the color change

            if (questionNumber == totalQuestions)
            {
                // Work out the percentage
                percentage = (int)Math.Round((double)(score * 100) / totalQuestions);

                MessageBox.Show(
                    "Играта свърши!" + Environment.NewLine +
                    "Ти отговори вярно на " + score + " въпроса." + Environment.NewLine +
                    "Твоята успеваемост е " + percentage + "%" + Environment.NewLine +
                    "Натисни ОК за нова игра"
                );

                score = 0;
                questionNumber = 0;
                progressBar1.Value = 0; // Reset the progress bar
                askQuestion(questionNumber);

                // Reset the score label
                lbScore.Text = "Резултат: 0";
            }
            else
            {
                questionNumber++;
                progressBar1.Value = questionNumber; // Update progress bar
                askQuestion(questionNumber);
            }
        }

        private void askQuestion(int qnum)
        {
            // Reset all button colors and enabled state to default
            foreach (Button btn in this.Controls.OfType<Button>().Where(b => b.Tag != null))
            {
                btn.BackColor = default(Color);
                btn.Enabled = true;
                btn.FlatAppearance.BorderColor = default(Color);
            }

            // Remove focus from all buttons
            this.ActiveControl = null;

            switch (qnum)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.questiongirl;

                    lblQuestion.Text = "Коя е столицата на Испания?";

                    button1.Text = "Копенхаген";
                    button2.Text = "Мадрид";
                    button3.Text = "Париж";
                    button4.Text = "Талин";

                    correctAnswer = 2;
                    break;

                case 2:
                    pictureBox1.Image = Properties.Resources.questiongirl;

                    lblQuestion.Text = "Коя е столицата на Андора?";

                    button1.Text = "Берлин";
                    button2.Text = "Букурещ";
                    button3.Text = "Андора ла Вела";
                    button4.Text = "Атина";

                    correctAnswer = 3;
                    break;

                case 3:
                    pictureBox1.Image = Properties.Resources.spain;

                    lblQuestion.Text = "Столицата е Мадрид, коя държава съм аз?";

                    button1.Text = "Германия";
                    button2.Text = "Полша";
                    button3.Text = "Белгия";
                    button4.Text = "Испания";

                    correctAnswer = 4;
                    break;

                case 4:
                    pictureBox1.Image = Properties.Resources.turkey;

                    lblQuestion.Text = "Анкара е моята столица, коя държава съм аз?";

                    button1.Text = "Турция";
                    button2.Text = "Гърция";
                    button3.Text = "Македония";
                    button4.Text = "Казахстан";

                    correctAnswer = 1;
                    break;

                case 5:
                    pictureBox1.Image = Properties.Resources.questiongirl;

                    lblQuestion.Text = "Коя е столицата на Сърбия?";

                    button1.Text = "Москва";
                    button2.Text = "Белград";
                    button3.Text = "София";
                    button4.Text = "Лондон";

                    correctAnswer = 2;
                    break;

                case 6:
                    pictureBox1.Image = Properties.Resources.questiongirl;

                    lblQuestion.Text = "Коя е столицата на Чехия?";

                    button1.Text = "Амстердам";
                    button2.Text = "Вършава";
                    button3.Text = "Тирана";
                    button4.Text = "Прага";

                    correctAnswer = 4;
                    break;

                case 7:
                    pictureBox1.Image = Properties.Resources.malta;

                    lblQuestion.Text = "Аз съм Малта, познай моята столица.";

                    button1.Text = "Валета";
                    button2.Text = "Рига";
                    button3.Text = "Осло";
                    button4.Text = "Монако";

                    correctAnswer = 1;
                    break;

                case 8:
                    pictureBox1.Image = Properties.Resources.italy;

                    lblQuestion.Text = "Коя е тази държава и столица?";

                    button1.Text = "Италия-Рим";
                    button2.Text = "Испания-Мадрид";
                    button3.Text = "Румъния-Букурещ";
                    button4.Text = "България-София";

                    correctAnswer = 1;
                    break;

                case 9:
                    pictureBox1.Image = Properties.Resources.questiongirl;

                    lblQuestion.Text = "Коя е столицата на Германия?";

                    button1.Text = "Копенхаген";
                    button2.Text = "Лисабон";
                    button3.Text = "Берлин";
                    button4.Text = "Минск";

                    correctAnswer = 3;
                    break;

                case 10:
                    pictureBox1.Image = Properties.Resources.questiongirl;

                    lblQuestion.Text = "Коя е столицата на Литва?";

                    button1.Text = "Латвия";
                    button2.Text = "Вилюс";
                    button3.Text = "Рига";
                    button4.Text = "Виена";

                    correctAnswer = 2;
                    break;

                case 11:
                    pictureBox1.Image = Properties.Resources.russia;

                    lblQuestion.Text = "Коя е моята държава и столица ?";

                    button1.Text = "Русия-Мурманск";
                    button2.Text = "Русия-Санкт Петербург";
                    button3.Text = "Русия-Минск";
                    button4.Text = "Русия-Москва";

                    correctAnswer = 4;
                    break;

                case 12:
                    pictureBox1.Image = Properties.Resources.denmark;

                    lblQuestion.Text = "Аз съм Дания и столицата ми е..?";

                    button1.Text = "Лисабон";
                    button2.Text = "Монако";
                    button3.Text = "Варшава";
                    button4.Text = "Копенхаген";

                    correctAnswer = 4;
                    break;

                case 13:
                    pictureBox1.Image = Properties.Resources.questiongirl;

                    lblQuestion.Text = "Коя е столицата на Австрия?";

                    button1.Text = "Берлин";
                    button2.Text = "Москва";
                    button3.Text = "Виена";
                    button4.Text = "Грац";

                    correctAnswer = 3;
                    break;

                case 14:
                    pictureBox1.Image = Properties.Resources.bulgaria;

                    lblQuestion.Text = "Коя държава съм аз и коя е моята столица?";

                    button1.Text = "Велико Търново";
                    button2.Text = "Пловдив";
                    button3.Text = "Варна";
                    button4.Text = "София";

                    correctAnswer = 4;
                    break;

                case 15:
                    pictureBox1.Image = Properties.Resources.belgium;

                    lblQuestion.Text = "Коя е столицата ми? Белгия ме наричат.";

                    button1.Text = "Брюксел";
                    button2.Text = "Белград";
                    button3.Text = "Берлин";
                    button4.Text = "Будапеща";

                    correctAnswer = 1;
                    break;

                case 16:
                    pictureBox1.Image = Properties.Resources.questiongirl;

                    lblQuestion.Text = "Коя е столицата на Финландия?";

                    button1.Text = "Загреб";
                    button2.Text = "Хелзинки";
                    button3.Text = "Донецк";
                    button4.Text = "Прищина";

                    correctAnswer = 2;
                    break;

                case 17:
                    pictureBox1.Image = Properties.Resources.questiongirl;

                    lblQuestion.Text = "Коя е столицата на Великобритания?";

                    button1.Text = "Англия";
                    button2.Text = "Скопие";
                    button3.Text = "Лондон";
                    button4.Text = "Дъблин";

                    correctAnswer = 3;
                    break;

                case 18:
                    pictureBox1.Image = Properties.Resources.questiongirl;

                    lblQuestion.Text = "Коя е столицата на Беларус?";

                    button1.Text = "Минск";
                    button2.Text = "Москва";
                    button3.Text = "Монтана";
                    button4.Text = "Стокхолм";

                    correctAnswer = 1;
                    break;

                case 19:
                    pictureBox1.Image = Properties.Resources.france;

                    lblQuestion.Text = "Коя държава и столица съм аз?";

                    button1.Text = "Франция-Монпелие";
                    button2.Text = "Франция-Лион";
                    button3.Text = "Франция-Льо Ман";
                    button4.Text = "Франция-Париж";

                    correctAnswer = 4;
                    break;

                case 20:
                    pictureBox1.Image = Properties.Resources.grecee;

                    lblQuestion.Text = "Коя държава съм аз, столицата ми е Атина.";

                    button1.Text = "Грузия";
                    button2.Text = "Гренландия";
                    button3.Text = "Кипър";
                    button4.Text = "Гърция";

                    correctAnswer = 4;
                    break;

                case 21:
                    pictureBox1.Image = Properties.Resources.questiongirl;

                    lblQuestion.Text = "Коя е столицата на Румъния?";

                    button1.Text = "Букурещ";
                    button2.Text = "Будапеща";
                    button3.Text = "Любляна";
                    button4.Text = "Рейкявик";

                    correctAnswer = 1;
                    break;
            }
        }
    }
}
