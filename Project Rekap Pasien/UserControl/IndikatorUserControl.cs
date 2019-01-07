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
    public partial class IndikatorUserControl : UserControl
    {
        DataTable dt = new DataTable();

        string namaRuangan;
        int tahunSelected;

        public IndikatorUserControl()
        {
            InitializeComponent();
        }
        //-------------------------------------------- Public Method ---------------------------------------//

        public void CalculateIndikator(int tahun, string ruangan)
        {
            int count = 0;
            string data = null;
            float[] value = new float[12];
            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        data = "BOR";
                        for (int j = 0; j < 12; j++)
                        {
                            value[j] = Formula.calculateBOR(showData("Hari Perawatan", j), showData("Jumlah Tempat Tidur", j), showData("Jumlah Periode", j));
                        }
                        break;
                    case 1:
                        data = "ALOS";
                        for (int j = 0; j < 12; j++)
                        {
                            value[j] = Formula.calculateALOS(showData("Hari Perawatan", j), showData("Pasien Keluar (H&M)", j));
                        }
                        break;
                    case 2:
                        data = "TOI";
                        for (int j = 0; j < 12; j++)
                        {
                            value[j] = Formula.calculateTOI(showData("Jumlah Tempat Tidur", j), showData("Jumlah Periode", j), showData("Hari Perawatan", j), showData("Pasien Keluar (H&M)", j));
                        }
                        break;
                    case 3:
                        data = "BTO";
                        for (int j = 0; j < 12; j++)
                        {
                            value[j] = Formula.calculateBTO(showData("Pasien Keluar (H&M)", j), showData("Jumlah Tempat Tidur", j));
                        }
                        break;
                    case 4:
                        data = "NDR";
                        for (int j = 0; j < 12; j++)
                        {
                            value[j] = Formula.calculateNDR(showData("Pasien Mati >= 48 jam", j), showData("Pasien Keluar (H&M)", j));
                        }
                        break;
                    case 5:
                        data = "GDR";
                        for (int j = 0; j < 12; j++)
                        {
                            value[j] = Formula.calculateGDR(showData("Pasien Mati Keseluruhan", j), showData("Pasien Keluar (H&M)", j));
                        }
                        break;
                    default:
                        break;
                }
                count++;
                float rerata = 0;
                for (int j = 0; j < 12; j++)
                {
                    rerata += value[j];
                }
                rerata /= 12;
                Indikator indikator = new Indikator
                {
                    Id = count,
                    Ruangan = ruangan,
                    Tahun = tahun,
                    Data = data,
                    Januari = value[0],
                    Februari = value[1],
                    Maret = value[2],
                    April = value[3],
                    Mei = value[4],
                    Juni = value[5],
                    Juli = value[6],
                    Agustus = value[7],
                    September = value[8],
                    Oktober = value[9],
                    November = value[10],
                    Desember = value[11],
                    Total = rerata
                };
                AppForm.listIndikator.Add(indikator);
            }
        }

        public void RefreshRuangan()
        {
            if (listView1.Items.Count > 0 || listView1.Items != null)
            {
                listView1.Items.Clear();
            }
            AppForm.listRekapitulasi = SqliteDataAccess.getAllRekapitulasiDataAll();
            var deleteDuplicateRuangan = AppForm.listRekapitulasi.Distinct(new RuanganComparer());
            deleteDuplicateRuangan = deleteDuplicateRuangan.OrderBy(rekap => rekap.Ruangan).ToList();
            var items = listView1.Items.Cast<ListViewItem>()
                                 .Select(item => item.Text)
                                 .ToList();
            foreach (Rekapitulasi rekap in deleteDuplicateRuangan)
            {
                bool alreadyExists = items.Any(x => x == rekap.Ruangan.ToString());
                if (!alreadyExists)
                    listView1.Items.Add("Ruangan " + rekap.Ruangan.ToString());
            }
            listViewTahun.Refresh();
        }

        public void RefreshTahunInListView()
        {
            AppForm.listRekapitulasi = SqliteDataAccess.getAllRekapitulasiDataOfRuangan(namaRuangan);
            var deleteDuplicateTahun = AppForm.listRekapitulasi.Distinct(new TahunComparer());
            deleteDuplicateTahun = deleteDuplicateTahun.OrderBy(rekap => rekap.Tahun).ToList();
            var items = listViewTahun.Items.Cast<ListViewItem>()
                                 .Select(item => item.Text)
                                 .ToList();
            foreach (Rekapitulasi rekap in deleteDuplicateTahun)
            {
                bool alreadyExists = items.Any(x => x == rekap.Tahun.ToString());
                if (!alreadyExists)
                    listViewTahun.Items.Add(rekap.Tahun.ToString());
            }
            dataGridView1.Visible = false;
            listViewTahun.Visible = true;
            listViewTahun.Refresh();
        }

        //-------------------------------------------- End of Public Method ----------------------------------------//
        int showData(string data, int i)
        {
            int value = 0;
            Rekapitulasi rekap = AppForm.listRekapitulasi.Find(x => String.Equals(x.Data, data, StringComparison.CurrentCulture));
            switch (i)
            {
                case 0:
                    value = rekap.Januari;
                    break;
                case 1:
                    value = rekap.Februari;
                    break;
                case 2:
                    value = rekap.Maret;
                    break;
                case 3:
                    value = rekap.April;
                    break;
                case 4:
                    value = rekap.Mei;
                    break;
                case 5:
                    value = rekap.Juni;
                    break;
                case 6:
                    value = rekap.Juli;
                    break;
                case 7:
                    value = rekap.Agustus;
                    break;
                case 8:
                    value = rekap.September;
                    break;
                case 9:
                    value = rekap.Oktober;
                    break;
                case 10:
                    value = rekap.November;
                    break;
                case 11:
                    value = rekap.Desember;
                    break;
                default:
                    break;
            }
            return value;
        }

        void initDataIndikator()
        {   
            dt = new DataTable();
            dt.Columns.Add("no", typeof(int));
            dt.Columns.Add("indikator", typeof(string));
            dt.Columns.Add("januari", typeof(float));
            dt.Columns.Add("februari", typeof(float));
            dt.Columns.Add("maret", typeof(float));
            dt.Columns.Add("april", typeof(float));
            dt.Columns.Add("mei", typeof(float));
            dt.Columns.Add("juni", typeof(float));
            dt.Columns.Add("juli", typeof(float));
            dt.Columns.Add("agustus", typeof(float));
            dt.Columns.Add("september", typeof(float));
            dt.Columns.Add("oktober", typeof(float));
            dt.Columns.Add("november", typeof(float));
            dt.Columns.Add("desember", typeof(float));
            dt.Columns.Add("total", typeof(float));
            foreach (Indikator ind in AppForm.listIndikator)
                dt.Rows.Add(ind.Id, ind.Data, ind.Januari, ind.Februari, ind.Maret, ind.April, ind.Mei, ind.Juni, ind.Juli, ind.Agustus, ind.September, ind.Oktober, ind.November, ind.Desember, ind.Total);
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;
        }

        private void listViewTahun_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            tahunSelected = Int32.Parse(e.Item.Text);
            AppForm.listIndikator = SqliteDataAccess.getAllIndikatorDataOfRuanganTahun(namaRuangan, tahunSelected);
            listViewTahun.Visible = false;
            initDataIndikator();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewTahun.Items.Count != 0)
            {
                listViewTahun.Items.Clear();
            }
            int indexOfSpace = e.Item.Text.IndexOf(" ");
            namaRuangan = e.Item.Text.Substring(indexOfSpace + 1);
            RefreshTahunInListView();
        }

        private void IndikatorUserControl_Load(object sender, EventArgs e)
        {
            lblNamaUser.Text = LoginForm.userModel.Nama;
            lblUsername.Text = LoginForm.userModel.Username;
            RefreshRuangan();
        }

        private void IndikatorUserControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                RefreshRuangan();
                RefreshTahunInListView();
            }
        }
    }
}
