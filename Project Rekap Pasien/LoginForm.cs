using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Rekap_Pasien
{
    public partial class LoginForm : Form
    {
        public static List<UserModel> listUser = new List<UserModel>();
        public static UserModel userModel = new UserModel();

        public LoginForm()
        {
            InitializeComponent();
            listUser = SqliteDataAccess.loadUser();
        }

        private void login()
        {
            if (SqliteDataAccess.CheckLogin(tbUsername.Text, tbPassword.Text))
            {
                this.Hide();
                var appForm = new AppForm();
                appForm.Closed += (s, args) => this.Show();
                appForm.Show();
                tbUsername.Text = "";
                tbPassword.Text = "";
            }
            else
            {
                MessageBox.Show("Username/Password salah!", "Error", MessageBoxButtons.OK);
            }
            //Console.WriteLine(EncryptPassword.Encrypt("admin", "zxc123"));
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void tbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbPassword.Text != null && tbUsername.Text != null)
                    login();
            }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbPassword.Text != null && tbUsername.Text != null)
                    login();
            }
        }
    }
}