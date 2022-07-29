namespace IOOP_Assignment
{
    partial class Generator
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ClubsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsClubs = new IOOP_Assignment.dsClubs();
            this.ActivityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.radActivities = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radClubs = new System.Windows.Forms.RadioButton();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.reportViewerClubs = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ActivityTableAdapter = new IOOP_Assignment.dsClubsTableAdapters.ActivityTableAdapter();
            this.ClubsTableAdapter = new IOOP_Assignment.dsClubsTableAdapters.ClubsTableAdapter();
            this.reportViewerActi = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ClubsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClubs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActivityBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClubsBindingSource
            // 
            this.ClubsBindingSource.DataMember = "Clubs";
            this.ClubsBindingSource.DataSource = this.dsClubs;
            // 
            // dsClubs
            // 
            this.dsClubs.DataSetName = "dsClubs";
            this.dsClubs.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ActivityBindingSource
            // 
            this.ActivityBindingSource.DataMember = "Activity";
            this.ActivityBindingSource.DataSource = this.dsClubs;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(95, 116);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(110, 22);
            this.dtpFrom.TabIndex = 2;
            this.dtpFrom.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // radActivities
            // 
            this.radActivities.AutoSize = true;
            this.radActivities.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radActivities.Location = new System.Drawing.Point(32, 48);
            this.radActivities.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radActivities.Name = "radActivities";
            this.radActivities.Size = new System.Drawing.Size(231, 24);
            this.radActivities.TabIndex = 4;
            this.radActivities.TabStop = true;
            this.radActivities.Text = "Club activities for the week";
            this.radActivities.UseVisualStyleBackColor = true;
            this.radActivities.CheckedChanged += new System.EventHandler(this.radActivities_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radActivities);
            this.groupBox1.Controls.Add(this.radClubs);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Location = new System.Drawing.Point(46, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(296, 77);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report";
            // 
            // radClubs
            // 
            this.radClubs.AutoSize = true;
            this.radClubs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radClubs.Location = new System.Drawing.Point(32, 24);
            this.radClubs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radClubs.Name = "radClubs";
            this.radClubs.Size = new System.Drawing.Size(150, 24);
            this.radClubs.TabIndex = 3;
            this.radClubs.TabStop = true;
            this.radClubs.Text = "List of the clubs";
            this.radClubs.UseVisualStyleBackColor = true;
            this.radClubs.CheckedChanged += new System.EventHandler(this.radClubs_CheckedChanged);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(467, 39);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(139, 45);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(445, 93);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(190, 45);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back to Menu";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(258, 116);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(110, 22);
            this.dtpTo.TabIndex = 2;
            // 
            // reportViewerClubs
            // 
            this.reportViewerClubs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewerClubs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            reportDataSource1.Name = "dsClubsList";
            reportDataSource1.Value = this.ClubsBindingSource;
            this.reportViewerClubs.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerClubs.LocalReport.ReportEmbeddedResource = "IOOP_Assignment.reportClubs.rdlc";
            this.reportViewerClubs.Location = new System.Drawing.Point(12, 165);
            this.reportViewerClubs.Name = "reportViewerClubs";
            this.reportViewerClubs.ServerReport.BearerToken = null;
            this.reportViewerClubs.Size = new System.Drawing.Size(681, 243);
            this.reportViewerClubs.TabIndex = 9;
            // 
            // ActivityTableAdapter
            // 
            this.ActivityTableAdapter.ClearBeforeFill = true;
            // 
            // ClubsTableAdapter
            // 
            this.ClubsTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewerActi
            // 
            this.reportViewerActi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewerActi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            reportDataSource2.Name = "dsActivity";
            reportDataSource2.Value = this.ActivityBindingSource;
            this.reportViewerActi.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewerActi.LocalReport.ReportEmbeddedResource = "IOOP_Assignment.reportActivity.rdlc";
            this.reportViewerActi.Location = new System.Drawing.Point(12, 165);
            this.reportViewerActi.Name = "reportViewerActi";
            this.reportViewerActi.ServerReport.BearerToken = null;
            this.reportViewerActi.Size = new System.Drawing.Size(681, 243);
            this.reportViewerActi.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(24, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(211, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "To:";
            // 
            // Generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(705, 420);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewerActi);
            this.Controls.Add(this.reportViewerClubs);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Generator";
            this.Text = "ReportGenerator";
            this.Load += new System.EventHandler(this.Generator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ClubsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClubs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActivityBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.RadioButton radActivities;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.RadioButton radClubs;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerClubs;
        private System.Windows.Forms.BindingSource ActivityBindingSource;
        private dsClubs dsClubs;
        private dsClubsTableAdapters.ActivityTableAdapter ActivityTableAdapter;
        private System.Windows.Forms.BindingSource ClubsBindingSource;
        private dsClubsTableAdapters.ClubsTableAdapter ClubsTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerActi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}