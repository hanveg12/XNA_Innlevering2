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

using System.IO;

namespace Level_Editor
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        PlayerSprite player;

        InputComponent inputManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            inputManager = new InputComponent(this);
            Components.Add(inputManager);

            Audio.Initialize();

            //initaliser kamera
            Camera.ViewPortWidth = GraphicsDevice.Viewport.Width;
            Camera.ViewPortHeight = GraphicsDevice.Viewport.Height;
            Camera.WorldRectangle = GraphicsDevice.Viewport.Bounds;
            Camera.Position = new Vector2(0, Camera.WorldRectangle.Height - Camera.ViewPortHeight);

            //initialiser TileMap
            TileMap.EditorMode = false;
            TileMap.Initialize(Content.Load<Texture2D>(@"Textures\PlatformTiles"));
            TileMap.spriteFont = Content.Load<SpriteFont>(@"Fonts\Pericles8");

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player = new PlayerSprite(new Point(400, 200), 5, "idleRight");

            player.Animations.Add("runLeft",
                new Animation(Content.Load<Texture2D>("Textures/FRunLeft"), 48, 48, 55, 8, true));
            player.Animations.Add("runRight",
                new Animation(Content.Load<Texture2D>("Textures/FRunRight"), 48, 48, 55, 8, false));
            player.Animations.Add("idleLeft",
                new Animation(Content.Load<Texture2D>("Textures/IdleLeft"), 48, 48, 890, 2, true));
            player.Animations.Add("idleRight",
                new Animation(Content.Load<Texture2D>("Textures/IdleRight"), 48, 48, 890, 2, false));
            player.Animations.Add("jumpLeft",
                new Animation(Content.Load<Texture2D>("Textures/JumpLeft"), 48, 48, 110, 7, true));
            player.Animations.Add("jumpRight",
                new Animation(Content.Load<Texture2D>("Textures/JumpRight"), 48, 48, 110, 7, false));
            
            Audio.themeA = Content.Load<Song>("Audio/BackgroundMusic/Noise Attack");
            Audio.themeB = Content.Load<Song>("Audio/BackgroundMusic/Summon the Rawk");
            
            Audio.LoadContent();

                

            //last inn nivået
            LoadLevel("Test");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {


            //Oppdater spilleren ved å sende med input-systemet
            player.Update(gameTime, inputManager);

            Audio.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            TileMap.Draw(spriteBatch);
            player.Draw(spriteBatch);

            spriteBatch.End();
            
            base.Draw(gameTime);
        }

        private void LoadLevel(string levelName)
        {
            try
            {

                TileMap.LoadMap((FileStream)TitleContainer.
                    OpenStream(@"Maps\" + levelName + ".map"));

                for (int x = 0; x < TileMap.MapWidth; x++)
                {
                    for (int y = 0; y < TileMap.MapHeight; y++)
                    {
                        if (TileMap.CellCodeValue(x, y) == "Start")
                        {
                            player.Position = new Point(x * TileMap.TileWidth, y * TileMap.TileHeight);
                        }
                    }
                }
            }

            catch(FileNotFoundException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }
    }
}
