using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Level_Editor
{
    public abstract class GameObject
    {

        public GameObject(Point pos)
        {
            Position = pos;
        }

        protected Color defaultColor = Color.White;

        public Point Position;

        protected Texture2D Graphic { get; set; }

        protected Rectangle Source { get; set; }

        protected Rectangle Destination { get; set; }
    }
}
