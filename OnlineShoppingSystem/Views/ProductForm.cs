using OnlineShoppingSystem.Controllers;
using OnlineShoppingSystem.Models;

namespace OnlineShoppingSystem.Views
{
    public partial class ProductForm : Form
    {
        private readonly ProductController _controller = new ProductController();
        private readonly CategoryController _categoryController = new CategoryController();
        private int _selectedId = 0;

        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            try
            {
                // fill the category drop-down
                cmbCategory.DataSource = _categoryController.GetCategories();
                cmbCategory.DisplayMember = "category_name";
                cmbCategory.ValueMember = "category_id";
                cmbCategory.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot load categories: " + ex.Message);
            }
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            try
            {
                dgvProducts.DataSource = _controller.GetProducts();
                dgvProducts.Columns["category_id"].Visible = false;
                dgvProducts.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot load data: " + ex.Message);
            }
        }

        private Product ReadForm()
        {
            return new Product
            {
                ProductId = _selectedId,
                CategoryId = cmbCategory.SelectedValue == null ? 0 : Convert.ToInt32(cmbCategory.SelectedValue),
                ProductName = txtProductName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Price = numPrice.Value,
                Quantity = (int)numQuantity.Value,
                Image = txtImage.Text.Trim()
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.AddProduct(ReadForm());
                MessageBox.Show("Product saved.");
                RefreshGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.EditProduct(ReadForm());
                MessageBox.Show("Product updated.");
                RefreshGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedId <= 0)
            {
                MessageBox.Show("Select a product first.");
                return;
            }
            if (MessageBox.Show("Delete this product?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                _controller.RemoveProduct(_selectedId);
                MessageBox.Show("Product deleted.");
                RefreshGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                // e.g. product is used in an order
                MessageBox.Show(ex.Message, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvProducts.DataSource = _controller.SearchProducts(txtSearch.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            RefreshGrid();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
            _selectedId = Convert.ToInt32(row.Cells["product_id"].Value);
            cmbCategory.SelectedValue = Convert.ToInt32(row.Cells["category_id"].Value);
            txtProductName.Text = Convert.ToString(row.Cells["product_name"].Value);
            txtDescription.Text = Convert.ToString(row.Cells["description"].Value);
            numPrice.Value = Convert.ToDecimal(row.Cells["price"].Value);
            numQuantity.Value = Convert.ToInt32(row.Cells["quantity"].Value);
            txtImage.Text = Convert.ToString(row.Cells["image"].Value);
        }

        private void ClearForm()
        {
            _selectedId = 0;
            cmbCategory.SelectedIndex = -1;
            txtProductName.Clear();
            txtDescription.Clear();
            numPrice.Value = 0;
            numQuantity.Value = 0;
            txtImage.Clear();
            txtProductName.Focus();
            dgvProducts.ClearSelection();
        }
    }
}
