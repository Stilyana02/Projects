using quizzgame4;
using System;
using System.Windows.Forms;

namespace quizzgame4

{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show the login form
            Form2 loginForm = new Form2();
            if (loginForm.ShowDialog() == DialogResult.OK) // Проверяваме за DialogResult.OK
            {
                // If login is successful, show the main form
                Application.Run(new Form1());
            }
        }

    }
}
