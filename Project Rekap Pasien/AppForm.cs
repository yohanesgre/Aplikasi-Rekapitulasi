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
    public partial class AppForm : Form
    {
        public static List<Rekapitulasi> listRekapitulasi = new List<Rekapitulasi>();
        public static List<Indikator> listIndikator = new List<Indikator>();
        public static List<UserModel> listUser = new List<UserModel>();
        public static Rekapitulasi rekapitulasi = new Rekapitulasi();
        public static ArrayList ucList = new ArrayList();
        
        UserControl mUC;
        RekapitulasiUserControl rekapitulasiUserControl = new RekapitulasiUserControl();
        IndikatorUserControl indikatorUserControl = new IndikatorUserControl();
        GJBUserControl gJBUserControl = new GJBUserControl();
        SettingUC settingUserControl = new SettingUC();
        //SettingAccountCustomControl settingAccountCustomControl = new SettingAccountCustomControl();
        public static int menuClicked;

        public AppForm()
        {
            InitializeComponent();
            PanelUC.Controls.Clear();
            PanelUC.Controls.Add(rekapitulasiUserControl);
            rekapitulasiUserControl.Hide();
            ucList.Add(rekapitulasiUserControl);
            PanelUC.Controls.Add(indikatorUserControl);
            indikatorUserControl.Hide();
            ucList.Add(indikatorUserControl);
            PanelUC.Controls.Add(gJBUserControl);
            gJBUserControl.Hide();
            ucList.Add(gJBUserControl);
            PanelUC.Controls.Add(settingUserControl);
            settingUserControl.Hide();
            ucList.Add(settingUserControl);
            mUC = (UserControl) ucList[0];
            mUC.Show();
            menuClicked = 1;
            Console.WriteLine(LoginForm.userModel.Role);
        }

        private void selectMenu(int _menuCliked)
        {
            menuClicked = _menuCliked;
            switch (menuClicked)
            {
                case 1:
                    foreach (UserControl uc in ucList)
                    {
                        if (uc.Equals(rekapitulasiUserControl))
                        {                            
                            uc.Show();
                        }
                        else
                        {
                            uc.Hide();
                        }
                    }
                    break;
                case 2:
                    foreach (UserControl uc in ucList)
                    {
                        if (uc.Equals(indikatorUserControl))
                        {
                            uc.Show();
                        }
                        else
                        {
                            uc.Hide();
                        }
                    }
                    break;
                case 3:
                    foreach (UserControl uc in ucList)
                    {
                        if (uc.Equals(gJBUserControl))
                        {
                            uc.Show();
                        }
                        else
                        {
                            uc.Hide();
                        }
                    }
                    break;
                case 4:
                    foreach (UserControl uc in ucList)
                    {
                        if (uc.Equals(settingUserControl))
                        {
                            uc.Show();
                        }
                        else
                        {
                            uc.Hide();
                        }
                    }
                    break;
                default:
                    break;
            }
            
        }

        private void btnRekapitulasi_Click(object sender, EventArgs e)
        {
            SidePanel.Location = new Point(0, 3);
            selectMenu(1);
        }

        private void btnIndikator_Click(object sender, EventArgs e)
        {
            SidePanel.Location = new Point(0, 47);
            selectMenu(2);
        }

        private void btnGBJ_Click(object sender, EventArgs e)
        {
            SidePanel.Location = new Point(0, 91);
            selectMenu(3);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SidePanel.Location = new Point(0, 135);
            selectMenu(4);
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new LoginForm();
            loginForm.Closed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void AppForm_Load(object sender, EventArgs e)
        {
            if (LoginForm.userModel.Role != 1)
            {
                btnBantuan.Enabled = false;
            }
        }

        private void btnBantuan_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("User Guide.pdf");
        }
    }
}
