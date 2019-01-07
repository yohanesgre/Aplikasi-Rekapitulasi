using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Rekap_Pasien
{
    public partial class SettingUC : UserControl
    {
        DataTable ut = new DataTable();

        public SettingUC()
        {
            InitializeComponent();
            initUserTable();
        }

        void initUserTable()
        {
            ut = new DataTable();
            ut.Columns.Add("no", typeof(int));
            ut.Columns.Add("user", typeof(string));
            ut.Columns.Add("pass", typeof(string));
            ut.Columns.Add("nama", typeof(string));
            ut.Columns.Add("jabatan", typeof(string));
            ut.Columns.Add("instalasi", typeof(string));
            ut.Columns.Add("role", typeof(int));
            int count = 0;
            AppForm.listUser = SqliteDataAccess.loadUser();
            foreach (UserModel user in AppForm.listUser)
            {
                count++;
                ut.Rows.Add(count, user.Username, EncryptPassword.Decrypt(user.Password, "zxc123"), user.Nama, user.Jabatan, user.Instalasi, user.Role);
            }
            dataGridView1.DataSource = ut;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == dataGridView1.Columns["updateButton"].Index)
            {
                UserModel newUser = new UserModel();
                newUser.Username = (string)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
                newUser.Password = EncryptPassword.Encrypt((string)dataGridView1.Rows[e.RowIndex].Cells[4].Value, "zxc123");
                newUser.Nama = (string)dataGridView1.Rows[e.RowIndex].Cells[5].Value;
                newUser.Jabatan = (string)dataGridView1.Rows[e.RowIndex].Cells[6].Value;
                newUser.Instalasi = (string)dataGridView1.Rows[e.RowIndex].Cells[7].Value;
                newUser.Role = (int)dataGridView1.Rows[e.RowIndex].Cells[8].Value;
                SqliteDataAccess.UpdateUser(ut.Rows[e.RowIndex][1].ToString(), newUser);
            }
            if (e.ColumnIndex == dataGridView1.Columns["deleteButton"].Index)
            {
                SqliteDataAccess.DeleteUser((string)dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                initUserTable();
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUserDialog.AddUser("Menambahkan User");
            initUserTable();
        }
    }

    public static class AddUserDialog
    {
        public static void AddUser(string caption)
        {
            Form prompt = new Form();
            prompt.Width = 320;
            prompt.Height = 230;
            prompt.Text = caption;
            prompt.StartPosition = FormStartPosition.CenterParent;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = "Username: ", AutoSize = true, Font = new Font("Microsoft San Serif", 15, FontStyle.Bold) };
            TextBox inputBox = new TextBox() { Left = 50, Top = 50, Width = 200, };
            Label textLabel2 = new Label() { Left = 50, Top = 80, Text = "Password: ", AutoSize = true, Font = new Font("Microsoft San Serif", 15, FontStyle.Bold) };
            TextBox inputBox2 = new TextBox() { Left = 50, Top = 110, Width = 200, };
            Button confirmation = new Button() { Text = "Ok", Left = 140, Width = 50, Top = 140 };
            string ruangan = null;
            confirmation.Click += (sender, e) =>
            {
                SqliteDataAccess.AddUser(new UserModel()
                { Username = inputBox.Text.ToString(),
                    Password = inputBox2.Text.ToString()});
                prompt.Close();
            };
            Button cancelBox = new Button() { Text = "Cancel", Left = 200, Width = 50, Top = 140 };
            cancelBox.Click += (sender, e) =>
            {
                prompt.Close();
            };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(textLabel2);
            prompt.Controls.Add(inputBox2);
            prompt.Controls.Add(cancelBox);
            prompt.ShowDialog();
        }
    }
}
