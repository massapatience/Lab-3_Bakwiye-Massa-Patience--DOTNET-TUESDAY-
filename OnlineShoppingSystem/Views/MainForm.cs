using OnlineShoppingSystem.Models;

namespace OnlineShoppingSystem.Views
{
    public partial class MainForm : Form
    {
        private readonly User _user;

        public MainForm(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, " + _user.FullName + " (" + _user.Role + ")";

            // Only the admin can manage users and categories
            if (_user.Role != "Admin")
            {
                btnUsers.Enabled = false;
                btnCategories.Enabled = false;
            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            new UserForm().ShowDialog();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            new CategoryForm().ShowDialog();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            new ProductForm().ShowDialog();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            new OrderForm().ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
