﻿
namespace ToolTestWishyWishy
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb_Localhost = new System.Windows.Forms.RadioButton();
            this.rdb_PublicWeb = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdb_Option_CreateWish = new System.Windows.Forms.RadioButton();
            this.rdb_Option_Thank = new System.Windows.Forms.RadioButton();
            this.btn_Start = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numud_TaskNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdb_Sequen = new System.Windows.Forms.RadioButton();
            this.rdb_Parallel = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.numud_WaitTime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_Noti = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numud_TaskNum)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numud_WaitTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Noti)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb_Localhost);
            this.groupBox1.Controls.Add(this.rdb_PublicWeb);
            this.groupBox1.Location = new System.Drawing.Point(24, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn server";
            // 
            // rdb_Localhost
            // 
            this.rdb_Localhost.AutoSize = true;
            this.rdb_Localhost.Location = new System.Drawing.Point(128, 19);
            this.rdb_Localhost.Name = "rdb_Localhost";
            this.rdb_Localhost.Size = new System.Drawing.Size(94, 21);
            this.rdb_Localhost.TabIndex = 1;
            this.rdb_Localhost.Text = "Local host";
            this.rdb_Localhost.UseVisualStyleBackColor = true;
            // 
            // rdb_PublicWeb
            // 
            this.rdb_PublicWeb.AutoSize = true;
            this.rdb_PublicWeb.Checked = true;
            this.rdb_PublicWeb.Location = new System.Drawing.Point(22, 19);
            this.rdb_PublicWeb.Name = "rdb_PublicWeb";
            this.rdb_PublicWeb.Size = new System.Drawing.Size(100, 21);
            this.rdb_PublicWeb.TabIndex = 0;
            this.rdb_PublicWeb.TabStop = true;
            this.rdb_PublicWeb.Text = "Public Web";
            this.rdb_PublicWeb.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdb_Option_CreateWish);
            this.groupBox2.Controls.Add(this.rdb_Option_Thank);
            this.groupBox2.Location = new System.Drawing.Point(24, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(384, 112);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chọn công việc";
            // 
            // rdb_Option_CreateWish
            // 
            this.rdb_Option_CreateWish.AutoSize = true;
            this.rdb_Option_CreateWish.Checked = true;
            this.rdb_Option_CreateWish.Location = new System.Drawing.Point(22, 19);
            this.rdb_Option_CreateWish.Name = "rdb_Option_CreateWish";
            this.rdb_Option_CreateWish.Size = new System.Drawing.Size(201, 21);
            this.rdb_Option_CreateWish.TabIndex = 6;
            this.rdb_Option_CreateWish.TabStop = true;
            this.rdb_Option_CreateWish.Text = "Test chức năng tạo ước mơ";
            this.rdb_Option_CreateWish.UseVisualStyleBackColor = true;
            // 
            // rdb_Option_Thank
            // 
            this.rdb_Option_Thank.AutoSize = true;
            this.rdb_Option_Thank.Location = new System.Drawing.Point(22, 61);
            this.rdb_Option_Thank.Name = "rdb_Option_Thank";
            this.rdb_Option_Thank.Size = new System.Drawing.Size(195, 21);
            this.rdb_Option_Thank.TabIndex = 4;
            this.rdb_Option_Thank.Text = "Test chức năng lời cảm ơn";
            this.rdb_Option_Thank.UseVisualStyleBackColor = true;
            // 
            // btn_Start
            // 
            this.btn_Start.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Start.Location = new System.Drawing.Point(679, 381);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(109, 57);
            this.btn_Start.TabIndex = 3;
            this.btn_Start.Text = "Bắt đầu";
            this.btn_Start.UseVisualStyleBackColor = false;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numud_TaskNum);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(438, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(225, 48);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chọn số luồng chạy";
            // 
            // numud_TaskNum
            // 
            this.numud_TaskNum.Location = new System.Drawing.Point(92, 16);
            this.numud_TaskNum.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numud_TaskNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numud_TaskNum.Name = "numud_TaskNum";
            this.numud_TaskNum.Size = new System.Drawing.Size(60, 22);
            this.numud_TaskNum.TabIndex = 4;
            this.numud_TaskNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số luồng";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdb_Sequen);
            this.groupBox4.Controls.Add(this.rdb_Parallel);
            this.groupBox4.Location = new System.Drawing.Point(438, 77);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(225, 53);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cách luồng chạy";
            // 
            // rdb_Sequen
            // 
            this.rdb_Sequen.AutoSize = true;
            this.rdb_Sequen.Location = new System.Drawing.Point(126, 19);
            this.rdb_Sequen.Name = "rdb_Sequen";
            this.rdb_Sequen.Size = new System.Drawing.Size(78, 21);
            this.rdb_Sequen.TabIndex = 3;
            this.rdb_Sequen.Text = "Tuần tự";
            this.rdb_Sequen.UseVisualStyleBackColor = true;
            // 
            // rdb_Parallel
            // 
            this.rdb_Parallel.AutoSize = true;
            this.rdb_Parallel.Checked = true;
            this.rdb_Parallel.Location = new System.Drawing.Point(20, 19);
            this.rdb_Parallel.Name = "rdb_Parallel";
            this.rdb_Parallel.Size = new System.Drawing.Size(97, 21);
            this.rdb_Parallel.TabIndex = 2;
            this.rdb_Parallel.TabStop = true;
            this.rdb_Parallel.Text = "Song song";
            this.rdb_Parallel.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.numud_WaitTime);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(438, 141);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(225, 48);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Chọn thời gian nghỉ";
            // 
            // numud_WaitTime
            // 
            this.numud_WaitTime.DecimalPlaces = 2;
            this.numud_WaitTime.Location = new System.Drawing.Point(92, 16);
            this.numud_WaitTime.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numud_WaitTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numud_WaitTime.Name = "numud_WaitTime";
            this.numud_WaitTime.Size = new System.Drawing.Size(60, 22);
            this.numud_WaitTime.TabIndex = 4;
            this.numud_WaitTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số giây";
            // 
            // dgv_Noti
            // 
            this.dgv_Noti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Noti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Noti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3});
            this.dgv_Noti.Location = new System.Drawing.Point(24, 221);
            this.dgv_Noti.MultiSelect = false;
            this.dgv_Noti.Name = "dgv_Noti";
            this.dgv_Noti.ReadOnly = true;
            this.dgv_Noti.RowHeadersVisible = false;
            this.dgv_Noti.RowHeadersWidth = 51;
            this.dgv_Noti.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_Noti.Size = new System.Drawing.Size(639, 217);
            this.dgv_Noti.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 50F;
            this.Column1.HeaderText = "STT";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Chức năng test";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Phân tích lỗi";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Trạng thái";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // btn_Stop
            // 
            this.btn_Stop.BackColor = System.Drawing.Color.LightCoral;
            this.btn_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Stop.Location = new System.Drawing.Point(679, 381);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(109, 57);
            this.btn_Stop.TabIndex = 7;
            this.btn_Stop.Text = "Dừng lại";
            this.btn_Stop.UseVisualStyleBackColor = false;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.dgv_Noti);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TOOL TEST WISHYWISHY";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numud_TaskNum)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numud_WaitTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Noti)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb_Localhost;
        private System.Windows.Forms.RadioButton rdb_PublicWeb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numud_TaskNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdb_Sequen;
        private System.Windows.Forms.RadioButton rdb_Parallel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown numud_WaitTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_Noti;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.RadioButton rdb_Option_CreateWish;
        private System.Windows.Forms.RadioButton rdb_Option_Thank;
    }
}

