using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Level_Editor
{
    public class Sandbox3Renderer : ToolStripRenderer
    {
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            SolidBrush mainBg = new SolidBrush(Color.FromArgb(39, 39, 39));
            SolidBrush dropDownBg = new SolidBrush(Color.FromArgb(30, 30, 30)); 

            //Draw gradient background
            e.Graphics.FillRectangle(mainBg, e.AffectedBounds);

            //Draw bottom border on the MenuStrip
            e.Graphics.DrawLine(new Pen(Color.FromArgb(18, 18, 18), 3), e.AffectedBounds.X, e.AffectedBounds.Height - 1, e.AffectedBounds.X + e.AffectedBounds.Width, e.AffectedBounds.Height - 1);
            mainBg.Dispose();

            if (e.ToolStrip.IsDropDown)
            {
                e.Graphics.FillRectangle(dropDownBg, e.AffectedBounds);
            }
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            //OnHover
            e.Item.Margin = new Padding(1, 0, 0, 0);
            if (e.Item.Selected && !e.Item.IsOnDropDown)
            {
                //Border
                Pen hoverStroke = new Pen(Color.Orange);

                //The path to draw within
                GraphicsPath outlinePath = GraphicsTools.Rectangle(1, 0, e.Item.Width - 2, e.Item.Height - 2, 5, 5, 5, 5);

                e.Graphics.DrawPath(hoverStroke, outlinePath);
            }

            //OnPress
            if (e.Item.Pressed && !e.Item.IsOnDropDown)
            {
                //Solid fill
                SolidBrush fill = new SolidBrush(Color.FromArgb(180, 104, 15));

                //Border
                Pen activeStroke = new Pen(Color.Orange);

                GraphicsPath outlinePath = GraphicsTools.Rectangle(1, 0, e.Item.Width - 2, e.Item.Height - 2, 5, 5, 5, 5);
                e.Graphics.FillPath(fill, outlinePath);
                e.Graphics.DrawPath(activeStroke, outlinePath);

                if (!e.Item.Enabled) return;
            }

            if (e.Item.Selected && e.Item.IsOnDropDown)
            {
                SolidBrush dropDownItemFill = new SolidBrush(Color.FromArgb(50, 180, 104, 15));
                Pen dropDownItemStroke = new Pen(Color.FromArgb(100, 50, 0));
                GraphicsPath outlinePath = GraphicsTools.Rectangle(1, 1, e.Item.Width - 4, e.Item.Height - 4, 0, 0, 0, 0);
                e.Graphics.FillPath(dropDownItemFill, outlinePath);
                e.Graphics.DrawPath(dropDownItemStroke, outlinePath);
            }
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            Color borderColor = Color.FromArgb(100,100,100);
            ButtonBorderStyle solid = ButtonBorderStyle.Solid;
            //Only on the dropdowns
            if (e.ToolStrip.IsDropDown)
            {
                ControlPaint.DrawBorder(e.Graphics, e.AffectedBounds,
                    borderColor, 1, solid,
                    borderColor, 1, solid,
                    borderColor, 1, solid,
                    borderColor, 1, solid);
            }
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = Color.White;
            base.OnRenderArrow(e);
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e.Item.Enabled)
            {
                e.TextColor = Color.White;
            }
            else
            {
                e.TextColor = Color.FromArgb(200, 200, 200);
            }
            base.OnRenderItemText(e);
        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            e.Graphics.FillRectangle(new LinearGradientBrush(e.AffectedBounds, Color.FromArgb(25, 25, 25), Color.FromArgb(55,55,55), 360), e.AffectedBounds);
            base.OnRenderImageMargin(e);
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.FromArgb(80, 80, 80)), 30, 0, e.Item.Width, 0);
        }

        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            Rectangle backRect = new Rectangle(5, 4, 13, 13);
            LinearGradientBrush bgBrush = new LinearGradientBrush(backRect, Color.FromArgb(255, 220, 120), Color.FromArgb(240, 160, 40), LinearGradientMode.Vertical);

            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(150, 50, 0)), 1), new Rectangle(4, 3, 14, 14));
            e.Graphics.FillRectangle(bgBrush, backRect);
            e.Graphics.DrawImage(e.Image, new Point(3, 3));
        }
    }
}
