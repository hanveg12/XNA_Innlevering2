using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Tile_Engine;

namespace Level_Editor
{
    public partial class MainForm : Form
    {
        public EditorGame game;
        public string ControllerState;
        public Timer controllerStateTimer = new Timer();

        /// <summary>
        /// Kjører en gang og gjør nødvendige deklareringer
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitializeEditor();

            menuStrip1.Renderer = new Sandbox3Renderer();
            statusStrip1.Renderer = new StatusStripRenderer();

            menuStrip1.Click += new EventHandler(menuFocus);
            pctSurface.MouseDown += new MouseEventHandler(mapFocus);

            //Setter bakgrunnfargen og hvordan listen med bilder skal rendres
            this.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.listTiles.DrawItem += new DrawListViewItemEventHandler(ListItemManager.DrawListItems);

        }

        //Setter opp editoren
        private void InitializeEditor()
        {
            //Timer som styrer sjekking av kontrollertilkobling
            StartTimer();

            Application.EnableVisualStyles(); 
            LoadImageList();

            this.backgroundToolStripMenuItem.Checked = true;

            cboCodeValues.Items.Clear();
            cboCodeValues.Items.Add("None");
            cboCodeValues.Items.Add("Enemy");
            cboCodeValues.Items.Add("Lethal");
            cboCodeValues.Items.Add("EnemyBlocking");
            cboCodeValues.Items.Add("Start");

            cboCodeValues.SelectedIndex = 0;

            TileMap.EditorMode = true;
            FixViewPortScales();

            foreach (ToolStripMenuItem i in toolsToolStripMenuItem.DropDownItems)
            {
                i.Click += new EventHandler(changeTool);
            }
        }

        /// <summary>
        /// Laster inn bildene fra spritesheet til verktøykassen
        /// </summary>
        private void LoadImageList()
        {
            string filePath = Application.StartupPath + @"/Content/Textures/PlatformTiles.png";
            Bitmap tileSheet = new Bitmap(filePath);
            int tileCount = 0;
            for (int y = 0; y < tileSheet.Height / TileMap.TileHeight; y++)
            {
                for (int x = 0; x < tileSheet.Width / TileMap.TileWidth; x++)
                {
                    Bitmap newBitmap = tileSheet.Clone(
                        new System.Drawing.Rectangle(
                            x * TileMap.TileWidth,
                            y * TileMap.TileHeight,
                            TileMap.TileWidth,
                            TileMap.TileHeight),
                            System.Drawing.Imaging.PixelFormat.DontCare);

                    imgListTiles.Images.Add(newBitmap);
                    string itemName = "";
                    if (tileCount == 0)
                    {
                        itemName = "Empty block";
                    }

                    listTiles.Items.Add(itemName, tileCount++);
                }
            }
        }

        //Starter timeren som sjekker Xbox 360-kontrolleren
        private void StartTimer()
        {
            controllerStateTimer.Interval = 1000;
            controllerStateTimer.Tick += new EventHandler(updateControllerState);
            controllerStateTimer.Start();
        }

        private void updateControllerState(object sender, EventArgs e)
        {
            ControllerState = (GamePad.GetState(PlayerIndex.One).IsConnected) ? "Connected" : "Not Connected";
            this.xbox360ControllerStateLabel.Text = "Xbox 360 Controller: " + ControllerState;
        }

        //Setter fokus til menyen
        private void menuFocus(object sender, EventArgs e)
        {
            game.MapFocused = false;
        }

        //Setter fokus til pctSurface
        private void mapFocus(object sender, EventArgs e)
        {
            game.MapFocused = true;
        }

        //Fikser proporsjoner med kameraet
        private void FixViewPortScales()
        {
            Camera.ViewPortWidth = pctSurface.Width;
            Camera.ViewPortHeight = pctSurface.Height;
            Camera.Move(Vector2.Zero);
        }

        //Setter alle elementene i den valgte verktøylinjen til ikke krysset av
        private void UnCheckAll(ToolStripMenuItem menu)
        {
            foreach (ToolStripMenuItem item in menu.DropDown.Items)
            {
                item.Checked = false;
            }
        }

        //Sjekker hvilken indeks det valgte elementet har i dropdown-menyen
        private int checkIndexInDropDown(ToolStripMenuItem menu, ToolStripItem dropdown)
        {
            int index = -1;
            for (int iterator = 0; iterator < menu.DropDownItems.Count; iterator++)
            {
                if (menu.DropDownItems[iterator] == dropdown)
                {
                    index = iterator;
                }
            }
            return index;
        }

        //Endre tegneverktøyet 
        private void changeTool(object sender, EventArgs e)
        {
            game.SelectedTool = sender.ToString().ToLower();
        }

        //Lukker applikasjonen
        private void CloseApp()
        {
            game.Exit();
            Application.Exit();
        }

        //Når man trykker på lukk-knappen i programmet
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseApp();
        }

        //Exit-knappen i filmenyen
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseApp();
        }

        //Endre hvilken tile som skal velges
        private void listTiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listTiles.SelectedIndices.Count > 0)
            {
                game.DrawTile = listTiles.SelectedIndices[0];
            }
        }

        //Når man endrer størrelsen på vinduet, fikses kameraet
        private void MainForm_Resize(object sender, EventArgs e)
        {
            FixViewPortScales();
        }

        //Endrer hvilket lag det skal tegnes på
        private void changeLayer(object sender, EventArgs e)
        {
            var itemClicked = ((ToolStripMenuItem)sender);
            UnCheckAll(layersToolStripMenuItem);
            itemClicked.Checked = true;
            game.DrawLayer = checkIndexInDropDown(layersToolStripMenuItem, itemClicked);
        }

        private void loadMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Map files (*.map)|*.map";
            dialog.InitialDirectory = Application.StartupPath + @"\Maps";
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    TileMap.LoadMap(new FileStream(dialog.FileName, FileMode.Open));
                }

                catch
                {
                    MessageBox.Show("Kan ikke åpne filen");
                }
            }
        }

        private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "Map files (*.map)|*.map";
            dialog.InitialDirectory = Application.StartupPath + @"\Maps";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    TileMap.SaveMap(new FileStream(dialog.FileName, FileMode.Create));
                }

                catch
                {
                    MessageBox.Show("Kan ikke lagre filen");
                }
            }
        }

        private void clearMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TileMap.ClearMap();
        }

        private void cboCodeValues_SelectionChangeCommitted(object sender, EventArgs e)
        {
            game.CurrentCodeValue = cboCodeValues.Text;
        }
    }
}
