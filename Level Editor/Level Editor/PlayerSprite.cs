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
using Tile_Engine;

namespace Level_Editor
{
    class PlayerSprite : AnimationSprite
    {
        private bool playerOnGround = false;
        private int jumpspeed = 0;

        public PlayerSprite(Point pos, int moveSpeed, string defaultAnimation)
            : base(pos, moveSpeed, defaultAnimation)
        {
        }

        public void Update(GameTime gt, InputComponent input)
        {

            //oppdater animasjonen hvis man ikke trykke noen knapper
            CurrentAnimation = NextAnimation;

            //Animasjon av spilleren mot venstre
            if (input.KeyDown(Keys.Left))
            {
                CurrentAnimation = "runLeft";
                NextAnimation = "idleLeft";
                MoveLeft();
            }

            //Animasjon av spilleren mot høyre
            if (input.KeyDown(Keys.Right))
            {
                CurrentAnimation = "runRight";
                NextAnimation = "idleRight";
                MoveRight();
            }


            //hopplogikk
            if (!playerOnGround)
            {
                this.Position.Y += jumpspeed;
                jumpspeed++;

                if (this.Position.Y >= 300)
                {
                    playerOnGround = true;
                }
            }

            else
            {
                if (input.KeyDown(Keys.Up))
                {
                    playerOnGround = false;
                    jumpspeed = -18;
                }
            }

            base.Update(gt);
        }

        public void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }
    }
}
