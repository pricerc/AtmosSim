using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using Microsoft.VisualBasic.CompilerServices;

namespace WinFormsApp1
{
    [DesignerGenerated()]
    public partial class SkyForm : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.humanLocations = new System.Windows.Forms.ToolStripStatusLabel();
            this.mouseLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this.GasStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeSelector = new System.Windows.Forms.ToolStripMenuItem();
            this.modeSelector = new System.Windows.Forms.ToolStripMenuItem();
            this.DarkMode = new System.Windows.Forms.ToolStripMenuItem();
            this.LightMode = new System.Windows.Forms.ToolStripMenuItem();
            this.spaceRatioSelector = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightSelector = new System.Windows.Forms.ToolStripMenuItem();
            this.humanCO2HighlightSelector = new System.Windows.Forms.ToolStripMenuItem();
            this.cO2HighlightSelector = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.White;
            this.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBox1.Location = new System.Drawing.Point(8, 8);
            this.PictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.PictureBox1.MaximumSize = new System.Drawing.Size(3810, 2100);
            this.PictureBox1.MinimumSize = new System.Drawing.Size(1250, 800);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(1250, 800);
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.humanLocations,
            this.mouseLocation,
            this.GasStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(8, 32);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(768, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // humanLocations
            // 
            this.humanLocations.Name = "humanLocations";
            this.humanLocations.Size = new System.Drawing.Size(52, 17);
            this.humanLocations.Text = "Man: 0,0";
            // 
            // mouseLocation
            // 
            this.mouseLocation.Name = "mouseLocation";
            this.mouseLocation.Size = new System.Drawing.Size(64, 17);
            this.mouseLocation.Text = "Mouse: 0,0";
            // 
            // GasStatusLabel
            // 
            this.GasStatusLabel.Name = "GasStatusLabel";
            this.GasStatusLabel.Size = new System.Drawing.Size(40, 17);
            this.GasStatusLabel.Text = "Gases:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.sizeSelector,
            this.modeSelector,
            this.spaceRatioSelector,
            this.highlightSelector});
            this.menuStrip1.Location = new System.Drawing.Point(8, 8);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(768, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAs});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveAs
            // 
            this.saveAs.Name = "saveAs";
            this.saveAs.Size = new System.Drawing.Size(123, 22);
            this.saveAs.Text = "Save As...";
            // 
            // sizeSelector
            // 
            this.sizeSelector.Name = "sizeSelector";
            this.sizeSelector.Size = new System.Drawing.Size(80, 20);
            this.sizeSelector.Text = "Canvas Size";
            // 
            // modeSelector
            // 
            this.modeSelector.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DarkMode,
            this.LightMode});
            this.modeSelector.Name = "modeSelector";
            this.modeSelector.Size = new System.Drawing.Size(50, 20);
            this.modeSelector.Text = "Mode";
            // 
            // DarkMode
            // 
            this.DarkMode.Checked = true;
            this.DarkMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DarkMode.Name = "DarkMode";
            this.DarkMode.Size = new System.Drawing.Size(101, 22);
            this.DarkMode.Text = "Dark";
            // 
            // LightMode
            // 
            this.LightMode.Name = "LightMode";
            this.LightMode.Size = new System.Drawing.Size(101, 22);
            this.LightMode.Text = "Light";
            // 
            // spaceRatioSelector
            // 
            this.spaceRatioSelector.Name = "spaceRatioSelector";
            this.spaceRatioSelector.Size = new System.Drawing.Size(77, 20);
            this.spaceRatioSelector.Text = "Space ratio";
            // 
            // highlightSelector
            // 
            this.highlightSelector.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.humanCO2HighlightSelector,
            this.cO2HighlightSelector});
            this.highlightSelector.Name = "highlightSelector";
            this.highlightSelector.Size = new System.Drawing.Size(69, 20);
            this.highlightSelector.Text = "Highlight";
            // 
            // humanCO2HighlightSelector
            // 
            this.humanCO2HighlightSelector.CheckOnClick = true;
            this.humanCO2HighlightSelector.Name = "humanCO2HighlightSelector";
            this.humanCO2HighlightSelector.Size = new System.Drawing.Size(140, 22);
            this.humanCO2HighlightSelector.Text = "Human CO2";
            // 
            // cO2HighlightSelector
            // 
            this.cO2HighlightSelector.CheckOnClick = true;
            this.cO2HighlightSelector.Name = "cO2HighlightSelector";
            this.cO2HighlightSelector.Size = new System.Drawing.Size(140, 22);
            this.cO2HighlightSelector.Text = "CO2";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(8, 8);
            this.panel1.Controls.Add(this.PictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(8);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(768, 299);
            this.panel1.TabIndex = 3;
            // 
            // SkyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(8, 8);
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "SkyForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The air that we breathe";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal PictureBox PictureBox1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel humanLocations;
        private ToolStripStatusLabel mouseLocation;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem sizeSelector;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveAs;
        private ToolStripMenuItem modeSelector;
        private ToolStripMenuItem DarkMode;
        private ToolStripMenuItem LightMode;
        private ToolStripMenuItem spaceRatioSelector;
        private ToolStripMenuItem highlightSelector;
        private ToolStripMenuItem humanCO2HighlightSelector;
        private ToolStripMenuItem cO2HighlightSelector;
        private ToolStripStatusLabel GasStatusLabel;
        private Panel panel1;
    }
}