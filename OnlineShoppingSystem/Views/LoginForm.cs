using OnlineShoppingSystem.Controllers;
using OnlineShoppingSystem.Models;

namespace OnlineShoppingSystem.Views
{
    public partial class LoginForm : Form
    {
        private readonly UserController _controller = new UserController();

        public LoginForm()
        {
            InitializeComponent();
            AcceptButton = btnLogin; // Enter key = Login
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                User user = _controller.Login(txtEmail.Text, txtPassword.Text);
                Hide();
                new MainForm(user).ShowDialog();
                // back from main menu (logout)
                txtPassword.Clear();
                Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
