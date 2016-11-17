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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ddbSettings = new System.Windows.Forms.ToolStripDropDownButton();
            this.miPathOld = new System.Windows.Forms.ToolStripMenuItem();
            this.miPath5 = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdRotator = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
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
            this.miPathOld.Size = new System.Drawing.Size(152, 22);
            this.miPathOld.Text = "NetRotator";
            this.miPathOld.Click += new System.EventHandler(this.miPathClick);
            // 
            // miPath5
            // 
            this.miPath5.Name = "miPath5";
            this.miPath5.Size = new System.Drawing.Size(152, 22);
            this.miPath5.Text = "NetRotator5+";
            this.miPath5.Click += new System.EventHandler(this.miPathClick);
            // 
            // ofdRotator
            // 
            this.ofdRotator.FileName = "openFileDialog1";
            this.ofdRotator.Filter = "AntennaNetRotator.exe|AntennaNetRotator.exe";
            this.ofdRotator.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdRotator_FileOk);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 314);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FMain";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton ddbSettings;
        private System.Windows.Forms.ToolStripMenuItem miPathOld;
        private System.Windows.Forms.ToolStripMenuItem miPath5;
        private System.Windows.Forms.OpenFileDialog ofdRotator;
    }
}

