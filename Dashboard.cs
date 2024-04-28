using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Espela_EDP_ACT4
{
    public partial class Dashboard : Form
    {
        private MySqlConnection connection;
        private string loggedInUsername;

        public Dashboard(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
            UpdateUserLabel(); // Update UI with logged-in username

            // Establish MySQL connection
            string connectionString = "server=127.0.0.1;database=ecommercedb;uid=root;pwd=Kenneth120318!";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                DisplayProducts(); // Display products in DataGridView
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void Userlabel_Click(object sender, EventArgs e)
        {
            // This is where the user's name that logged in will appear
        }

        private void UpdateUserLabel()
        {
            Userlabel.Text = "Welcome, " + loggedInUsername + "!";
        }

        private void DisplayProducts()
        {
            try
            {
                string query = "SELECT id, name, price FROM products";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                Games.DataSource = table;

                // Center-align DataGridView content
                Games.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Add Buy button column
                DataGridViewButtonColumn buyButtonColumn = new DataGridViewButtonColumn();
                buyButtonColumn.HeaderText = "Buy";
                buyButtonColumn.Name = "BuyButton";
                buyButtonColumn.Text = "Buy";
                buyButtonColumn.UseColumnTextForButtonValue = true;
                buyButtonColumn.DefaultCellStyle.BackColor = Color.Green;
                buyButtonColumn.DefaultCellStyle.ForeColor = Color.White;
                Games.Columns.Add(buyButtonColumn);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && connection != null)
            {
                connection.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Games_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the Buy button is clicked
            if (e.ColumnIndex == Games.Columns["BuyButton"].Index && e.RowIndex >= 0)
            {
                // Get the product ID from the DataGridView
                int productId = Convert.ToInt32(Games.Rows[e.RowIndex].Cells["id"].Value);

                // Get the current date
                DateTime orderDate = DateTime.Now;

                // Get the total price from the DataGridView
                decimal totalPrice = Convert.ToDecimal(Games.Rows[e.RowIndex].Cells["price"].Value);

                // Insert the order into the orders table
                try
                {
                    string query = "INSERT INTO orders (user_id, product_id, order_date, total_price) VALUES (@userId, @productId, @orderDate, @totalPrice)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@userId", GetUserId(loggedInUsername)); // Assuming you have a function to get the user ID
                    command.Parameters.AddWithValue("@productId", productId);
                    command.Parameters.AddWithValue("@orderDate", orderDate);
                    command.Parameters.AddWithValue("@totalPrice", totalPrice);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product Succesfully Purchased!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to Purchase.");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Example function to get the user ID based on the username
        private int GetUserId(string username)
        {
            int userId = 0;
            try
            {
                string query = "SELECT id FROM users WHERE username = @username";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    userId = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return userId;
        }


    }
}
