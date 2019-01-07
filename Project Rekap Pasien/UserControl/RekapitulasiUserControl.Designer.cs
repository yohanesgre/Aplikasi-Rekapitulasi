namespace Project_Rekap_Pasien
{
    partial class RekapitulasiUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RekapitulasiUserControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.listViewTahun = new System.Windows.Forms.ListView();
            this.tahun = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Numbering = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indikator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.januari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.februari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maret = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.april = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.juni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.juli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agustus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.september = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oktober = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.november = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.saveFD = new System.Windows.Forms.SaveFileDialog();
            this.folderFD = new System.Windows.Forms.FolderBrowserDialog();
            this.btnTambahRuangan = new System.Windows.Forms.Button();
            this.btnHapusRuangan = new System.Windows.Forms.Button();
            this.btnHapusTahun = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnAddNewData = new System.Windows.Forms.Button();
            this.btnParseData = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblNamaUser = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnTambahRuangan);
            this.panel1.Controls.Add(this.btnHapusRuangan);
            this.panel1.Controls.Add(this.btnHapusTahun);
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Controls.Add(this.btnAddNewData);
            this.panel1.Controls.Add(this.lblUpdate);
            this.panel1.Controls.Add(this.btnParseData);
            this.panel1.Controls.Add(this.btnReload);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 55);
            this.panel1.TabIndex = 0;
            // 
            // lblUpdate
            // 
            this.lblUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdate.Location = new System.Drawing.Point(457, 18);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUpdate.Size = new System.Drawing.Size(276, 23);
            this.lblUpdate.TabIndex = 5;
            this.lblUpdate.Text = "Diperbarui: ";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUpdate.Visible = false;
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.Controls.Add(this.listView1);
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(217, 309);
            this.panel5.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(217, 309);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 210;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.AutoScroll = true;
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.listViewTahun);
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Location = new System.Drawing.Point(226, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(805, 309);
            this.panel4.TabIndex = 5;
            // 
            // listViewTahun
            // 
            this.listViewTahun.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tahun});
            this.listViewTahun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTahun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewTahun.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewTahun.Location = new System.Drawing.Point(0, 0);
            this.listViewTahun.Margin = new System.Windows.Forms.Padding(0);
            this.listViewTahun.Name = "listViewTahun";
            this.listViewTahun.Size = new System.Drawing.Size(805, 309);
            this.listViewTahun.TabIndex = 1;
            this.listViewTahun.UseCompatibleStateImageBehavior = false;
            this.listViewTahun.View = System.Windows.Forms.View.Details;
            this.listViewTahun.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewTahun_ItemSelectionChanged);
            this.listViewTahun.VisibleChanged += new System.EventHandler(this.listViewTahun_VisibleChanged);
            // 
            // tahun
            // 
            this.tahun.Width = 150;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numbering,
            this.indikator,
            this.januari,
            this.februari,
            this.maret,
            this.april,
            this.mei,
            this.juni,
            this.juli,
            this.agustus,
            this.september,
            this.oktober,
            this.november,
            this.desember,
            this.total});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(1);
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(805, 309);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValidated);
            // 
            // Numbering
            // 
            this.Numbering.DataPropertyName = "no";
            this.Numbering.HeaderText = "No";
            this.Numbering.Name = "Numbering";
            this.Numbering.ReadOnly = true;
            this.Numbering.Width = 58;
            // 
            // indikator
            // 
            this.indikator.DataPropertyName = "data";
            this.indikator.HeaderText = "Data";
            this.indikator.Name = "indikator";
            this.indikator.Width = 73;
            // 
            // januari
            // 
            this.januari.DataPropertyName = "januari";
            this.januari.HeaderText = "Januari";
            this.januari.Name = "januari";
            this.januari.Width = 90;
            // 
            // februari
            // 
            this.februari.DataPropertyName = "februari";
            this.februari.HeaderText = "Februari";
            this.februari.Name = "februari";
            this.februari.Width = 97;
            // 
            // maret
            // 
            this.maret.DataPropertyName = "maret";
            this.maret.HeaderText = "Maret";
            this.maret.Name = "maret";
            this.maret.Width = 79;
            // 
            // april
            // 
            this.april.DataPropertyName = "april";
            this.april.HeaderText = "April";
            this.april.Name = "april";
            this.april.Width = 69;
            // 
            // mei
            // 
            this.mei.DataPropertyName = "mei";
            this.mei.HeaderText = "Mei";
            this.mei.Name = "mei";
            this.mei.Width = 63;
            // 
            // juni
            // 
            this.juni.DataPropertyName = "juni";
            this.juni.HeaderText = "Juni";
            this.juni.Name = "juni";
            this.juni.Width = 67;
            // 
            // juli
            // 
            this.juli.DataPropertyName = "juli";
            this.juli.HeaderText = "Juli";
            this.juli.Name = "juli";
            this.juli.Width = 61;
            // 
            // agustus
            // 
            this.agustus.DataPropertyName = "agustus";
            this.agustus.HeaderText = "Agustus";
            this.agustus.Name = "agustus";
            this.agustus.Width = 97;
            // 
            // september
            // 
            this.september.DataPropertyName = "september";
            this.september.HeaderText = "September";
            this.september.Name = "september";
            this.september.Width = 117;
            // 
            // oktober
            // 
            this.oktober.DataPropertyName = "oktober";
            this.oktober.HeaderText = "Oktober";
            this.oktober.Name = "oktober";
            this.oktober.Width = 95;
            // 
            // november
            // 
            this.november.DataPropertyName = "november";
            this.november.HeaderText = "November";
            this.november.Name = "november";
            this.november.Width = 110;
            // 
            // desember
            // 
            this.desember.DataPropertyName = "desember";
            this.desember.HeaderText = "Desember";
            this.desember.Name = "desember";
            this.desember.Width = 112;
            // 
            // total
            // 
            this.total.DataPropertyName = "total";
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 73;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Location = new System.Drawing.Point(3, 58);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1034, 319);
            this.panel3.TabIndex = 3;
            // 
            // btnTambahRuangan
            // 
            this.btnTambahRuangan.Image = global::Project_Rekap_Pasien.Properties.Resources.add_room_32;
            this.btnTambahRuangan.Location = new System.Drawing.Point(17, 10);
            this.btnTambahRuangan.Margin = new System.Windows.Forms.Padding(5);
            this.btnTambahRuangan.Name = "btnTambahRuangan";
            this.btnTambahRuangan.Size = new System.Drawing.Size(50, 40);
            this.btnTambahRuangan.TabIndex = 6;
            this.btnTambahRuangan.UseVisualStyleBackColor = true;
            this.btnTambahRuangan.Visible = false;
            this.btnTambahRuangan.Click += new System.EventHandler(this.btnTambahRuangan_Click);
            // 
            // btnHapusRuangan
            // 
            this.btnHapusRuangan.Image = global::Project_Rekap_Pasien.Properties.Resources.delete_room_32;
            this.btnHapusRuangan.Location = new System.Drawing.Point(77, 10);
            this.btnHapusRuangan.Margin = new System.Windows.Forms.Padding(5);
            this.btnHapusRuangan.Name = "btnHapusRuangan";
            this.btnHapusRuangan.Size = new System.Drawing.Size(50, 40);
            this.btnHapusRuangan.TabIndex = 8;
            this.btnHapusRuangan.UseVisualStyleBackColor = true;
            this.btnHapusRuangan.Visible = false;
            this.btnHapusRuangan.Click += new System.EventHandler(this.btnHapusRuangan_Click);
            // 
            // btnHapusTahun
            // 
            this.btnHapusTahun.Image = global::Project_Rekap_Pasien.Properties.Resources.delete_date_32;
            this.btnHapusTahun.Location = new System.Drawing.Point(197, 10);
            this.btnHapusTahun.Margin = new System.Windows.Forms.Padding(5);
            this.btnHapusTahun.Name = "btnHapusTahun";
            this.btnHapusTahun.Size = new System.Drawing.Size(50, 40);
            this.btnHapusTahun.TabIndex = 9;
            this.btnHapusTahun.UseVisualStyleBackColor = true;
            this.btnHapusTahun.Visible = false;
            this.btnHapusTahun.Click += new System.EventHandler(this.btnHapusTahun_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Image = global::Project_Rekap_Pasien.Properties.Resources.excel_32;
            this.btnExportExcel.Location = new System.Drawing.Point(257, 10);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(5);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(50, 40);
            this.btnExportExcel.TabIndex = 12;
            this.btnExportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Visible = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnAddNewData
            // 
            this.btnAddNewData.Image = global::Project_Rekap_Pasien.Properties.Resources.add_date_321;
            this.btnAddNewData.Location = new System.Drawing.Point(137, 10);
            this.btnAddNewData.Margin = new System.Windows.Forms.Padding(5);
            this.btnAddNewData.Name = "btnAddNewData";
            this.btnAddNewData.Size = new System.Drawing.Size(50, 40);
            this.btnAddNewData.TabIndex = 4;
            this.btnAddNewData.UseVisualStyleBackColor = true;
            this.btnAddNewData.Visible = false;
            this.btnAddNewData.Click += new System.EventHandler(this.btnAddNewData_Click);
            // 
            // btnParseData
            // 
            this.btnParseData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnParseData.Image = global::Project_Rekap_Pasien.Properties.Resources.update_32;
            this.btnParseData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParseData.Location = new System.Drawing.Point(377, 10);
            this.btnParseData.Margin = new System.Windows.Forms.Padding(5);
            this.btnParseData.Name = "btnParseData";
            this.btnParseData.Size = new System.Drawing.Size(72, 40);
            this.btnParseData.TabIndex = 3;
            this.btnParseData.Text = "Data";
            this.btnParseData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnParseData.UseVisualStyleBackColor = true;
            this.btnParseData.Visible = false;
            this.btnParseData.Click += new System.EventHandler(this.btnParseData_Click);
            // 
            // btnReload
            // 
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.Location = new System.Drawing.Point(317, 10);
            this.btnReload.Margin = new System.Windows.Forms.Padding(5);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(50, 40);
            this.btnReload.TabIndex = 0;
            this.btnReload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Project_Rekap_Pasien.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(5, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblNamaUser);
            this.panel2.Controls.Add(this.lblUsername);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(800, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(237, 40);
            this.panel2.TabIndex = 14;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(45, 3);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(96, 16);
            this.lblUsername.TabIndex = 14;
            this.lblUsername.Text = "lblUsername";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNamaUser
            // 
            this.lblNamaUser.AutoSize = true;
            this.lblNamaUser.Location = new System.Drawing.Point(48, 22);
            this.lblNamaUser.Name = "lblNamaUser";
            this.lblNamaUser.Size = new System.Drawing.Size(35, 13);
            this.lblNamaUser.TabIndex = 15;
            this.lblNamaUser.Text = "label2";
            this.lblNamaUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RekapitulasiUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "RekapitulasiUserControl";
            this.Size = new System.Drawing.Size(1040, 381);
            this.Load += new System.EventHandler(this.RekapitulasiUserControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnParseData;
        private System.Windows.Forms.Button btnAddNewData;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Button btnTambahRuangan;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numbering;
        private System.Windows.Forms.DataGridViewTextBoxColumn indikator;
        private System.Windows.Forms.DataGridViewTextBoxColumn januari;
        private System.Windows.Forms.DataGridViewTextBoxColumn februari;
        private System.Windows.Forms.DataGridViewTextBoxColumn maret;
        private System.Windows.Forms.DataGridViewTextBoxColumn april;
        private System.Windows.Forms.DataGridViewTextBoxColumn mei;
        private System.Windows.Forms.DataGridViewTextBoxColumn juni;
        private System.Windows.Forms.DataGridViewTextBoxColumn juli;
        private System.Windows.Forms.DataGridViewTextBoxColumn agustus;
        private System.Windows.Forms.DataGridViewTextBoxColumn september;
        private System.Windows.Forms.DataGridViewTextBoxColumn oktober;
        private System.Windows.Forms.DataGridViewTextBoxColumn november;
        private System.Windows.Forms.DataGridViewTextBoxColumn desember;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.ListView listViewTahun;
        private System.Windows.Forms.ColumnHeader tahun;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnHapusTahun;
        private System.Windows.Forms.Button btnHapusRuangan;
        private System.Windows.Forms.SaveFileDialog saveFD;
        private System.Windows.Forms.FolderBrowserDialog folderFD;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNamaUser;
        private System.Windows.Forms.Label lblUsername;
    }
}
