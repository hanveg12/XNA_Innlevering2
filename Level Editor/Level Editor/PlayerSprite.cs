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
        private bool facingRight = true;

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
                facingRight = false;
            }

            //Animasjon av spilleren mot høyre
            if (input.KeyDown(Keys.Right))
            {
                CurrentAnimation = "runRight";
                NextAnimation = "idleRight";
                MoveRight();
                facingRight = true;
            }


            //hopplogikk
            if (!playerOnGround)
            {
                this.Position.Y += jumpspeed;
                jumpspeed++;

                if (CheckMapCollision())
                {
                    playerOnGround = true;
                    if (facingRight)
                    {
                        NextAnimation = "idleRight";
                    }
                    else
                    {
                        NextAnimation = "idleLeft";
                    }
                }
            }

            else
            {
                if (input.KeyDown(Keys.Up))
                {
                    if (facingRight)
                    {
                        CurrentAnimation = "jumpRight";
                        NextAnimation = "jumpRight";
                    }

                    else
                    {
                        CurrentAnimation = "jumpLeft";
                        NextAnimation = "jumpLeft";
                    }
                    playerOnGround = false;
                    jumpspeed = -15;
                }
            }

            int screenLocation = (int)Camera.WorldToScreen(new Vector2(this.Position.X, this.Position.Y)).X;

            if (screenLocation > 500)
            {
                Camera.Move(new Vector2(screenLocation - 500, 0));
            }

            if(screenLocation < 200)
            {
                Camera.Move(new Vector2(screenLocation - 200, 0));
            }
            
            base.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }

        private bool CheckMapCollision()
        {
            Vector2 tileToCheckPosition = TileMap.GetCellByPixel(new Vector2(Position.X, Position.Y + 48));
            //playerOnGround = false;

            if (!TileMap.CellIsPassable(tileToCheckPosition))
            {
                playerOnGround = true;
                return true;
            }

            return false;
        }
    }
}
