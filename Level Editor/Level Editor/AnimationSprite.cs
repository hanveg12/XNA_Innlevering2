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
    public class AnimationSprite : GameObject, IDrawable
    {
        protected int _moveSpeed;
        protected string currentAnimation;
        protected string nextAnimation;

        protected Dictionary<string, Animation> animations = new Dictionary<string, Animation>();

        public Dictionary<string, Animation> Animations
        {
            get
            {
                return animations;
            }

            set
            {
                animations = value;
            }
        }

        public string CurrentAnimation
        {
            get
            {
                return currentAnimation;
            }

            set
            {
                currentAnimation = value;
            }
        }

        public string NextAnimation
        {
            get
            {
                return nextAnimation;
            }

            set
            {
                nextAnimation = value;
            }
        }


        public AnimationSprite(Point pos, int movespeed, string defaultAnimation) : base (pos)
        {
            currentAnimation = nextAnimation = defaultAnimation;
            _moveSpeed = movespeed;
        }

        public void MoveLeft()
        {
            this.Position.X -= _moveSpeed;
        }

        public void MoveRight()
        {
            this.Position.X += _moveSpeed;
        }

        public void Update(GameTime gt)
        {
            
            Destination = new Rectangle(Position.X, Position.Y, 
                animations[currentAnimation].Clip.Width,
                animations[currentAnimation].Clip.Height);

            if (animations.ContainsKey(currentAnimation))
            {
                animations[currentAnimation].IsRunning = true;
                animations[currentAnimation].Update(gt);
                Source = animations[currentAnimation].Clip;
            }
        }

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(animations[currentAnimation].Graphic, Destination, Source, defaultColor);
        }
    }
}
