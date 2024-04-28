using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Espela_EDP_ACT4
{
    public partial class Signup : Form
    {
        // Make the connection public
        public MySqlConnection Connection { get; } = new MySqlConnection(connectionString);

        private const string connectionString = "server=127.0.0.1;database=ecommercedb;uid=root;pwd=Kenneth120318!;";

        public Signup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Close the Signup form
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Get user input from textboxes
            string email = emailTextBox.Text.Trim();
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text;

            // Validate inputs
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Hash the password before storing it
            string hashedPassword = HashPassword(password);

            // Insert new user into the database
            CreateUser(email, username, hashedPassword);
        }

        private void CreateUser(string email, string username, string hashedPassword)
        {
            // Use the public connection field/property here
            using (MySqlConnection connection = Connection)
            {
                try
                {
                    connection.Open();

                    // Query to insert a new user into the database
                    string query = "INSERT INTO users (email, username, password) VALUES (@email, @username, @password)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", hashedPassword);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // User creation successful
                        MessageBox.Show("Account created successfully!");

                        // Close the Signup form after account creation
                        this.Close();

                        // Open the Login form
                        Login loginForm = new Login();
                        loginForm.Show();
                    }
                    else
                    {
                        // User creation failed
                        MessageBox.Show("Failed to create account. Please try again.");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private string HashPassword(string password)
        {
            // Use a secure hashing algorithm (e.g., bcrypt) to hash the password
            // For demonstration purposes, I'm using a simple hashing method
            return Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
