using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;

namespace Espela_EDP_ACT4
{
    public partial class Login : Form
    {
        // Make the connection public
        public MySqlConnection Connection { get; } = new MySqlConnection(connectionString);

        private const string connectionString = "server=127.0.0.1;database=ecommercedb;uid=root;pwd=Kenneth120318!;";

        public Login()
        {
            InitializeComponent();
            passwordbox.PasswordChar = '*';
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string loginInput = usernamebox.Text;
            string password = passwordbox.Text;

            AuthenticateUser(loginInput, password);
        }

        private void AuthenticateUser(string loginInput, string password)
        {
            using (MySqlConnection connection = Connection)
            {
                try
                {
                    connection.Open();

                    string query = "SELECT username, password FROM users WHERE email = @loginInput OR username = @loginInput";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@loginInput", loginInput);

                    // Execute the query to get the hashed password and the username
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string storedUsername = reader["username"].ToString();
                        string hashedPassword = reader["password"].ToString();

                        // Hash the provided password using the same method as the stored hashed password
                        string hashedInputPassword = HashPassword(password);

                        if (hashedInputPassword == hashedPassword)
                        {
                            if (storedUsername == "admin" && password == "123")
                            {
                                OpenAdminForm();
                            }
                            else
                            {
                                MessageBox.Show("Login successful!");
                                OpenDashboardForm(storedUsername); // Pass the retrieved username
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username/email or password. Please try again.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username/email or password. Please try again.");
                    }

                    reader.Close();
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

        private void OpenAdminForm()
        {
            admin adminForm = new admin();
            adminForm.Show();
            this.Hide();
        }

        private void OpenDashboardForm(string username)
        {
            Dashboard dashboardForm = new Dashboard(username);
            dashboardForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Handle label5 (e.g., signup) click
            // For example, open the signup form
            OpenSignupForm();
        }

        private void OpenSignupForm()
        {
            Signup signupForm = new Signup();
            signupForm.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // Handle any PictureBox click event (if needed)
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Handle any text changed event for username/email box (if needed)
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Handle any text changed event for password box (if needed)
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Handle any paint event for panel2 (if needed)
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Handle form load event (if needed)
        }
    }
}
