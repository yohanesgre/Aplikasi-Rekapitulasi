using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project_Rekap_Pasien
{
    public partial class GJBUserControl : UserControl
    {
        string namaRuangan;
        int tahunSelected;
        int indexTahunSelected;

        IndikatorUserControl indikatorUC = new IndikatorUserControl();

        List<Indikator> listIndikator = new List<Indikator>();

        public GJBUserControl()
        {
            InitializeComponent();
            chartLoad();
        }

        double calculateBORY(double BOR)
        {
            return BOR / 10;
        }
        double calculateBORX(double ALOS)
        {
            return 10 - ALOS;
        }
        double calculateBTOXY(int periode, double BTO)
        {
            return periode / BTO;
        }

        float round(float a)
        {
            float result = 0;
            result = (float)Math.Round((double)a, 2);
            return result;
        }

        public static string DoFormat(float myNumber)
        {
            var s = string.Format("{0:0.00}", myNumber);
            return s;
        }

        void chartLoad()
        {
            var chart = chart1.ChartAreas[0];
            chart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;

            chart.AxisX.MajorGrid.LineColor = Color.Gray;
            chart.AxisY.MajorGrid.LineColor = Color.Gray;

            chart.AxisY.LabelStyle.Format = "";
            chart.AxisX.LabelStyle.Format = "";
            chart.AxisX.LabelStyle.IsEndLabelVisible = true;

            chart.AxisX.Minimum = 0;
            chart.AxisY.Minimum = 0;

            chart.AxisX.Maximum = 20;
            chart.AxisY.Maximum = 20;

            chart.AxisY.ScaleView.Zoom(0, 20);

            chart.AxisX.Interval = 1;
            chart.AxisY.Interval = 1;
        }

        void initChart()
        {
            if (chart1.Series.Count > 0)
            {
                chart1.Series.Clear();
            }

            Series efisien1 = new Series();
            efisien1.Name = "Daerah Efisien";
            efisien1.IsVisibleInLegend = true;
            efisien1.Color = Color.Yellow;
            efisien1.ChartType = SeriesChartType.Line;
            efisien1.Points.AddXY(1, 3);
            efisien1.Points.AddXY(3, 9);
            efisien1.BorderWidth = 2;

            Series efisien2 = new Series();
            efisien2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            efisien2.Color = Color.Yellow;
            efisien2.IsVisibleInLegend = false;
            efisien2.Points.AddXY(3, 9);
            efisien2.Points.AddXY(3, 15);
            efisien2.BorderWidth = 2;

            Series efisien3 = new Series();
            efisien3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            efisien3.Color = Color.Yellow;
            efisien3.IsVisibleInLegend = false;
            efisien3.Points.AddXY(1, 15);
            efisien3.Points.AddXY(3, 15);
            efisien3.BorderWidth = 2;

            Series efisien4 = new Series();
            efisien4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            efisien4.Color = Color.Yellow;
            efisien4.IsVisibleInLegend = false;
            efisien4.Points.AddXY(1, 3);
            efisien4.Points.AddXY(1, 15);
            efisien4.BorderWidth = 2;

            chart1.Series.Add(efisien1);
            chart1.Series.Add(efisien2);
            chart1.Series.Add(efisien3);
            chart1.Series.Add(efisien4);
        }

        void clearChart()
        {
            if (chart1.Series.Count > 0)
            {
                chart1.Series.Clear();
            }
        }

        void createChart(string bulan, double BORX, double BORY, double BTOXY, int periode)
        {
            Series BOR = new Series();
            BOR.Name = "BOR " + bulan + "\n" + BORY.ToString("0.00") + "%\n";
            BOR.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            BOR.Color = Color.Blue;
            BOR.IsVisibleInLegend = true;
            BOR.BorderWidth = 2;
            BOR.Points.AddXY(0, 0);
            BOR.Points.AddXY(calculateBORX(BORX), calculateBORY(BORY));
            chart1.Series.Add(BOR);

            Series BTO = new Series();
            BTO.Name = "BTO " + bulan + "\n" + calculateBTOXY(periode, BTOXY).ToString("0.00") + "\n";
            BTO.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            BTO.Color = Color.Red;
            BTO.IsVisibleInLegend = true;
            BTO.BorderWidth = 2;
            BTO.Points.AddXY(0, calculateBTOXY(periode, BTOXY));
            BTO.Points.AddXY(calculateBTOXY(periode, BTOXY), 0);
            chart1.Series.Add(BTO);
        }

        private void refreshRuangan()
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
            listView1.Refresh();
        }

        private void refreshTahunInComboBox()
        {
            if (cbTahun.Items.Count > 0) {
                cbTahun.Items.Clear();
            }
            AppForm.listRekapitulasi = SqliteDataAccess.getAllRekapitulasiDataOfRuangan(namaRuangan);
            var deleteDuplicateTahun = AppForm.listRekapitulasi.Distinct(new TahunComparer());
            deleteDuplicateTahun = deleteDuplicateTahun.OrderBy(rekap => rekap.Tahun).ToList();
            foreach (Rekapitulasi rekap in deleteDuplicateTahun)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = rekap.Tahun.ToString();
                item.Value = rekap.Tahun;
                cbTahun.Items.Add(item);
            }
            cbTahun.Refresh();
        }

        void changeTextInTextBox(float BOR, float TOI, float ALOS, float BTO)
        {
            tbBOR.Text = BOR.ToString();
            tbTOI.Text = TOI.ToString();
            tbALOS.Text = ALOS.ToString();
            tbBTO.Text = BTO.ToString();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            int indexOfSpace = e.Item.Text.IndexOf(" ");
            namaRuangan = e.Item.Text.Substring(indexOfSpace + 1);
            refreshTahunInComboBox();
        }

        private void cbTahun_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItemValue = (cbTahun.SelectedItem as ComboboxItem).Value.ToString();
            if (selectedItemValue != null && selectedItemValue != "" && selectedItemValue != " ")
            {
                tahunSelected = Int32.Parse(selectedItemValue);
            }
        }

        private void cbPeriode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tahunSelected == null || tahunSelected <= 0)
            {
                return;
            }
            AppForm.listIndikator = SqliteDataAccess.getAllIndikatorDataOfRuanganTahun(namaRuangan, tahunSelected);
            AppForm.listRekapitulasi = SqliteDataAccess.getAllRekapitulasiDataOfRuanganTahun(namaRuangan, tahunSelected);
            int listALOS = AppForm.listIndikator.FindIndex(x => x.Data == "ALOS" && x.Tahun == tahunSelected);
            int listBOR = AppForm.listIndikator.FindIndex(x => x.Data == "BOR" && x.Tahun == tahunSelected);
            int listBTO = AppForm.listIndikator.FindIndex(x => x.Data == "BTO" && x.Tahun == tahunSelected);
            int listTOI = AppForm.listIndikator.FindIndex(x => x.Data == "TOI" && x.Tahun == tahunSelected);
            Indikator indikatorBOR = AppForm.listIndikator[listBOR]; /*BORY*/
            Indikator indikatorALOS = AppForm.listIndikator[listALOS]; /*BORX*/
            Indikator indikatorBTO = AppForm.listIndikator[listBTO];
            Indikator indikatorTOI = AppForm.listIndikator[listTOI];

            int hariPerawatan = 0;
            int pasienKeluar = 0;
            int jumlahPeriode = 0;
            int tempatTidur = 0;
            float ALOS = 0;
            float BOR = 0;
            float BTO = 0;
            float TOI = 0;

            clearChart();
            if (tbBOR.Text != "" && tbTOI.Text != "" && tbALOS.Text != "" && tbBTO.Text != "")
            {
                tbBOR.Text = "";
                tbTOI.Text = "";
                tbALOS.Text = "";
                tbBTO.Text = "";
            }
            int index = cbPeriode.SelectedIndex;
            switch (index)
            {
                case 0:
                    ALOS = round(indikatorALOS.Januari);
                    BOR = round(indikatorBOR.Januari);
                    BTO = round(indikatorBTO.Januari);
                    TOI = round(indikatorTOI.Januari);
                    if (indikatorALOS.Januari == 0 || indikatorBOR.Januari == 0 || indikatorBTO.Januari == 0)
                        break;
                    changeTextInTextBox(BOR, TOI, ALOS, BTO);
                    initChart();
                    foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
                    {
                        if (rekap.Data == "Jumlah Periode")
                            jumlahPeriode = rekap.Januari;
                    }
                    createChart("Januari", ALOS, BOR, BTO, jumlahPeriode);
                    break;
                case 1:
                    ALOS = round(indikatorALOS.Februari);
                    BOR = round(indikatorBOR.Februari);
                    BTO = round(indikatorBTO.Februari);
                    TOI = round(indikatorTOI.Februari);
                    if (indikatorALOS.Februari == 0 || indikatorBOR.Februari == 0 || indikatorBTO.Februari == 0)
                        break;
                    changeTextInTextBox(BOR, TOI, ALOS, BTO);
                    initChart();
                    foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
                    {
                        if (rekap.Data == "Jumlah Periode")
                            jumlahPeriode = rekap.Februari;
                    }
                    createChart("Februari", ALOS, BOR, BTO, jumlahPeriode);
                    break;
                case 2:
                    ALOS = round(indikatorALOS.Maret);
                    BOR = round(indikatorBOR.Maret);
                    BTO = round(indikatorBTO.Maret);
                    TOI = round(indikatorTOI.Maret);
                    if (indikatorALOS.Maret == 0 || indikatorBOR.Maret == 0 || indikatorBTO.Maret == 0)
                        break;
                    changeTextInTextBox(BOR, TOI, ALOS, BTO);
                    initChart();
                    foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
                    {
                        if (rekap.Data == "Jumlah Periode")
                            jumlahPeriode = rekap.Maret;
                    }
                    createChart("Maret", ALOS, BOR, BTO, jumlahPeriode);
                    break;
                case 3:
                    ALOS = round(indikatorALOS.April);
                    BOR = round(indikatorBOR.April);
                    BTO = round(indikatorBTO.April);
                    TOI = round(indikatorTOI.April);
                    if (indikatorALOS.April == 0 || indikatorBOR.April == 0 || indikatorBTO.April == 0)
                        break;
                    changeTextInTextBox(BOR, TOI, ALOS, BTO);
                    initChart();
                    foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
                    {
                        if (rekap.Data == "Jumlah Periode")
                            jumlahPeriode = rekap.April;
                    }
                    createChart("April", ALOS, BOR, BTO, jumlahPeriode);
                    break;
                case 4:
                    ALOS = round(indikatorALOS.Mei);
                    BOR = round(indikatorBOR.Mei);
                    BTO = round(indikatorBTO.Mei);
                    TOI = round(indikatorTOI.Mei);
                    if (indikatorALOS.Mei == 0 || indikatorBOR.Mei == 0 || indikatorBTO.Mei == 0)
                        break;
                    changeTextInTextBox(BOR, TOI, ALOS, BTO);
                    initChart();
                    foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
                    {
                        if (rekap.Data == "Jumlah Periode")
                            jumlahPeriode = rekap.Mei;
                    }
                    createChart("Mei", ALOS, BOR, BTO, jumlahPeriode);
                    break;
                case 5:
                    ALOS = round(indikatorALOS.Juni);
                    BOR = round(indikatorBOR.Juni);
                    BTO = round(indikatorBTO.Juni);
                    TOI = round(indikatorTOI.Juni);
                    if (indikatorALOS.Juni == 0 || indikatorBOR.Juni == 0 || indikatorBTO.Juni == 0)
                        break;
                    changeTextInTextBox(BOR, TOI, ALOS, BTO); initChart();
                    foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
                    {
                        if (rekap.Data == "Jumlah Periode")
                            jumlahPeriode = rekap.Juni;
                    }
                    createChart("Juni", ALOS, BOR, BTO, jumlahPeriode);
                    break;
                case 6:
                    ALOS = round(indikatorALOS.Juli);
                    BOR = round(indikatorBOR.Juli);
                    BTO = round(indikatorBTO.Juli);
                    TOI = round(indikatorTOI.Juli);
                    if (indikatorALOS.Juli == 0 || indikatorBOR.Juli == 0 || indikatorBTO.Juli == 0)
                        break;
                    changeTextInTextBox(BOR, TOI, ALOS, BTO); initChart();
                    createChart("Juli", ALOS, BOR, BTO, jumlahPeriode);
                    break;
                case 7:
                    ALOS = round(indikatorALOS.Agustus);
                    BOR = round(indikatorBOR.Agustus);
                    BTO = round(indikatorBTO.Agustus);
                    TOI = round(indikatorTOI.Agustus);
                    if (indikatorALOS.Agustus == 0 || indikatorBOR.Agustus == 0 || indikatorBTO.Agustus == 0)
                        break;
                    changeTextInTextBox(BOR, TOI, ALOS, BTO); initChart();
                    foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
                    {
                        if (rekap.Data == "Jumlah Periode")
                            jumlahPeriode = rekap.Agustus;
                    }
                    createChart("Agustus", ALOS, BOR, BTO, jumlahPeriode);
                    break;
                case 8:
                    ALOS = round(indikatorALOS.September);
                    BOR = round(indikatorBOR.September);
                    BTO = round(indikatorBTO.September);
                    TOI = round(indikatorTOI.September);
                    if (indikatorALOS.September == 0 || indikatorBOR.September == 0 || indikatorBTO.September == 0)
                        break;
                    changeTextInTextBox(BOR, TOI, ALOS, BTO); initChart();
                    foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
                    {
                        if (rekap.Data == "Jumlah Periode")
                            jumlahPeriode = rekap.September;
                    }
                    createChart("September", ALOS, BOR, BTO, jumlahPeriode);
                    break;
                case 9:
                    ALOS = round(indikatorALOS.Oktober);
                    BOR = round(indikatorBOR.Oktober);
                    BTO = round(indikatorBTO.Oktober);
                    TOI = round(indikatorTOI.Oktober);
                    if (indikatorALOS.Oktober == 0 || indikatorBOR.Oktober == 0 || indikatorBTO.Oktober == 0)
                        break;
                    changeTextInTextBox(BOR, TOI, ALOS, BTO); initChart();
                    foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
                    {
                        if (rekap.Data == "Jumlah Periode")
                            jumlahPeriode = rekap.Oktober;
                    }
                    createChart("Oktober", ALOS, BOR, BTO, jumlahPeriode);
                    break;
                case 10:
                    ALOS = round(indikatorALOS.November);
                    BOR = round(indikatorBOR.November);
                    BTO = round(indikatorBTO.November);
                    TOI = round(indikatorTOI.November);
                    if (indikatorALOS.November == 0 || indikatorBOR.November == 0 || indikatorBTO.November == 0)
                        break;
                    changeTextInTextBox(BOR, TOI, ALOS, BTO); initChart();
                    foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
                    {
                        if (rekap.Data == "Jumlah Periode")
                            jumlahPeriode = rekap.November;
                    }
                    createChart("November", ALOS, BOR, BTO, jumlahPeriode);
                    break;
                case 11:
                    ALOS = round(indikatorALOS.Desember);
                    BOR = round(indikatorBOR.Desember);
                    BTO = round(indikatorBTO.Desember);
                    TOI = round(indikatorTOI.Desember);
                    if (indikatorALOS.Desember == 0 || indikatorBOR.Desember == 0 || indikatorBTO.Desember == 0)
                        break;
                    changeTextInTextBox(BOR, TOI, ALOS, BTO); initChart();
                    foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
                    {
                        if (rekap.Data == "Jumlah Periode")
                            jumlahPeriode = rekap.Desember;
                    }
                    createChart("Desember", ALOS, BOR, BTO, jumlahPeriode);
                    break;
                case 12:
                    foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
                    {
                        if (rekap.Data == "Hari Perawatan")
                            hariPerawatan = rekap.Januari + rekap.Februari + rekap.Maret;
                        if (rekap.Data == "Pasien Keluar (H&M)")
                            pasienKeluar = rekap.Januari + rekap.Februari + rekap.Maret;
                        if (rekap.Data == "Jumlah Periode")
                            jumlahPeriode = rekap.Januari + rekap.Februari + rekap.Maret;
                        if (rekap.Data == "Jumlah Tempat Tidur")
                            tempatTidur = rekap.Maret;
                    }
                    ALOS = Formula.calculateALOS(hariPerawatan, pasienKeluar);
                    BOR = Formula.calculateBOR(hariPerawatan, tempatTidur, jumlahPeriode);
                    TOI = Formula.calculateTOI(tempatTidur, jumlahPeriode, hariPerawatan, pasienKeluar);
                    BTO = Formula.calculateBTO(pasienKeluar, tempatTidur);
                    if (ALOS == 0 || BOR == 0 || BTO == 0)
                        break;
                    changeTextInTextBox(BOR, TOI, ALOS, BTO);
                    initChart();
                    createChart("Triwulan 1 (JANUARI-FEBRUARI-MARET)", ALOS, BOR, BTO, jumlahPeriode);
                    break;
                case 13:
                    foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
                    {
                        if (rekap.Data == "Hari Perawatan")
                            hariPerawatan = rekap.April + rekap.Mei + rekap.Juni;
                        if (rekap.Data == "Pasien Keluar (H&M)")
                            pasienKeluar = rekap.April + rekap.Mei + rekap.Juni;
                        if (rekap.Data == "Jumlah Periode")
                            jumlahPeriode = rekap.April + rekap.Mei + rekap.Juni;
                        if (rekap.Data == "Jumlah Tempat Tidur")
                            tempatTidur = rekap.Juni;
                    }
                    ALOS = Formula.calculateALOS(hariPerawatan, pasienKeluar);
                    BOR = Formula.calculateBOR(hariPerawatan, tempatTidur, jumlahPeriode);
                    TOI = Formula.calculateTOI(tempatTidur, jumlahPeriode, hariPerawatan, pasienKeluar);
                    BTO = Formula.calculateBTO(pasienKeluar, tempatTidur);
                    if (ALOS == 0 || BOR == 0 || BTO == 0)
                        break;
                    changeTextInTextBox(BOR, TOI, ALOS, BTO);
                    initChart();
                    createChart("Triwulan 2 (APRIL-MEI-JUNI)", ALOS, BOR, BTO, jumlahPeriode);
                    break;
                case 14:
                    foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
                    {
                        if (rekap.Data == "Hari Perawatan")
                            hariPerawatan = rekap.Juli + rekap.Agustus + rekap.September;
                        if (rekap.Data == "Pasien Keluar (H&M)")
                            pasienKeluar = rekap.Juli + rekap.Agustus + rekap.September;
                        if (rekap.Data == "Jumlah Periode")
                            jumlahPeriode = rekap.Juli + rekap.Agustus + rekap.September;
                        if (rekap.Data == "Jumlah Tempat Tidur")
                            tempatTidur = rekap.September;
                    }
                    ALOS = Formula.calculateALOS(hariPerawatan, pasienKeluar);
                    BOR = Formula.calculateBOR(hariPerawatan, tempatTidur, jumlahPeriode);
                    TOI = Formula.calculateTOI(tempatTidur, jumlahPeriode, hariPerawatan, pasienKeluar);
                    BTO = Formula.calculateBTO(pasienKeluar, tempatTidur);
                    if (ALOS == 0 || BOR == 0 || BTO == 0)
                        break;
                    changeTextInTextBox(BOR, TOI, ALOS, BTO);
                    initChart();
                    createChart("Triwulan 3 (JULI-AGUSTUS-SEPTEMBER)", ALOS, BOR, BTO, jumlahPeriode);
                    break;
                case 15:
                    foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
                    {
                        if (rekap.Data == "Hari Perawatan")
                            hariPerawatan = rekap.Oktober + rekap.November + rekap.Desember;
                        if (rekap.Data == "Pasien Keluar (H&M)")
                            pasienKeluar = rekap.Oktober + rekap.November + rekap.Desember;
                        if (rekap.Data == "Jumlah Periode")
                            jumlahPeriode = rekap.Oktober + rekap.November + rekap.Desember;
                        if (rekap.Data == "Jumlah Tempat Tidur")
                            tempatTidur = rekap.Desember;
                    }
                    ALOS = Formula.calculateALOS(hariPerawatan, pasienKeluar);
                    BOR = Formula.calculateBOR(hariPerawatan, tempatTidur, jumlahPeriode);
                    TOI = Formula.calculateTOI(tempatTidur, jumlahPeriode, hariPerawatan, pasienKeluar);
                    BTO = Formula.calculateBTO(pasienKeluar, tempatTidur);
                    if (ALOS == 0 || BOR == 0 || BTO == 0)
                        break;
                    changeTextInTextBox(BOR, TOI, ALOS, BTO);
                    initChart();
                    createChart("Triwulan 4 (OKTOBER-NOVEMBER-DESEMBER)", ALOS, BOR, BTO, jumlahPeriode);
                    break;
                case 16:
                    foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
                    {
                        if (rekap.Data == "Hari Perawatan")
                            hariPerawatan = rekap.Januari + rekap.Februari + rekap.Maret + rekap.April + rekap.Mei + rekap.Juni;
                        if (rekap.Data == "Pasien Keluar (H&M)")
                            pasienKeluar = rekap.Januari + rekap.Februari + rekap.Maret + rekap.April + rekap.Mei + rekap.Juni;
                        if (rekap.Data == "Jumlah Periode")
                            jumlahPeriode = rekap.Januari + rekap.Februari + rekap.Maret + rekap.April + rekap.Mei + rekap.Juni;
                        if (rekap.Data == "Jumlah Tempat Tidur")
                            tempatTidur = rekap.Juni;
                    }
                    Console.WriteLine(hariPerawatan);
                    Console.WriteLine(pasienKeluar);
                    Console.WriteLine(jumlahPeriode);
                    Console.WriteLine(tempatTidur);
                    ALOS = Formula.calculateALOS(hariPerawatan, pasienKeluar);
                    BOR = Formula.calculateBOR(hariPerawatan, tempatTidur, jumlahPeriode);
                    TOI = Formula.calculateTOI(tempatTidur, jumlahPeriode, hariPerawatan, pasienKeluar);
                    BTO = Formula.calculateBTO(pasienKeluar, tempatTidur);
                    if (ALOS == 0 || BOR == 0 || BTO == 0)
                        break;
                    changeTextInTextBox(BOR, TOI, ALOS, BTO);
                    initChart();
                    createChart("Semester 1", ALOS, BOR, BTO, jumlahPeriode);
                    break;
                case 17:
                    foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
                    {
                        if (rekap.Data == "Hari Perawatan")
                            hariPerawatan = rekap.Juli + rekap.Agustus + rekap.September + rekap.Oktober + rekap.November + rekap.Desember;
                        if (rekap.Data == "Pasien Keluar (H&M)")
                            pasienKeluar = rekap.Juli + rekap.Agustus + rekap.September + rekap.Oktober + rekap.November + rekap.Desember;
                        if (rekap.Data == "Jumlah Periode")
                            jumlahPeriode = rekap.Juli + rekap.Agustus + rekap.September + rekap.Oktober + rekap.November + rekap.Desember;
                        if (rekap.Data == "Jumlah Tempat Tidur")
                            tempatTidur = rekap.Desember;
                    }
                    ALOS = Formula.calculateALOS(hariPerawatan, pasienKeluar);
                    BOR = Formula.calculateBOR(hariPerawatan, tempatTidur, jumlahPeriode);
                    TOI = Formula.calculateTOI(tempatTidur, jumlahPeriode, hariPerawatan, pasienKeluar);
                    BTO = Formula.calculateBTO(pasienKeluar, tempatTidur);
                    if (ALOS == 0 || BOR == 0 || BTO == 0)
                        break;
                    changeTextInTextBox(BOR, TOI, ALOS, BTO);
                    initChart();
                    createChart("Semester 2", ALOS, BOR, BTO, jumlahPeriode);
                    break;
                case 18:
                    foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
                    {
                        if (rekap.Data == "Hari Perawatan")
                            hariPerawatan = rekap.Januari + rekap.Februari + rekap.Maret + rekap.April + rekap.Mei + rekap.Juni + rekap.Juli + rekap.Agustus + rekap.September + rekap.Oktober + rekap.November + rekap.Desember;
                        if (rekap.Data == "Pasien Keluar (H&M)")
                            pasienKeluar = rekap.Januari + rekap.Februari + rekap.Maret + rekap.April + rekap.Mei + rekap.Juni + rekap.Juli + rekap.Agustus + rekap.September + rekap.Oktober + rekap.November + rekap.Desember;
                        if (rekap.Data == "Jumlah Periode")
                            jumlahPeriode = rekap.Januari + rekap.Februari + rekap.Maret + rekap.April + rekap.Mei + rekap.Juni + rekap.Juli + rekap.Agustus + rekap.September + rekap.Oktober + rekap.November + rekap.Desember;
                        if (rekap.Data == "Jumlah Tempat Tidur")
                            tempatTidur = rekap.Desember;
                    }
                    ALOS = Formula.calculateALOS(hariPerawatan, pasienKeluar);
                    BOR = Formula.calculateBOR(hariPerawatan, tempatTidur, jumlahPeriode);
                    TOI = Formula.calculateTOI(tempatTidur, jumlahPeriode, hariPerawatan, pasienKeluar);
                    BTO = Formula.calculateBTO(pasienKeluar, tempatTidur);
                    if (ALOS == 0 || BOR == 0 || BTO == 0)
                        break;
                    changeTextInTextBox(BOR, TOI, ALOS, BTO);
                    initChart();
                    createChart("1 Tahun", ALOS, BOR, BTO, jumlahPeriode);
                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = cbTahun.SelectedIndex;
            tahunSelected = Int32.Parse(cbTahun.Items[index].ToString());
            AppForm.listIndikator = SqliteDataAccess.getAllIndikatorDataOfRuanganTahun(namaRuangan, tahunSelected);
            initChart();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Exporter.ExportChartToWord(chart1);
        }

        private void GJBUserControl_Load(object sender, EventArgs e)
        {
            lblNamaUser.Text = LoginForm.userModel.Nama;
            lblUsername.Text = LoginForm.userModel.Username;
            refreshRuangan();
        }

        private void GJBUserControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                refreshRuangan();
            }
        }

        //---------------------------------------------- Class ComboboxItem ----------------------------------------------------------

        protected class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }



        //---------------------------------------------- Function to Calculate Intersection ------------------------------------------

        // The points.
        List<PointF> Points = new List<PointF>();

        // The closest points.
        PointF Close1, Close2, Intersection;
        bool LinesIntersect = false;

        

        void calculateIntersection(float x1, float x2, float x3, float x4, float y1, float y2, float y3, float y4)
        {
            if (Points.Count == 4)
            {
                Points = new List<PointF>();
                LinesIntersect = false;
            }

            Points.Add(new PointF(x1, y1));
            Points.Add(new PointF(x2, y2));
            Points.Add(new PointF(x3, y3));
            Points.Add(new PointF(x4, y4));

            if (Points.Count == 4)
            {
                bool segments_intersect;
                FindIntersection(Points[0], Points[1], Points[2], Points[3],
                    out LinesIntersect, out segments_intersect,
                    out Intersection, out Close1, out Close2);
            }
            Console.WriteLine(Intersection);
        }

       
        // Find the point of intersection between
        // the lines p1 --> p2 and p3 --> p4.
        private void FindIntersection(PointF p1, PointF p2, PointF p3, PointF p4,
            out bool lines_intersect, out bool segments_intersect,
            out PointF intersection, out PointF close_p1, out PointF close_p2)
        {
            // Get the segments' parameters.
            float dx12 = p2.X - p1.X;
            float dy12 = p2.Y - p1.Y;
            float dx34 = p4.X - p3.X;
            float dy34 = p4.Y - p3.Y;

            // Solve for t1 and t2
            float denominator = (dy12 * dx34 - dx12 * dy34);
            float t1 = ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34) / denominator;
            if (float.IsInfinity(t1))
            {
                // The lines are parallel (or close enough to it).
                lines_intersect = false;
                segments_intersect = false;
                intersection = new PointF(float.NaN, float.NaN);
                close_p1 = new PointF(float.NaN, float.NaN);
                close_p2 = new PointF(float.NaN, float.NaN);
                return;
            }
            lines_intersect = true;

            float t2 = ((p3.X - p1.X) * dy12 + (p1.Y - p3.Y) * dx12) / -denominator;

            // Find the point of intersection.
            intersection = new PointF(p1.X + dx12 * t1, p1.Y + dy12 * t1);

            // The segments intersect if t1 and t2 are between 0 and 1.
            segments_intersect = ((t1 >= 0) && (t1 <= 1) && (t2 >= 0) && (t2 <= 1));

            // Find the closest points on the segments.
            if (t1 < 0)
            {
                t1 = 0;
            }
            else if (t1 > 1)
            {
                t1 = 1;
            }

            if (t2 < 0)
            {
                t2 = 0;
            }
            else if (t2 > 1)
            {
                t2 = 1;
            }

            close_p1 = new PointF(p1.X + dx12 * t1, p1.Y + dy12 * t1);
            close_p2 = new PointF(p3.X + dx34 * t2, p3.Y + dy34 * t2);
        }
    }
}
