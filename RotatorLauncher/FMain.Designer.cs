namespace RotatorLauncher
{
    partial class FMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ddbSettings = new System.Windows.Forms.ToolStripDropDownButton();
            this.miPathOld = new System.Windows.Forms.ToolStripMenuItem();
            this.miPath5 = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdRotator = new System.Windows.Forms.OpenFileDialog();
            this.dgvDevices = new System.Windows.Forms.DataGridView();
            this.Band = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Run = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Run2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmDevices = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddbSettings});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(355, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ddbSettings
            // 
            this.ddbSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ddbSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPathOld,
            this.miPath5});
            this.ddbSettings.Image = ((System.Drawing.Image)(resources.GetObject("ddbSettings.Image")));
            this.ddbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbSettings.Name = "ddbSettings";
            this.ddbSettings.Size = new System.Drawing.Size(29, 22);
            this.ddbSettings.Text = "toolStripDropDownButton1";
            // 
            // miPathOld
            // 
            this.miPathOld.Name = "miPathOld";
            this.miPathOld.Size = new System.Drawing.Size(146, 22);
            this.miPathOld.Text = "NetRotator";
            this.miPathOld.Click += new System.EventHandler(this.miPathClick);
            // 
            // miPath5
            // 
            this.miPath5.Name = "miPath5";
            this.miPath5.Size = new System.Drawing.Size(146, 22);
            this.miPath5.Text = "NetRotator5+";
            this.miPath5.Click += new System.EventHandler(this.miPathClick);
            // 
            // ofdRotator
            // 
            this.ofdRotator.FileName = "openFileDialog1";
            this.ofdRotator.Filter = "AntennaNetRotator.exe|AntennaNetRotator.exe";
            this.ofdRotator.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdRotator_FileOk);
            // 
            // dgvDevices
            // 
            this.dgvDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Band,
            this.Run,
            this.Run2});
            this.dgvDevices.ContextMenuStrip = this.cmDevices;
            this.dgvDevices.Location = new System.Drawing.Point(0, 0);
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.Size = new System.Drawing.Size(355, 312);
            this.dgvDevices.TabIndex = 1;
            this.dgvDevices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDevices_CellClick);
            // 
            // Band
            // 
            this.Band.DataPropertyName = "band";
            this.Band.Frozen = true;
            this.Band.HeaderText = "Band";
            this.Band.Name = "Band";
            this.Band.ReadOnly = true;
            // 
            // Run
            // 
            this.Run.DataPropertyName = "run";
            this.Run.HeaderText = "Run";
            this.Run.Name = "Run";
            this.Run.ReadOnly = true;
            // 
            // Run2
            // 
            this.Run2.DataPropertyName = "run2";
            this.Run2.HeaderText = "2nd";
            this.Run2.Name = "Run2";
            this.Run2.ReadOnly = true;
            // 
            // cmDevices
            // 
            this.cmDevices.Name = "cmDevices";
            this.cmDevices.Size = new System.Drawing.Size(153, 26);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 314);
            this.Controls.Add(this.dgvDevices);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FMain";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton ddbSettings;
        private System.Windows.Forms.ToolStripMenuItem miPathOld;
        private System.Windows.Forms.ToolStripMenuItem miPath5;
        private System.Windows.Forms.OpenFileDialog ofdRotator;
        private System.Windows.Forms.DataGridView dgvDevices;
        private System.Windows.Forms.DataGridViewTextBoxColumn Band;
        private System.Windows.Forms.DataGridViewTextBoxColumn Run;
        private System.Windows.Forms.DataGridViewTextBoxColumn Run2;
        private System.Windows.Forms.ContextMenuStrip cmDevices;
    }
}

