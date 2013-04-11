using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Level_Editor
{
    public class InputComponent : Microsoft.Xna.Framework.GameComponent
    {
        public KeyboardState currentKeyboardState, previousKeyboardState;
        public MouseState currentMouseState, previousMouseState;

        public InputComponent(Game game)
            : base(game)
        {
        }


        public Vector2 MousePosition
        {
            get
            {
                return new Vector2(currentMouseState.X, currentMouseState.Y);
            }
        }

        public bool OnKeyPress(Keys key)
        {
            return (previousKeyboardState.IsKeyUp(key)) && (currentKeyboardState.IsKeyDown(key));
        }

        public bool KeyDown(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key);
        }

        public override void Initialize()
        {
            currentKeyboardState = Keyboard.GetState();
            currentMouseState = Mouse.GetState();

            base.Initialize();
        }


        public override void Update(GameTime gameTime)
        {
            currentKeyboardState = Keyboard.GetState();
            currentMouseState = Mouse.GetState();

            base.Update(gameTime);

            previousKeyboardState = currentKeyboardState;
            previousMouseState = currentMouseState;

            
        }
    }
}
