using MySql.Data.MySqlClient;
using System;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Espela_EDP_ACT4
{
    public partial class Forgot : Form
    {
        // Make the connection public
        public MySqlConnection Connection { get; } = new MySqlConnection(connectionString);

        private const string connectionString = "server=127.0.0.1;database=ecommercedb;uid=root;pwd=Kenneth120318!;";

        public Forgot()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Get the email and new password from the textboxes
            string email = emailrecovery.Text.Trim();
            string newPassword = newpass.Text;

            // Check if the email and new password are not empty
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(newPassword))
            {
                // Hash the new password
                string hashedPassword = HashPassword(newPassword);

                // Reset the password
                ResetPassword(email, hashedPassword);
            }
            else
            {
                MessageBox.Show("Please enter your email and new password.");
            }
        }

        private string HashPassword(string password)
        {
            // Use a secure hashing algorithm (e.g., bcrypt) to hash the password
            // For demonstration purposes, I'm using a simple hashing method
            return Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
        }

        private void ResetPassword(string email, string newPassword)
        {
            // Use the public connection field/property here
            using (MySqlConnection connection = Connection)
            {
                try
                {
                    connection.Open();

                    // Check if the email exists in the users table
                    string query = "SELECT COUNT(*) FROM users WHERE email = @email";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@email", email);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        // Update the password in the users table
                        string updateQuery = "UPDATE users SET password = @password WHERE email = @email";
                        MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@password", newPassword);
                        updateCommand.Parameters.AddWithValue("@email", email);

                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password reset successfully!");

                            // Close the Forgot form and show the login form
                            this.Hide();
                            Login loginForm = new Login();
                            loginForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Failed to reset password. Please try again.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email not found.");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Forgot_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void newpass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
