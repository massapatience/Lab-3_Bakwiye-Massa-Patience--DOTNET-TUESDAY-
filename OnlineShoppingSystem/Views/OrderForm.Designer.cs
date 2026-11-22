namespace OnlineShoppingSystem.Views
{
    partial class OrderForm
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
            lblCustomer = new Label();
            cmbCustomer = new ComboBox();
            lblOrderDate = new Label();
            dtpOrderDate = new DateTimePicker();
            lblTotal = new Label();
            numTotal = new NumericUpDown();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnSave = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnRefresh = new Button();
            dgvOrders = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(20, 23);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.TabIndex = 0;
            lblCustomer.Text = "Customer";
            // 
            // cmbCustomer
            // 
            cmbCustomer.Location = new Point(150, 20);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(260, 23);
            cmbCustomer.TabIndex = 1;
            cmbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            // lblOrderDate
            // 
            lblOrderDate.AutoSize = true;
            lblOrderDate.Location = new Point(20, 58);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.TabIndex = 2;
            lblOrderDate.Text = "Order Date";
            // 
            // dtpOrderDate
            // 
            dtpOrderDate.Location = new Point(150, 55);
            dtpOrderDate.Name = "dtpOrderDate";
            dtpOrderDate.Size = new Size(150, 23);
            dtpOrderDate.TabIndex = 3;
            dtpOrderDate.Format = DateTimePickerFormat.Short;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(20, 93);
            lblTotal.Name = "lblTotal";
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Total Amount";
            // 
            // numTotal
            // 
            numTotal.Location = new Point(150, 90);
            numTotal.Name = "numTotal";
            numTotal.Size = new Size(150, 23);
            numTotal.TabIndex = 5;
            numTotal.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numTotal.DecimalPlaces = 2;
            numTotal.ThousandsSeparator = true;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(20, 128);
            lblStatus.Name = "lblStatus";
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Order Status";
            // 
            // cmbStatus
            // 
            cmbStatus.Location = new Point(150, 125);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(150, 23);
            cmbStatus.TabIndex = 7;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.AddRange(new object[] { "Pending", "Paid", "Shipped", "Delivered", "Cancelled" });
            // 
            // btnSave
            // 
            btnSave.Location = new Point(150, 165);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 30);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(250, 165);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(90, 30);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(350, 165);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 30);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(450, 165);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(90, 30);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(20, 212);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(300, 23);
            txtSearch.TabIndex = 12;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(330, 210);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 28);
            btnSearch.TabIndex = 13;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(430, 210);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 28);
            btnRefresh.TabIndex = 14;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvOrders
            // 
            dgvOrders.Location = new Point(20, 250);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.Size = new Size(820, 230);
            dgvOrders.TabIndex = 15;
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.ReadOnly = true;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.MultiSelect = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.CellClick += dgvOrders_CellClick;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 510);
            Controls.Add(lblCustomer);
            Controls.Add(cmbCustomer);
            Controls.Add(lblOrderDate);
            Controls.Add(dtpOrderDate);
            Controls.Add(lblTotal);
            Controls.Add(numTotal);
            Controls.Add(lblStatus);
            Controls.Add(cmbStatus);
            Controls.Add(btnSave);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnRefresh);
            Controls.Add(dgvOrders);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "OrderForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Orders";
            Load += OrderForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCustomer;
        private ComboBox cmbCustomer;
        private Label lblOrderDate;
        private DateTimePicker dtpOrderDate;
        private Label lblTotal;
        private NumericUpDown numTotal;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private DataGridView dgvOrders;
    }
}
