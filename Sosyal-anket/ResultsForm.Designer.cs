using System;
using System.Windows.Forms;
using System.Drawing;

namespace Sosyal_anket
{
    partial class ResultsForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvResults;
        private Button btnSaveCsv;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultsForm));
            dgvResults = new DataGridView();
            btnSaveCsv = new Button();
            tslInfo = new ToolStripStatusLabel();
            statusStrip1 = new StatusStrip();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.ColumnHeadersHeight = 40;
            dgvResults.Location = new Point(12, 12);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.RowHeadersWidth = 72;
            dgvResults.Size = new Size(1872, 583);
            dgvResults.TabIndex = 0;
            // 
            // btnSaveCsv
            // 
            btnSaveCsv.Font = new Font("Segoe UI", 9F);
            btnSaveCsv.Location = new Point(12, 400);
            btnSaveCsv.Name = "btnSaveCsv";
            btnSaveCsv.Size = new Size(160, 36);
            btnSaveCsv.TabIndex = 1;
            btnSaveCsv.Text = "CSV kimi yadda saxla";
            btnSaveCsv.Click += btnSaveCsv_Click;
            // 
            // tslInfo
            // 
            tslInfo.Name = "tslInfo";
            tslInfo.Size = new Size(78, 37);
            tslInfo.Text = "Hazır";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(28, 28);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tslInfo });
            statusStrip1.Location = new Point(0, 624);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1896, 46);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // ResultsForm
            // 
            ClientSize = new Size(1896, 670);
            Controls.Add(dgvResults);
            Controls.Add(btnSaveCsv);
            Controls.Add(statusStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ResultsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nəticələr";
            Load += ResultsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private ToolStripStatusLabel tslInfo;
        private StatusStrip statusStrip1;
    }
}
