using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Level_Editor
{
    public class StatusStripRenderer : ToolStripRenderer
    {
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            SolidBrush bgColor = new SolidBrush(Color.FromArgb(20, 20, 20));
            e.Graphics.FillRectangle(bgColor, e.AffectedBounds);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(15, 15, 15), 3), 0, 0, e.AffectedBounds.Width, 0);
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = Color.White;
            base.OnRenderItemText(e);
        }
    }
}
