using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace Espela_EDP_ACT4
{
    public partial class admin : Form
    {
        // Declare MySqlConnection as a class-level variable
        private MySqlConnection Connection;

        private const string connectionString = "server=127.0.0.1;database=ecommercedb;uid=root;pwd=Kenneth120318!;";

        public admin()
        {
            InitializeComponent();

            // Initialize the connection in the constructor
            Connection = new MySqlConnection(connectionString);
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                // Open the connection before using it
                Connection.Open();

                // Query to retrieve data from the users table
                string query = "SELECT id, username, email, password FROM users";
                MySqlCommand command = new MySqlCommand(query, Connection);

                // Execute the query and load data into a DataTable
                DataTable dataTable = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);

                // Bind the DataTable to the DataGridView
                dataGridView1.DataSource = dataTable;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection after using it
                Connection.Close();
            }
        }

        private void LoadProductDetails()
        {
            try
            {
                // Query to retrieve product details from the database
                string query = "SELECT id, name, price FROM products";
                MySqlCommand command = new MySqlCommand(query, Connection);

                // Execute the query and load data into a DataTable
                DataTable dataTable = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);

                // Bind the DataTable to the DataGridView for products
                products.DataSource = dataTable;

                // Add delete button column to the DataGridView for products
                DataGridViewButtonColumn deleteProductButtonColumn = new DataGridViewButtonColumn();
                deleteProductButtonColumn.Name = "DeleteProductButtonColumn";
                deleteProductButtonColumn.Text = "Delete Product";
                deleteProductButtonColumn.UseColumnTextForButtonValue = true;
                products.Columns.Add(deleteProductButtonColumn);

                products.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                // Customize the appearance of the delete button column for products
                DataGridViewCellStyle buttonStyle = deleteProductButtonColumn.DefaultCellStyle;
                buttonStyle.BackColor = Color.Red;
                buttonStyle.ForeColor = Color.White;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close connection
                Connection.Close();
            }
        }

        private void admin_Load(object sender, EventArgs e)
        {
            // Load product details from the database when the form loads
            LoadProductDetails();

            // Load data from the database when the form loads
            LoadDataFromDatabase();

            // Load orders views
            LoadOrdersByUser();
            LoadOrders();
            LoadTopselling();


            CalculateAndDisplayTotalSales();

            // Add delete button column to the DataGridView for users
            DataGridViewButtonColumn deleteUserButtonColumn = new DataGridViewButtonColumn();
            deleteUserButtonColumn.Name = "DeleteUserButtonColumn";
            deleteUserButtonColumn.Text = "Delete User";
            deleteUserButtonColumn.UseColumnTextForButtonValue = true;

            // Customize the appearance of the delete button column for users
            DataGridViewCellStyle buttonStyle = deleteUserButtonColumn.DefaultCellStyle;
            buttonStyle.BackColor = Color.Red;
            buttonStyle.ForeColor = Color.White;

            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Add the column to the end of the DataGridView's column collection
            dataGridView1.Columns.Add(deleteUserButtonColumn);

            // Set the display index of the delete button column to be the last index
            deleteUserButtonColumn.DisplayIndex = dataGridView1.Columns.Count - 1;
        }

        // Method to load orders by user from the database
        private void LoadOrdersByUser()
        {
            try
            {
                // Open connection
                Connection.Open();

                // Query to retrieve data from the orders_by_user view
                string query = "SELECT * FROM orders_by_user";
                MySqlCommand command = new MySqlCommand(query, Connection);

                // Execute the query and load data into a DataTable
                DataTable dataTable = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);

                // Bind the DataTable to the DataGridView for total orders
                totalorders.DataSource = dataTable;

                // Center-align DataGridView content
                totalorders.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close connection
                Connection.Close();
            }
        }


        private void LoadOrders()
        {
            try
            {
                // Open connection
                Connection.Open();

                // Query to retrieve data from the orders_by_user view
                string query = "SELECT * FROM order_details";
                MySqlCommand command = new MySqlCommand(query, Connection);

                // Execute the query and load data into a DataTable
                DataTable dataTable = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);

                // Bind the DataTable to the DataGridView for total orders
                Orders.DataSource = dataTable;

                // Center-align DataGridView content
                Orders.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close connection
                Connection.Close();
            }
        }
        private void LoadTopselling()
        {
            try
            {
                // Open connection
                Connection.Open();

                // Query to retrieve data from the orders_by_user view
                string query = "SELECT * FROM top_selling_product";
                MySqlCommand command = new MySqlCommand(query, Connection);

                // Execute the query and load data into a DataTable
                DataTable dataTable = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);

                // Bind the DataTable to the DataGridView for total orders
                top.DataSource = dataTable;

                // Center-align DataGridView content
                top.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close connection
                Connection.Close();
            }
        }

        // Event handler for the CellContentClick event of the DataGridView for users
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the delete button for users is clicked
            if (e.ColumnIndex == dataGridView1.Columns["DeleteUserButtonColumn"].Index && e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Extract data from the selected row
                string userId = selectedRow.Cells["id"].Value.ToString(); // Assuming id is the primary key of the users table

                // Confirmation message
                DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Delete the user from the database
                    DeleteUser(userId);
                }
            }
        }

        // Event handler for the CellContentClick event of the DataGridView for products
        private void products_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the delete button for products is clicked
            if (e.ColumnIndex == products.Columns["DeleteProductButtonColumn"].Index && e.RowIndex >= 0)
            {
                // Get the ID of the selected product
                string productId = products.Rows[e.RowIndex].Cells["id"].Value.ToString();

                // Confirmation message
                DialogResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Delete the product from the database
                    DeleteProduct(productId);
                }
            }
        }

        // Function to delete a user from the database
        private void DeleteUser(string userId)
        {
            try
            {
                // Open the connection before executing the delete operation
                Connection.Open();

                // Query to delete the user from the users table
                string query = "DELETE FROM users WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, Connection);
                command.Parameters.AddWithValue("@id", userId);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Remove the deleted row from the DataGridView for users
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["id"].Value.ToString() == userId)
                        {
                            dataGridView1.Rows.Remove(row);
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("User deletion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection after executing the operation
                Connection.Close();
            }
        }

        // Function to delete a product from the database
        private void DeleteProduct(string productId)
        {
            try
            {
                // Query to delete the product from the products table
                string query = "DELETE FROM products WHERE id = @id";
                using (MySqlCommand command = new MySqlCommand(query, Connection))
                {
                    command.Parameters.AddWithValue("@id", productId);

                    // Open the connection before executing the delete operation
                    Connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh product details in the DataGridView for products
                        LoadProductDetails();
                    }
                    else
                    {
                        MessageBox.Show("Product deletion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection after executing the operation
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Retrieve product name and price from the text boxes
                    string productName = Productname.Text;
                    decimal productPrice;
                    if (!decimal.TryParse(price.Text, out productPrice))
                    {
                        MessageBox.Show("Invalid price format. Please enter a valid price.");
                        return;
                    }

                    // Open connection
                    connection.Open();

                    // Insert command
                    string query = "INSERT INTO products (name, price) VALUES (@name, @price)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@name", productName);
                    command.Parameters.AddWithValue("@price", productPrice);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product added successfully.");

                        // Refresh product details in the DataGridView for products
                        LoadProductDetails();

                        // Clear text boxes after adding product
                        Productname.Text = "";
                        price.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Failed to add product.");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            } // Connection automatically closed when leaving the 'using' block
        }

        private void export_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void ExportToExcel()
        {
            // Create a new Excel application
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;

            try
            {
                excelApp = new Excel.Application();
                excelApp.Visible = true;

                // Create a new workbook
                workbook = excelApp.Workbooks.Add();

                // Add company name and signature placeholder in Sheet1
                AddCompanyNameAndSignature(workbook);

                // Export order details data to Sheet2
                ExportOrderDetailsToSheet(workbook);

                // Display success message
                MessageBox.Show("Data exported to Excel successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Release Excel objects to free up resources
                ReleaseObject(workbook);
                ReleaseObject(excelApp);
            }
        }

        private void AddCompanyNameAndSignature(Excel.Workbook workbook)
        {
            try
            {
                // Access the first worksheet (Sheet1)
                Excel._Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

                // Add company name "Retroshelf" at cell A1
                sheet1.Cells[1, 3] = "Retroshelf";

                // Add signature placeholder below but not close at the company name
                sheet1.Cells[6, 3] = "Signature: ____________________";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding company name and signature: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportOrderDetailsToSheet(Excel.Workbook workbook)
        {
            try
            {
                // Add a new worksheet for order details (Sheet2)
                Excel._Worksheet sheet2 = (Excel.Worksheet)workbook.Sheets.Add();
                sheet2.Name = "Order Details";

                // Export order details data to Excel worksheet
                ExportDataToSheet(sheet2, Orders);

                // Generate clustered column graph for order details
                GenerateGraph(sheet2);

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting order details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportDataToSheet(Excel._Worksheet worksheet, DataGridView dataGridView)
        {
            try
            {
                // Export data from DataGridView to Excel worksheet
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 1, j + 1] = dataGridView.Rows[i].Cells[j].Value?.ToString() ?? "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data to sheet: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateGraph(Excel._Worksheet worksheet)
        {
            try
            {
                // Query to calculate total sales from the order_details view
                string query = "SELECT product_name, SUM(total_price) AS TotalPrice FROM order_details GROUP BY product_name";

                // Open connection
                Connection.Open();

                // Execute the query
                MySqlCommand command = new MySqlCommand(query, Connection);
                MySqlDataReader reader = command.ExecuteReader();

                int row = 2;

                while (reader.Read())
                {
                    worksheet.Cells[row, 6] = reader.GetString("product_name");
                    worksheet.Cells[row, 7] = reader.GetDecimal("TotalPrice");
                    row++;
                }

                // Close connection
                reader.Close();

                // Create a Chart object with increased horizontal position for more spacing
                Excel.ChartObjects charts = (Excel.ChartObjects)worksheet.ChartObjects();
                // Adjust the position of the chart for more spacing (e.g., 500 instead of 100)
                Excel.ChartObject chart = charts.Add(500, 100, 300, 300);
                Excel.Chart chartPage = chart.Chart;

                // Set chart data (Assuming your data range here)
                Excel.Range chartRange = worksheet.Range["F2", "G" + (row - 1)];
                chartPage.SetSourceData(chartRange);

                // Set chart type
                chartPage.ChartType = Excel.XlChartType.xlColumnClustered;

                // Set chart title
                chartPage.HasTitle = true;
                chartPage.ChartTitle.Text = "Order Details";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating graph: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close connection
                Connection.Close();
            }
        }


        private void ReleaseObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error releasing object: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void CalculateAndDisplayTotalSales()
        {
            try
            {
                // Open connection
                Connection.Open();

                // Query to calculate total sales from the order_details view
                string query = "SELECT SUM(total_price) AS TotalSales FROM order_details";
                MySqlCommand command = new MySqlCommand(query, Connection);
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    // Display total sales in the label
                    TotalSales.Text = "Total Sales: PHP" + result.ToString();
                }
                else
                {
                    // If no sales data found, display zero
                    TotalSales.Text = "Total Sales: PHP0.00";
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close connection
                Connection.Close();
            }
        }




    }
}
