using OnlineShoppingSystem.Controllers;
using OnlineShoppingSystem.Models;

namespace OnlineShoppingSystem.Views
{
    public partial class CategoryForm : Form
    {
        private readonly CategoryController _controller = new CategoryController();
        private int _selectedId = 0;

        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            try
            {
                dgvCategories.DataSource = _controller.GetCategories();
                dgvCategories.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot load data: " + ex.Message);
            }
        }

        private Category ReadForm()
        {
            return new Category
            {
                CategoryId = _selectedId,
                CategoryName = txtCategoryName.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.AddCategory(ReadForm());
                MessageBox.Show("Category saved.");
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
                _controller.EditCategory(ReadForm());
                MessageBox.Show("Category updated.");
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
                MessageBox.Show("Select a category first.");
                return;
            }
            if (MessageBox.Show("Delete this category?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                _controller.RemoveCategory(_selectedId);
                MessageBox.Show("Category deleted.");
                RefreshGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                // e.g. category still has products
                MessageBox.Show(ex.Message, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvCategories.DataSource = _controller.SearchCategories(txtSearch.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            RefreshGrid();
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvCategories.Rows[e.RowIndex];
            _selectedId = Convert.ToInt32(row.Cells["category_id"].Value);
            txtCategoryName.Text = Convert.ToString(row.Cells["category_name"].Value);
            txtDescription.Text = Convert.ToString(row.Cells["description"].Value);
        }

        private void ClearForm()
        {
            _selectedId = 0;
            txtCategoryName.Clear();
            txtDescription.Clear();
            txtCategoryName.Focus();
            dgvCategories.ClearSelection();
        }
    }
}
