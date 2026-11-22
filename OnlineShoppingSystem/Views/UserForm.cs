using OnlineShoppingSystem.Controllers;
using OnlineShoppingSystem.Models;

namespace OnlineShoppingSystem.Views
{
    public partial class UserForm : Form
    {
        private readonly UserController _controller = new UserController();
        private int _selectedId = 0;

        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            try
            {
                dgvUsers.DataSource = _controller.GetUsers();
                dgvUsers.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot load data: " + ex.Message);
            }
        }

        private User ReadForm()
        {
            return new User
            {
                UserId = _selectedId,
                FullName = txtFullName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Password = txtPassword.Text,
                Phone = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Role = cmbRole.Text
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.AddUser(ReadForm());
                MessageBox.Show("User saved.");
                RefreshGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                // duplicate email is rejected by the database (UNIQUE)
                MessageBox.Show(ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.EditUser(ReadForm());
                MessageBox.Show("User updated.");
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
                MessageBox.Show("Select a user first.");
                return;
            }
            if (MessageBox.Show("Delete this user?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                _controller.RemoveUser(_selectedId);
                MessageBox.Show("User deleted.");
                RefreshGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                // e.g. user still has orders
                MessageBox.Show(ex.Message, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvUsers.DataSource = _controller.SearchUsers(txtSearch.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            RefreshGrid();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
            _selectedId = Convert.ToInt32(row.Cells["user_id"].Value);
            txtFullName.Text = Convert.ToString(row.Cells["full_name"].Value);
            txtEmail.Text = Convert.ToString(row.Cells["email"].Value);
            txtPassword.Clear(); // leave empty to keep old password
            txtPhone.Text = Convert.ToString(row.Cells["phone"].Value);
            txtAddress.Text = Convert.ToString(row.Cells["address"].Value);
            cmbRole.Text = Convert.ToString(row.Cells["role"].Value);
        }

        private void ClearForm()
        {
            _selectedId = 0;
            txtFullName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            cmbRole.SelectedIndex = -1;
            txtFullName.Focus();
            dgvUsers.ClearSelection();
        }
    }
}
