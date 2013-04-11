using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Tile_Engine
{
    //Kamera-klassen som viser en liten del av kartet til en hver tid
    //og som kan beveges etter spilleren.
    public static class Camera
    {
        /*Deklarasjoner*/
        private static Vector2 position = Vector2.Zero; //posisjonen til kameraet
        private static Vector2 viewPortSize = Vector2.Zero; //størrelsen på synsfeltet
        private static Rectangle worldRectangle = Rectangle.Empty; //størrelsen på hele kartet


        /*Egenskaper*/
        public static Vector2 Position
        {
            get { return position; }
            //Sørg for at kameraposisjonen settes innenfor de lovlige grensene
            set
            {
                position = new Vector2(
                    MathHelper.Clamp(value.X, worldRectangle.X, worldRectangle.Width - ViewPortWidth), 
                    MathHelper.Clamp(value.Y, worldRectangle.Y, worldRectangle.Width - ViewPortHeight)
                    );
            }
        }

        public static Rectangle WorldRectangle
        {
            get { return worldRectangle; }
            set { worldRectangle = value; }
        }

        public static int ViewPortWidth
        {
            get { return (int)viewPortSize.X; }
            set { viewPortSize.X = value; }
        }

        public static int ViewPortHeight
        {
            get { return (int)viewPortSize.Y; }
            set { viewPortSize.Y = value; }
        }

        public static Rectangle ViewPort
        {
            get
            {
                return new Rectangle(
                    (int)Position.X, 
                    (int)Position.Y, 
                    ViewPortWidth, 
                    ViewPortHeight);
            }
        }


        /*Metoder*/

        //Beveger kameraet
        public static void Move(Vector2 offset)
        {
            Position += offset;
        }

        //Sjekker om et objekt er innenfor synsfeltet
        public static bool ObjectIsVisible(Rectangle objectBounds)
        {
            return (ViewPort.Intersects(objectBounds));
        }

        //Metoder som konverterer fra globale koordinater til skjermkoordinater
        public static Vector2 WorldToScreen(Vector2 worldLocation)
        {
            return worldLocation - position;
        }

        public static Rectangle WorldToScreen(Rectangle worldRectangle)
        {
            return new Rectangle(
                worldRectangle.Left - (int)position.X,
                worldRectangle.Top - (int)position.Y,
                worldRectangle.Width,
                worldRectangle.Height);
        }

        //Metoder som konverterer fra skjermkoordinater til globale koordinater
        public static Vector2 ScreenToWorld(Vector2 screenLocation)
        {
            return screenLocation + position;
        }

        public static Rectangle ScreenToWorld(Rectangle screenRectangle)
        {
            return new Rectangle(
                screenRectangle.Left + (int)position.X,
                screenRectangle.Top + (int)position.Y,
                screenRectangle.Width,
                screenRectangle.Height);
        }
    }
}
