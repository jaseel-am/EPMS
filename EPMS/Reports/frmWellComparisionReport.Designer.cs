namespace EPMS
{
    partial class frmWellComparisionReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWellComparisionReport));
            this.DgvReport = new System.Windows.Forms.DataGridView();
            this.WellName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbFromWell = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.txtOutPutPath = new System.Windows.Forms.TextBox();
            this.BtnExport = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bwrk1 = new System.ComponentModel.BackgroundWorker();
            this.btnBrowse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvReport
            // 
            this.DgvReport.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvReport.ColumnHeadersHeight = 30;
            this.DgvReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WellName,
            this.XVal,
            this.YVal,
            this.ZVal,
            this.Result});
            this.DgvReport.Location = new System.Drawing.Point(18, 48);
            this.DgvReport.Name = "DgvReport";
            this.DgvReport.RowHeadersVisible = false;
            this.DgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvReport.Size = new System.Drawing.Size(1087, 401);
            this.DgvReport.TabIndex = 54;
            // 
            // WellName
            // 
            this.WellName.DataPropertyName = "WellName";
            this.WellName.HeaderText = "Well Name";
            this.WellName.Name = "WellName";
            this.WellName.Width = 300;
            // 
            // XVal
            // 
            this.XVal.DataPropertyName = "XVal";
            this.XVal.HeaderText = "X Val";
            this.XVal.Name = "XVal";
            this.XVal.Width = 160;
            // 
            // YVal
            // 
            this.YVal.DataPropertyName = "YVal";
            this.YVal.HeaderText = "Y Val";
            this.YVal.Name = "YVal";
            this.YVal.Width = 160;
            // 
            // ZVal
            // 
            this.ZVal.DataPropertyName = "ZVal";
            this.ZVal.HeaderText = "Z Val";
            this.ZVal.Name = "ZVal";
            this.ZVal.Width = 160;
            // 
            // Result
            // 
            this.Result.DataPropertyName = "Result";
            this.Result.HeaderText = "Result";
            this.Result.Name = "Result";
            this.Result.Width = 250;
            // 
            // cmbFromWell
            // 
            this.cmbFromWell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromWell.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFromWell.FormattingEnabled = true;
            this.cmbFromWell.Location = new System.Drawing.Point(96, 14);
            this.cmbFromWell.Name = "cmbFromWell";
            this.cmbFromWell.Size = new System.Drawing.Size(272, 22);
            this.cmbFromWell.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(23, 463);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 14);
            this.label3.TabIndex = 51;
            this.label3.Text = "Output File Path:";
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRemember.ForeColor = System.Drawing.Color.White;
            this.chkRemember.Location = new System.Drawing.Point(165, 489);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(93, 18);
            this.chkRemember.TabIndex = 58;
            this.chkRemember.Text = "Remember";
            this.chkRemember.UseVisualStyleBackColor = true;
            // 
            // txtOutPutPath
            // 
            this.txtOutPutPath.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutPutPath.Location = new System.Drawing.Point(165, 461);
            this.txtOutPutPath.Name = "txtOutPutPath";
            this.txtOutPutPath.Size = new System.Drawing.Size(416, 22);
            this.txtOutPutPath.TabIndex = 57;
            // 
            // BtnExport
            // 
            this.BtnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExport.Font = new System.Drawing.Font("Verdana", 9F);
            this.BtnExport.ForeColor = System.Drawing.Color.White;
            this.BtnExport.Location = new System.Drawing.Point(976, 466);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(129, 27);
            this.BtnExport.TabIndex = 55;
            this.BtnExport.Text = "Export Excel";
            this.BtnExport.UseVisualStyleBackColor = false;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnProcess.ForeColor = System.Drawing.Color.White;
            this.btnProcess.Location = new System.Drawing.Point(374, 12);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(129, 27);
            this.btnProcess.TabIndex = 56;
            this.btnProcess.Text = "Generate Report";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 14);
            this.label1.TabIndex = 52;
            this.label1.Text = "From Well:";
            // 
            // bwrk1
            // 
            this.bwrk1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwrk1_DoWork);
            this.bwrk1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwrk1_RunWorkerCompleted);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBrowse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrowse.BackgroundImage")));
            this.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnBrowse.Location = new System.Drawing.Point(587, 458);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(37, 27);
            this.btnBrowse.TabIndex = 61;
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // frmWellComparisionReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1142, 512);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.DgvReport);
            this.Controls.Add(this.cmbFromWell);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkRemember);
            this.Controls.Add(this.txtOutPutPath);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.label1);
            this.Name = "frmWellComparisionReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Well Comparision Report";
            ((System.ComponentModel.ISupportInitialize)(this.DgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn WellName;
        private System.Windows.Forms.DataGridViewTextBoxColumn XVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn YVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.ComboBox cmbFromWell;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.TextBox txtOutPutPath;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker bwrk1;
        private System.Windows.Forms.Button btnBrowse;
    }
}