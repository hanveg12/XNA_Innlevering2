using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Level_Editor
{
    /// <summary>
    /// Klasse som inneholder verktøy for å tegne ting i et Windows Form
    /// </summary>
    public static class GraphicsTools
    {
        /// <summary>
        /// Bygger og returnerer en et rektangel, med eventuelle avrundede hjørner
        /// </summary>
        /// <param name="x">Startpunktets x-koordinat</param>
        /// <param name="y">Startpunktet y-koordinat</param>
        /// <param name="width">Bredden på rektangelet</param>
        /// <param name="height">Høyden på rektangelet</param>
        /// <param name="leftTopRadius">Avrundingsverdi for hjørne oppe til venstre</param>
        /// <param name="rightTopRadius">Avrundingsverdi for hjørne oppe til høyre</param>
        /// <param name="rightBottomRadius">Avrundingsverdi for hjørne nede til høyre</param>
        /// <param name="leftBottomRadius">Avrundingsverdi for hjørne nede til venstre</param>
        /// <returns>Et GraphicsPath-objekt som representerer rektangelet</returns>
        public static GraphicsPath Rectangle(int x, int y, int width, int height, int leftTopRadius, int rightTopRadius, int rightBottomRadius, int leftBottomRadius)
        {
            GraphicsPath p = new GraphicsPath();

            //Punkter for øvre venstre hjørne
            Point leftTopStart = new Point(x, y + leftTopRadius);
            Point leftTopStop = new Point(x + leftTopRadius, y);
            Point topLeftControlPoint = new Point(x, y);

            //Punkter for øvre høyre hjørne
            Point rightTopStart = new Point(x + width- rightTopRadius, y);
            Point rightTopStop = new Point(x + width, y + rightTopRadius);
            Point topRightControlPoint = new Point(x + width, y);

            //Punkter for nedre høyre hjørne
            Point rightBottomStart = new Point(x + width, y + height - rightBottomRadius);
            Point rightBottomStop = new Point(x + width - rightBottomRadius, y + height);
            Point bottomRightControlPoint = new Point(x + width, y + height);

            //Punkter for nedre venstre hjørne
            Point leftBottomStart = new Point(x + leftBottomRadius, y + height);
            Point leftBottomStop = new Point(x, y + height - leftBottomRadius);
            Point bottomLeftControlPoint = new Point(x, y + height);

            p.StartFigure();
            p.AddBezier(leftTopStart, topLeftControlPoint, topLeftControlPoint, leftTopStop); //Top left corner

            p.AddLine(x + leftTopRadius, y, x + width - rightTopRadius, y); //Top edge

            p.AddBezier(rightTopStart, topRightControlPoint, topRightControlPoint, rightTopStop); //Top right corner

            p.AddLine(x + width, y + rightTopRadius, x + width, y + height - rightBottomRadius); //Right edge

            p.AddBezier(rightBottomStart, bottomRightControlPoint, bottomRightControlPoint, rightBottomStop); // Bottom right corner

            p.AddLine(x + width - rightBottomRadius, y + height, x + leftBottomRadius, y + height); //Bottom edge

            p.AddBezier(leftBottomStart, bottomLeftControlPoint, bottomLeftControlPoint, leftBottomStop); // Bottom right corner

            p.CloseFigure();
            return p;
        }
    }
}
