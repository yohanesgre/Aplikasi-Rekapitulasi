using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
namespace Project_Rekap_Pasien
{
    partial class AppForm/* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.btnBantuan = new System.Windows.Forms.Button();
            this.btnGBJ = new System.Windows.Forms.Button();
            this.btnIndikator = new System.Windows.Forms.Button();
            this.btnRekapitulasi = new System.Windows.Forms.Button();
            this.PanelUC = new System.Windows.Forms.Panel();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btnSetting = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 114);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.SidePanel);
            this.splitContainer1.Panel1.Controls.Add(this.btnBantuan);
            this.splitContainer1.Panel1.Controls.Add(this.btnGBJ);
            this.splitContainer1.Panel1.Controls.Add(this.btnIndikator);
            this.splitContainer1.Panel1.Controls.Add(this.btnRekapitulasi);
            this.splitContainer1.Panel1.Controls.Add(this.btnSetting);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PanelUC);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 570);
            this.splitContainer1.SplitterDistance = 237;
            this.splitContainer1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 549);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 3, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Copyright ©2018 by Sepay Team";
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.SidePanel.ForeColor = System.Drawing.Color.Teal;
            this.SidePanel.Location = new System.Drawing.Point(0, 3);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(25, 36);
            this.SidePanel.TabIndex = 13;
            // 
            // btnBantuan
            // 
            this.btnBantuan.BackColor = System.Drawing.Color.LightGray;
            this.btnBantuan.FlatAppearance.BorderSize = 0;
            this.btnBantuan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBantuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBantuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBantuan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBantuan.Location = new System.Drawing.Point(0, 179);
            this.btnBantuan.Margin = new System.Windows.Forms.Padding(3, 5, 0, 3);
            this.btnBantuan.Name = "btnBantuan";
            this.btnBantuan.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnBantuan.Size = new System.Drawing.Size(233, 36);
            this.btnBantuan.TabIndex = 17;
            this.btnBantuan.Text = "Bantuan";
            this.btnBantuan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBantuan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBantuan.UseVisualStyleBackColor = false;
            this.btnBantuan.Click += new System.EventHandler(this.btnBantuan_Click);
            // 
            // btnGBJ
            // 
            this.btnGBJ.BackColor = System.Drawing.Color.LightGray;
            this.btnGBJ.FlatAppearance.BorderSize = 0;
            this.btnGBJ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGBJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGBJ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGBJ.Image = global::Project_Rekap_Pasien.Properties.Resources.gjb;
            this.btnGBJ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGBJ.Location = new System.Drawing.Point(0, 91);
            this.btnGBJ.Margin = new System.Windows.Forms.Padding(3, 5, 0, 3);
            this.btnGBJ.Name = "btnGBJ";
            this.btnGBJ.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnGBJ.Size = new System.Drawing.Size(233, 36);
            this.btnGBJ.TabIndex = 16;
            this.btnGBJ.Text = "Grafik Barber Johnson";
            this.btnGBJ.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGBJ.UseVisualStyleBackColor = false;
            this.btnGBJ.Click += new System.EventHandler(this.btnGBJ_Click);
            // 
            // btnIndikator
            // 
            this.btnIndikator.BackColor = System.Drawing.Color.LightGray;
            this.btnIndikator.FlatAppearance.BorderSize = 0;
            this.btnIndikator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIndikator.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIndikator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnIndikator.Image = global::Project_Rekap_Pasien.Properties.Resources.indikator;
            this.btnIndikator.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIndikator.Location = new System.Drawing.Point(0, 47);
            this.btnIndikator.Margin = new System.Windows.Forms.Padding(3, 5, 0, 3);
            this.btnIndikator.Name = "btnIndikator";
            this.btnIndikator.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnIndikator.Size = new System.Drawing.Size(233, 36);
            this.btnIndikator.TabIndex = 15;
            this.btnIndikator.Text = "Indikator";
            this.btnIndikator.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIndikator.UseVisualStyleBackColor = false;
            this.btnIndikator.Click += new System.EventHandler(this.btnIndikator_Click);
            // 
            // btnRekapitulasi
            // 
            this.btnRekapitulasi.BackColor = System.Drawing.Color.LightGray;
            this.btnRekapitulasi.FlatAppearance.BorderSize = 0;
            this.btnRekapitulasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRekapitulasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRekapitulasi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRekapitulasi.Image = global::Project_Rekap_Pasien.Properties.Resources.rekap;
            this.btnRekapitulasi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRekapitulasi.Location = new System.Drawing.Point(0, 3);
            this.btnRekapitulasi.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btnRekapitulasi.Name = "btnRekapitulasi";
            this.btnRekapitulasi.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnRekapitulasi.Size = new System.Drawing.Size(233, 36);
            this.btnRekapitulasi.TabIndex = 14;
            this.btnRekapitulasi.Text = "Rekapitulasi";
            this.btnRekapitulasi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRekapitulasi.UseVisualStyleBackColor = false;
            this.btnRekapitulasi.Click += new System.EventHandler(this.btnRekapitulasi_Click);
            // 
            // PanelUC
            // 
            this.PanelUC.AutoSize = true;
            this.PanelUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelUC.Location = new System.Drawing.Point(0, 0);
            this.PanelUC.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.PanelUC.Name = "PanelUC";
            this.PanelUC.Size = new System.Drawing.Size(1023, 570);
            this.PanelUC.TabIndex = 5;
            // 
            // Panel5
            // 
            this.Panel5.AllowDrop = true;
            this.Panel5.AutoSize = true;
            this.Panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel5.Controls.Add(this.label1);
            this.Panel5.Controls.Add(this.pictureBox1);
            this.Panel5.Controls.Add(this.Label3);
            this.Panel5.Controls.Add(this.Label2);
            this.Panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel5.Enabled = false;
            this.Panel5.Location = new System.Drawing.Point(0, 0);
            this.Panel5.Name = "Panel5";
            this.Panel5.Size = new System.Drawing.Size(1264, 112);
            this.Panel5.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(590, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Instalasi Rekam Medis";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::Project_Rekap_Pasien.Properties.Resources.logo_login_100;
            this.pictureBox1.Location = new System.Drawing.Point(246, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 103);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(529, 40);
            this.Label3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(348, 25);
            this.Label3.TabIndex = 10;
            this.Label3.Text = "Jl. Raya Tlogomas No. 45, Malang ";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(369, 8);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(644, 29);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "RUMAH SAKIT UNIVERSITAS MUHAMMADIYAH MALANG";
            // 
            // Panel1
            // 
            this.Panel1.AutoSize = true;
            this.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Panel1.Controls.Add(this.Panel5);
            this.Panel1.Controls.Add(this.splitContainer1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1264, 681);
            this.Panel1.TabIndex = 0;
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.LightGray;
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSetting.Image = global::Project_Rekap_Pasien.Properties.Resources.setting2;
            this.btnSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetting.Location = new System.Drawing.Point(0, 135);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(3, 5, 0, 3);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnSetting.Size = new System.Drawing.Size(233, 36);
            this.btnSetting.TabIndex = 18;
            this.btnSetting.Text = "Setting";
            this.btnSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSetting.UseVisualStyleBackColor = false;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.Panel1);
            this.Name = "AppForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplikasi Rekapitulasi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AppForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.Panel5.ResumeLayout(false);
            this.Panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.Panel SidePanel;
        internal System.Windows.Forms.Button btnBantuan;
        internal System.Windows.Forms.Button btnGBJ;
        internal System.Windows.Forms.Button btnIndikator;
        internal System.Windows.Forms.Button btnRekapitulasi;
        private System.Windows.Forms.Panel PanelUC;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button btnSetting;
    }
}