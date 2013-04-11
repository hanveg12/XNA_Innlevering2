using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Level_Editor
{
    public static class ListItemManager
    {
        public static void DrawListItems(object sender, DrawListViewItemEventArgs e)
        {
            Rectangle itemRect = new Rectangle(e.Bounds.X + 5, e.Bounds.Y, e.Bounds.Width - 10, e.Bounds.Height - 1);

            SolidBrush selectedBackground = new SolidBrush(Color.FromArgb(100, 12, 123, 204));
            Pen selectedStroke = new Pen(Color.FromArgb(12, 123, 204));
            e.DrawDefault = true;
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(selectedBackground, itemRect);
                e.Graphics.DrawRectangle(selectedStroke, itemRect);
            }
        }
    }
}
