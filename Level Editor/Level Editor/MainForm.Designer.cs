using System.Windows.Forms;
using System.Drawing;
namespace Level_Editor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interactiveLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foregroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawTileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.togglePassableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pctSurface = new System.Windows.Forms.PictureBox();
            this.imgListTiles = new System.Windows.Forms.ImageList(this.components);
            this.listTiles = new System.Windows.Forms.ListView();
            this.tilePropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCodeValues = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.appStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.xbox360ControllerStateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctSurface)).BeginInit();
            this.tilePropertiesGroupBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.layersToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMapToolStripMenuItem,
            this.loadMapToolStripMenuItem,
            this.saveMapToolStripMenuItem,
            this.saveMapAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newMapToolStripMenuItem
            // 
            this.newMapToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newMapToolStripMenuItem.Image")));
            this.newMapToolStripMenuItem.Name = "newMapToolStripMenuItem";
            this.newMapToolStripMenuItem.ShortcutKeyDisplayString = "                       Ctrl+N";
            this.newMapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newMapToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.newMapToolStripMenuItem.Text = "New map";
            // 
            // loadMapToolStripMenuItem
            // 
            this.loadMapToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadMapToolStripMenuItem.Image")));
            this.loadMapToolStripMenuItem.Name = "loadMapToolStripMenuItem";
            this.loadMapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadMapToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.loadMapToolStripMenuItem.Text = "Load map";
            this.loadMapToolStripMenuItem.Click += new System.EventHandler(this.loadMapToolStripMenuItem_Click);
            // 
            // saveMapToolStripMenuItem
            // 
            this.saveMapToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveMapToolStripMenuItem.Image")));
            this.saveMapToolStripMenuItem.Name = "saveMapToolStripMenuItem";
            this.saveMapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMapToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.saveMapToolStripMenuItem.Text = "Save map";
            this.saveMapToolStripMenuItem.Click += new System.EventHandler(this.saveMapToolStripMenuItem_Click);
            // 
            // saveMapAsToolStripMenuItem
            // 
            this.saveMapAsToolStripMenuItem.Enabled = false;
            this.saveMapAsToolStripMenuItem.Name = "saveMapAsToolStripMenuItem";
            this.saveMapAsToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.saveMapAsToolStripMenuItem.Text = "Save map as...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(234, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearMapToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // clearMapToolStripMenuItem
            // 
            this.clearMapToolStripMenuItem.Name = "clearMapToolStripMenuItem";
            this.clearMapToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearMapToolStripMenuItem.Text = "Clear map";
            this.clearMapToolStripMenuItem.Click += new System.EventHandler(this.clearMapToolStripMenuItem_Click);
            // 
            // layersToolStripMenuItem
            // 
            this.layersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundToolStripMenuItem,
            this.interactiveLayerToolStripMenuItem,
            this.foregroundToolStripMenuItem});
            this.layersToolStripMenuItem.Name = "layersToolStripMenuItem";
            this.layersToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.layersToolStripMenuItem.Text = "&Layers";
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.backgroundToolStripMenuItem.Text = "Background";
            this.backgroundToolStripMenuItem.Click += new System.EventHandler(this.changeLayer);
            // 
            // interactiveLayerToolStripMenuItem
            // 
            this.interactiveLayerToolStripMenuItem.Name = "interactiveLayerToolStripMenuItem";
            this.interactiveLayerToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.interactiveLayerToolStripMenuItem.Text = "Interactive layer";
            this.interactiveLayerToolStripMenuItem.Click += new System.EventHandler(this.changeLayer);
            // 
            // foregroundToolStripMenuItem
            // 
            this.foregroundToolStripMenuItem.Name = "foregroundToolStripMenuItem";
            this.foregroundToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.foregroundToolStripMenuItem.Text = "Foreground";
            this.foregroundToolStripMenuItem.Click += new System.EventHandler(this.changeLayer);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawTileToolStripMenuItem,
            this.togglePassableToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // drawTileToolStripMenuItem
            // 
            this.drawTileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("drawTileToolStripMenuItem.Image")));
            this.drawTileToolStripMenuItem.Name = "drawTileToolStripMenuItem";
            this.drawTileToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.drawTileToolStripMenuItem.Text = "Draw";
            // 
            // togglePassableToolStripMenuItem
            // 
            this.togglePassableToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("togglePassableToolStripMenuItem.Image")));
            this.togglePassableToolStripMenuItem.Name = "togglePassableToolStripMenuItem";
            this.togglePassableToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.togglePassableToolStripMenuItem.Text = "Toggle";
            // 
            // pctSurface
            // 
            this.pctSurface.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pctSurface.Location = new System.Drawing.Point(12, 27);
            this.pctSurface.Name = "pctSurface";
            this.pctSurface.Size = new System.Drawing.Size(596, 428);
            this.pctSurface.TabIndex = 1;
            this.pctSurface.TabStop = false;
            // 
            // imgListTiles
            // 
            this.imgListTiles.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgListTiles.ImageSize = new System.Drawing.Size(48, 48);
            this.imgListTiles.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listTiles
            // 
            this.listTiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listTiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.listTiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listTiles.ForeColor = System.Drawing.Color.Black;
            this.listTiles.LargeImageList = this.imgListTiles;
            this.listTiles.Location = new System.Drawing.Point(614, 27);
            this.listTiles.Name = "listTiles";
            this.listTiles.OwnerDraw = true;
            this.listTiles.Size = new System.Drawing.Size(174, 369);
            this.listTiles.TabIndex = 4;
            this.listTiles.UseCompatibleStateImageBehavior = false;
            this.listTiles.SelectedIndexChanged += new System.EventHandler(this.listTiles_SelectedIndexChanged);
            // 
            // tilePropertiesGroupBox
            // 
            this.tilePropertiesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tilePropertiesGroupBox.Controls.Add(this.label1);
            this.tilePropertiesGroupBox.Controls.Add(this.cboCodeValues);
            this.tilePropertiesGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tilePropertiesGroupBox.ForeColor = System.Drawing.Color.White;
            this.tilePropertiesGroupBox.Location = new System.Drawing.Point(614, 402);
            this.tilePropertiesGroupBox.Name = "tilePropertiesGroupBox";
            this.tilePropertiesGroupBox.Size = new System.Drawing.Size(174, 53);
            this.tilePropertiesGroupBox.TabIndex = 6;
            this.tilePropertiesGroupBox.TabStop = false;
            this.tilePropertiesGroupBox.Text = "On tile right-click";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Set Tile Code:";
            // 
            // cboCodeValues
            // 
            this.cboCodeValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCodeValues.FormattingEnabled = true;
            this.cboCodeValues.Location = new System.Drawing.Point(85, 19);
            this.cboCodeValues.Name = "cboCodeValues";
            this.cboCodeValues.Size = new System.Drawing.Size(83, 21);
            this.cboCodeValues.TabIndex = 2;
            this.cboCodeValues.SelectionChangeCommitted += new System.EventHandler(this.cboCodeValues_SelectionChangeCommitted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appStatusLabel,
            this.toolStripStatusLabel1,
            this.xbox360ControllerStateLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 458);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // appStatusLabel
            // 
            this.appStatusLabel.Name = "appStatusLabel";
            this.appStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.appStatusLabel.Text = "Ready";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(630, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // xbox360ControllerStateLabel
            // 
            this.xbox360ControllerStateLabel.Name = "xbox360ControllerStateLabel";
            this.xbox360ControllerStateLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.xbox360ControllerStateLabel.Size = new System.Drawing.Size(116, 17);
            this.xbox360ControllerStateLabel.Text = "Xbox 360 Controller: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tilePropertiesGroupBox);
            this.Controls.Add(this.listTiles);
            this.Controls.Add(this.pctSurface);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "SharpEd";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctSurface)).EndInit();
            this.tilePropertiesGroupBox.ResumeLayout(false);
            this.tilePropertiesGroupBox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.PictureBox pctSurface;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMapAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interactiveLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foregroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ImageList imgListTiles;
        private ListView listTiles;
        private GroupBox tilePropertiesGroupBox;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel appStatusLabel;
        private ToolStripStatusLabel xbox360ControllerStateLabel;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem drawTileToolStripMenuItem;
        private ToolStripMenuItem togglePassableToolStripMenuItem;
        private ToolStripMenuItem clearMapToolStripMenuItem;
        private ComboBox cboCodeValues;
        private Label label1;
    }
}