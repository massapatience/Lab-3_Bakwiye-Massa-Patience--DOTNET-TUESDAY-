namespace OnlineShoppingSystem.Views
{
    partial class ProductForm
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
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblProductName = new Label();
            txtProductName = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblPrice = new Label();
            numPrice = new NumericUpDown();
            lblQuantity = new Label();
            numQuantity = new NumericUpDown();
            lblImage = new Label();
            txtImage = new TextBox();
            btnSave = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnRefresh = new Button();
            dgvProducts = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(20, 23);
            lblCategory.Name = "lblCategory";
            lblCategory.TabIndex = 0;
            lblCategory.Text = "Category";
            // 
            // cmbCategory
            // 
            cmbCategory.Location = new Point(150, 20);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(260, 23);
            cmbCategory.TabIndex = 1;
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(20, 58);
            lblProductName.Name = "lblProductName";
            lblProductName.TabIndex = 2;
            lblProductName.Text = "Product Name";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(150, 55);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(260, 23);
            txtProductName.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(20, 93);
            lblDescription.Name = "lblDescription";
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(150, 90);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(400, 23);
            txtDescription.TabIndex = 5;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(20, 128);
            lblPrice.Name = "lblPrice";
            lblPrice.TabIndex = 6;
            lblPrice.Text = "Price (RWF)";
            // 
            // numPrice
            // 
            numPrice.Location = new Point(150, 125);
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(150, 23);
            numPrice.TabIndex = 7;
            numPrice.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numPrice.DecimalPlaces = 2;
            numPrice.ThousandsSeparator = true;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(20, 163);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.TabIndex = 8;
            lblQuantity.Text = "Quantity";
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(150, 160);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(150, 23);
            numQuantity.TabIndex = 9;
            numQuantity.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numQuantity.ThousandsSeparator = true;
            // 
            // lblImage
            // 
            lblImage.AutoSize = true;
            lblImage.Location = new Point(20, 198);
            lblImage.Name = "lblImage";
            lblImage.TabIndex = 10;
            lblImage.Text = "Image (file name)";
            // 
            // txtImage
            // 
            txtImage.Location = new Point(150, 195);
            txtImage.Name = "txtImage";
            txtImage.Size = new Size(260, 23);
            txtImage.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(150, 235);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 30);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(250, 235);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(90, 30);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(350, 235);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 30);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(450, 235);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(90, 30);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(20, 282);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(300, 23);
            txtSearch.TabIndex = 16;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(330, 280);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 28);
            btnSearch.TabIndex = 17;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(430, 280);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 28);
            btnRefresh.TabIndex = 18;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.Location = new Point(20, 320);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Size = new Size(820, 230);
            dgvProducts.TabIndex = 19;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.CellClick += dgvProducts_CellClick;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 580);
            Controls.Add(lblCategory);
            Controls.Add(cmbCategory);
            Controls.Add(lblProductName);
            Controls.Add(txtProductName);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(lblPrice);
            Controls.Add(numPrice);
            Controls.Add(lblQuantity);
            Controls.Add(numQuantity);
            Controls.Add(lblImage);
            Controls.Add(txtImage);
            Controls.Add(btnSave);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnRefresh);
            Controls.Add(dgvProducts);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Products";
            Load += ProductForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblProductName;
        private TextBox txtProductName;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblPrice;
        private NumericUpDown numPrice;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private Label lblImage;
        private TextBox txtImage;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private DataGridView dgvProducts;
    }
}
