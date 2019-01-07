namespace Project_Rekap_Pasien
{
    partial class SettingUC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingUC));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.Numbering = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jabatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Instalasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteButton = new System.Windows.Forms.DataGridViewImageColumn();
            this.updateButton = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.btnAddUser);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 56);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(3, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1034, 477);
            this.panel2.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numbering,
            this.Username,
            this.Password,
            this.Nama,
            this.Jabatan,
            this.Instalasi,
            this.Role,
            this.deleteButton,
            this.updateButton});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(1);
            this.dataGridView1.Size = new System.Drawing.Size(1034, 477);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle5.NullValue")));
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewImageColumn1.HeaderText = "Delete";
            this.dataGridViewImageColumn1.Image = global::Project_Rekap_Pasien.Properties.Resources.delete_user_32;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 72;
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddUser.Image = global::Project_Rekap_Pasien.Properties.Resources.add_user_32;
            this.btnAddUser.Location = new System.Drawing.Point(6, 6);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAddUser.Size = new System.Drawing.Size(44, 44);
            this.btnAddUser.TabIndex = 0;
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // Numbering
            // 
            this.Numbering.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Numbering.DataPropertyName = "no";
            this.Numbering.HeaderText = "No";
            this.Numbering.Name = "Numbering";
            this.Numbering.ReadOnly = true;
            this.Numbering.Width = 62;
            // 
            // Username
            // 
            this.Username.DataPropertyName = "user";
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            this.Username.Width = 124;
            // 
            // Password
            // 
            this.Password.DataPropertyName = "pass";
            this.Password.HeaderText = "Password";
            this.Password.Name = "Password";
            this.Password.Width = 119;
            // 
            // Nama
            // 
            this.Nama.DataPropertyName = "nama";
            this.Nama.HeaderText = "Nama";
            this.Nama.Name = "Nama";
            this.Nama.Width = 87;
            // 
            // Jabatan
            // 
            this.Jabatan.DataPropertyName = "jabatan";
            this.Jabatan.HeaderText = "Jabatan";
            this.Jabatan.Name = "Jabatan";
            this.Jabatan.Width = 102;
            // 
            // Instalasi
            // 
            this.Instalasi.DataPropertyName = "instalasi";
            this.Instalasi.HeaderText = "Instalasi";
            this.Instalasi.Name = "Instalasi";
            this.Instalasi.Width = 102;
            // 
            // Role
            // 
            this.Role.DataPropertyName = "role";
            this.Role.HeaderText = "Role";
            this.Role.Name = "Role";
            this.Role.Width = 76;
            // 
            // deleteButton
            // 
            this.deleteButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle2.NullValue")));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.deleteButton.DefaultCellStyle = dataGridViewCellStyle2;
            this.deleteButton.HeaderText = "Delete";
            this.deleteButton.Image = global::Project_Rekap_Pasien.Properties.Resources.delete_user_32;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.deleteButton.Width = 72;
            // 
            // updateButton
            // 
            this.updateButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle3.NullValue")));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.updateButton.DefaultCellStyle = dataGridViewCellStyle3;
            this.updateButton.HeaderText = "Update";
            this.updateButton.Image = global::Project_Rekap_Pasien.Properties.Resources.update_user_32;
            this.updateButton.Name = "updateButton";
            this.updateButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.updateButton.Width = 78;
            // 
            // SettingUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "SettingUC";
            this.Size = new System.Drawing.Size(1040, 537);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numbering;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jabatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Instalasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role;
        private System.Windows.Forms.DataGridViewImageColumn deleteButton;
        private System.Windows.Forms.DataGridViewImageColumn updateButton;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
    }
}
