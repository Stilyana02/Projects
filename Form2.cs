using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace quizzgame4
{
    public partial class Form2 : Form
    {
        private string connectionString = @"Data Source=DESKTOP-17RNRLJ;Initial Catalog=Login3;Integrated Security=True";

        public Form2()
        {
            InitializeComponent();
            txtpass.PasswordChar = '*'; // Set PasswordChar property to mask password input
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtuser.Text;
            string password = txtpass.Text;
            string usertype = comboBox1.SelectedItem.ToString();

            if (ValidateUser(username, password, usertype))
            {
                MessageBox.Show("Успешен вход!", "Вход", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Променяме DialogResult на OK
                this.Hide(); // Скриваме формата
            }
            else
            {
                MessageBox.Show("Невалидно потребителско име, парола или тип потребител.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateUser(string username, string password, string usertype)
        {
            bool isValid = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM dbo.login WHERE username = @username AND password = @password AND usertype = @usertype";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@usertype", usertype);

                        int result = (int)command.ExecuteScalar();

                        if (result > 0)
                        {
                            isValid = true;
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("SQL грешка: " + sqlEx.Message, "SQL Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Обща грешка: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return isValid;
        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
