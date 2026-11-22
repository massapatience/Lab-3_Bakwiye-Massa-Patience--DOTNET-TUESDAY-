using OnlineShoppingSystem.Controllers;
using OnlineShoppingSystem.Models;

namespace OnlineShoppingSystem.Views
{
    public partial class OrderForm : Form
    {
        private readonly OrderController _controller = new OrderController();
        private readonly UserController _userController = new UserController();
        private int _selectedId = 0;

        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            try
            {
                // fill the customer drop-down
                cmbCustomer.DataSource = _userController.GetCustomers();
                cmbCustomer.DisplayMember = "full_name";
                cmbCustomer.ValueMember = "user_id";
                cmbCustomer.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot load customers: " + ex.Message);
            }
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            try
            {
                dgvOrders.DataSource = _controller.GetOrders();
                dgvOrders.Columns["user_id"].Visible = false;
                dgvOrders.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot load data: " + ex.Message);
            }
        }

        private Order ReadForm()
        {
            return new Order
            {
                OrderId = _selectedId,
                UserId = cmbCustomer.SelectedValue == null ? 0 : Convert.ToInt32(cmbCustomer.SelectedValue),
                OrderDate = dtpOrderDate.Value,
                TotalAmount = numTotal.Value,
                OrderStatus = cmbStatus.Text
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.AddOrder(ReadForm());
                MessageBox.Show("Order saved.");
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
                _controller.EditOrder(ReadForm());
                MessageBox.Show("Order updated.");
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
                MessageBox.Show("Select an order first.");
                return;
            }
            if (MessageBox.Show("Delete this order?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                _controller.RemoveOrder(_selectedId);
                MessageBox.Show("Order deleted.");
                RefreshGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvOrders.DataSource = _controller.SearchOrders(txtSearch.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            RefreshGrid();
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvOrders.Rows[e.RowIndex];
            _selectedId = Convert.ToInt32(row.Cells["order_id"].Value);
            cmbCustomer.SelectedValue = Convert.ToInt32(row.Cells["user_id"].Value);
            dtpOrderDate.Value = Convert.ToDateTime(row.Cells["order_date"].Value);
            numTotal.Value = Convert.ToDecimal(row.Cells["total_amount"].Value);
            cmbStatus.Text = Convert.ToString(row.Cells["order_status"].Value);
        }

        private void ClearForm()
        {
            _selectedId = 0;
            cmbCustomer.SelectedIndex = -1;
            dtpOrderDate.Value = DateTime.Now;
            numTotal.Value = 0;
            cmbStatus.SelectedIndex = -1;
            dgvOrders.ClearSelection();
        }
    }
}
