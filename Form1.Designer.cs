
namespace Espela_EDP_ACT4
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            pictureBox4 = new PictureBox();
            label3 = new Label();
            passwordbox = new TextBox();
            label1 = new Label();
            usernamebox = new TextBox();
            pictureBox5 = new PictureBox();
            loginbtn = new Button();
            pictureBox3 = new PictureBox();
            label4 = new Label();
            panel2 = new Panel();
            label5 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Linen;
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(button1);
            panel1.Name = "panel1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.BackColor = Color.Transparent;
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Name = "label2";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            resources.ApplyResources(button1, "button1");
            button1.FlatAppearance.BorderSize = 0;
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            resources.ApplyResources(pictureBox4, "pictureBox4");
            pictureBox4.Name = "pictureBox4";
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.BackColor = Color.White;
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Name = "label3";
            // 
            // passwordbox
            // 
            resources.ApplyResources(passwordbox, "passwordbox");
            passwordbox.Name = "passwordbox";
            passwordbox.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.WhiteSmoke;
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Name = "label1";
            // 
            // usernamebox
            // 
            resources.ApplyResources(usernamebox, "usernamebox");
            usernamebox.Name = "usernamebox";
            usernamebox.TextChanged += textBox2_TextChanged;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Black;
            resources.ApplyResources(pictureBox5, "pictureBox5");
            pictureBox5.Name = "pictureBox5";
            pictureBox5.TabStop = false;
            // 
            // loginbtn
            // 
            loginbtn.BackColor = SystemColors.ActiveCaptionText;
            loginbtn.ForeColor = SystemColors.ButtonFace;
            resources.ApplyResources(loginbtn, "loginbtn");
            loginbtn.Name = "loginbtn";
            loginbtn.UseVisualStyleBackColor = false;
            loginbtn.Click += loginbtn_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Black;
            resources.ApplyResources(pictureBox3, "pictureBox3");
            pictureBox3.Name = "pictureBox3";
            pictureBox3.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.BackColor = Color.White;
            label4.FlatStyle = FlatStyle.Flat;
            label4.ForeColor = Color.FromArgb(0, 0, 192);
            label4.Name = "label4";
            label4.Click += label4_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            resources.ApplyResources(panel2, "panel2");
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(loginbtn);
            panel2.Controls.Add(pictureBox5);
            panel2.Controls.Add(usernamebox);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(passwordbox);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(pictureBox4);
            panel2.Name = "panel2";
            panel2.Paint += panel2_Paint;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.BackColor = Color.White;
            label5.FlatStyle = FlatStyle.Flat;
            label5.ForeColor = Color.FromArgb(0, 0, 192);
            label5.Name = "label5";
            label5.Click += label5_Click;
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(panel2);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            WindowState = FormWindowState.Minimized;
            Load += Login_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            OpenForgotForm();
        }

        private void OpenForgotForm()
        {
            // Create an instance of the Forgot form
            Forgot forgotForm = new Forgot();

            // Show the Forgot form
            forgotForm.Show();

            // Hide the current form
            this.Hide();
        }


        #endregion

        private Panel panel1;
        private Button button1;
        private Label label2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox4;
        private Label label3;
        private TextBox passwordbox;
        private Label label1;
        private TextBox usernamebox;
        private PictureBox pictureBox5;
        private Button loginbtn;
        private PictureBox pictureBox3;
        private Label label4;
        private Panel panel2;
        private Label label5;
    }
}
