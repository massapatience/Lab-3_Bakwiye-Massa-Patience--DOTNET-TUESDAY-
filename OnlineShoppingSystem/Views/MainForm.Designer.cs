namespace OnlineShoppingSystem.Views
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblWelcome = new Label();
            btnUsers = new Button();
            btnCategories = new Button();
            btnProducts = new Button();
            btnOrders = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWelcome.Location = new Point(30, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            // 
            // btnUsers
            // 
            btnUsers.Location = new Point(30, 70);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(300, 40);
            btnUsers.TabIndex = 1;
            btnUsers.Text = "Manage Users";
            btnUsers.UseVisualStyleBackColor = true;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnCategories
            // 
            btnCategories.Location = new Point(30, 120);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(300, 40);
            btnCategories.TabIndex = 2;
            btnCategories.Text = "Manage Categories";
            btnCategories.UseVisualStyleBackColor = true;
            btnCategories.Click += btnCategories_Click;
            // 
            // btnProducts
            // 
            btnProducts.Location = new Point(30, 170);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(300, 40);
            btnProducts.TabIndex = 3;
            btnProducts.Text = "Manage Products";
            btnProducts.UseVisualStyleBackColor = true;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnOrders
            // 
            btnOrders.Location = new Point(30, 220);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(300, 40);
            btnOrders.TabIndex = 4;
            btnOrders.Text = "Manage Orders";
            btnOrders.UseVisualStyleBackColor = true;
            btnOrders.Click += btnOrders_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(30, 270);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(300, 40);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 330);
            Controls.Add(lblWelcome);
            Controls.Add(btnUsers);
            Controls.Add(btnCategories);
            Controls.Add(btnProducts);
            Controls.Add(btnOrders);
            Controls.Add(btnLogout);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Menu - Online Shopping System";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Button btnUsers;
        private Button btnCategories;
        private Button btnProducts;
        private Button btnOrders;
        private Button btnLogout;
    }
}
