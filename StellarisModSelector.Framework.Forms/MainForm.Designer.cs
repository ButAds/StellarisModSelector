namespace StellarisModSelector.Framework.Forms
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exportPackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePacksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbDownloadedMods = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPacks = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Packs";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportPackToolStripMenuItem,
            this.savePacksToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(822, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exportPackToolStripMenuItem
            // 
            this.exportPackToolStripMenuItem.Name = "exportPackToolStripMenuItem";
            this.exportPackToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.exportPackToolStripMenuItem.Text = "Reload Mods";
            this.exportPackToolStripMenuItem.Click += new System.EventHandler(this.exportPackToolStripMenuItem_Click);
            // 
            // savePacksToolStripMenuItem
            // 
            this.savePacksToolStripMenuItem.Name = "savePacksToolStripMenuItem";
            this.savePacksToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.savePacksToolStripMenuItem.Text = "Save Packs";
            // 
            // lbDownloadedMods
            // 
            this.lbDownloadedMods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDownloadedMods.FormattingEnabled = true;
            this.lbDownloadedMods.Location = new System.Drawing.Point(185, 40);
            this.lbDownloadedMods.Name = "lbDownloadedMods";
            this.lbDownloadedMods.Size = new System.Drawing.Size(120, 381);
            this.lbDownloadedMods.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Downloaded Mods";
            // 
            // cbPacks
            // 
            this.cbPacks.FormattingEnabled = true;
            this.cbPacks.Location = new System.Drawing.Point(12, 41);
            this.cbPacks.Name = "cbPacks";
            this.cbPacks.Size = new System.Drawing.Size(167, 21);
            this.cbPacks.TabIndex = 5;
            this.cbPacks.SelectedIndexChanged += new System.EventHandler(this.cbPacks_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 430);
            this.Controls.Add(this.cbPacks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbDownloadedMods);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportPackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePacksToolStripMenuItem;
        private System.Windows.Forms.ListBox lbDownloadedMods;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPacks;
    }
}

