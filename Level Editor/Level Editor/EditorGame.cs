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
using Tile_Engine;

namespace Level_Editor
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class EditorGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        IntPtr drawSurface;
        System.Windows.Forms.Form parentForm;
        System.Windows.Forms.PictureBox pictureBox;
        System.Windows.Forms.Control gameForm;

        MainForm editorForm = new MainForm();

        public int DrawLayer = 0;
        public int DrawTile = 0;
        public bool EditingCode = false;
        public string CurrentCodeValue = "";
        public string HoverCodeValue = "";

        public string SelectedTool = "draw";

        public bool EditorIsActive = true;
        public bool MapFocused = true;

        public MouseState prevMouseState;
        public MouseState currMouseState;


        public EditorGame(IntPtr drawSurface, System.Windows.Forms.Form parentForm, System.Windows.Forms.PictureBox surfacePictureBox)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.drawSurface = drawSurface;
            this.parentForm = parentForm;
            this.pictureBox = surfacePictureBox;

            graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(graphics_PreparingDeviceSettings);
            Mouse.WindowHandle = drawSurface;

            gameForm = System.Windows.Forms.Control.FromHandle(this.Window.Handle);
            gameForm.VisibleChanged += new EventHandler(gameForm_VisibleChanged);
            parentForm.SizeChanged += new EventHandler(pictureBox_SizeChanged);

            parentForm.Activated += new EventHandler(parentForm_ChangeActiveState);
            parentForm.Deactivate += new EventHandler(parentForm_ChangeActiveState);
        }

        void parentForm_ChangeActiveState(object sender, EventArgs e)
        {
            EditorIsActive = !EditorIsActive;
        }

        void pictureBox_SizeChanged(object sender, EventArgs e)
        {
            if (parentForm.WindowState != System.Windows.Forms.FormWindowState.Minimized)
            {
                graphics.PreferredBackBufferWidth = pictureBox.Width;
                graphics.PreferredBackBufferHeight = pictureBox.Height;
                Camera.ViewPortWidth = pictureBox.Width;
                Camera.ViewPortHeight = pictureBox.Height;
                graphics.ApplyChanges();
            }
        }

        void gameForm_VisibleChanged(object sender, EventArgs e)
        {
            if (gameForm.Visible == true)
            {
                gameForm.Visible = false;
            }
        }

        void graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            e.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = drawSurface;
        }

        protected override void Initialize()
        {
            Audio.Initialize();
            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Camera.ViewPortWidth = pictureBox.Width;
            Camera.ViewPortHeight = pictureBox.Height;
            Camera.WorldRectangle = new Rectangle(
                0, 
                0, 
                TileMap.TileWidth * TileMap.MapWidth, 
                TileMap.TileHeight * TileMap.MapHeight);
            Camera.Position = new Vector2(0, Camera.WorldRectangle.Height - Camera.ViewPortHeight);

            TileMap.Initialize(Content.Load<Texture2D>(@"Textures\PlatformTiles"));
            TileMap.spriteFont = Content.Load<SpriteFont>(@"Fonts\Pericles8");

            prevMouseState = Mouse.GetState();

            pictureBox_SizeChanged(null, null);

            Audio.layTile = Content.Load<SoundEffect>("Audio/SFX/WeirdMetalicSelectDelicate");
            Audio.toggle = Content.Load<SoundEffect>("Audio/SFX/ScrollE");


            //Creating instances of SoundEffects
            Audio.layTileInstance = Audio.layTile.CreateInstance();
            Audio.toggleInstance = Audio.toggle.CreateInstance();

            Audio.themeA = Content.Load<Song>("Audio/BackgroundMusic/Home Base Groove");
            Audio.themeB = Content.Load<Song>("Audio/BackgroundMusic/Home Base Groove");
            
            Audio.LoadContent();
        }


        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
            currMouseState = Mouse.GetState();

            if ((currMouseState.X > 0) && (currMouseState.Y > 0) && (currMouseState.X < Camera.ViewPortWidth) && (currMouseState.Y < Camera.ViewPortHeight))
            {
                Vector2 mouseLoc = Camera.ScreenToWorld(new Vector2(currMouseState.X, currMouseState.Y));

                //sjekk om musepekeren er inne i tegneområdet og om editoren er det aktive vinduet
                if (Camera.WorldRectangle.Contains((int)mouseLoc.X, (int)mouseLoc.Y) && MapFocused && EditorIsActive)
                {

                    if (currMouseState.RightButton == ButtonState.Pressed)
                    {
                        TileMap.GetMapSquareAtPixel(mouseLoc).CodeValue = CurrentCodeValue;
                    }

                    if (currMouseState.LeftButton == ButtonState.Pressed)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                        {
                            Vector2 offset = new Vector2((currMouseState.X - prevMouseState.X), (currMouseState.Y - prevMouseState.Y));
                            Camera.Move(-offset);
                        }

                        else
                        {
                            switch (SelectedTool)
                            {
                                case "draw":
                                    TileMap.SetTileAtCell(
                                    TileMap.GetCellByPixelX((int)mouseLoc.X),
                                    TileMap.GetCellByPixelY((int)mouseLoc.Y),
                                    DrawLayer,
                                    DrawTile);
                                    if (Audio.soundOn == true)
                                        Audio.layTileInstance.Play();
                                    break;

                                case "toggle":
                                    //Enkel-klikk
                                    if (currMouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                                    {
                                        TileMap.GetMapSquareAtPixel((int)mouseLoc.X, (int)mouseLoc.Y).TogglePassable();
                                        if (Audio.soundOn == true)
                                            Audio.toggleInstance.Play();
                                    }
                                    //Hold inne og dra
                                    else if (currMouseState != prevMouseState)
                                    {
                                        TileMap.GetMapSquareAtPixel((int)mouseLoc.X, (int)mouseLoc.Y).SetTileCollidable();
                                        if (Audio.soundOn == true)
                                            Audio.toggleInstance.Play();
                                    }
                                    break;

                                default:
                                    return;
                            }
                        }
                    }
                }
            }

            Audio.Update(gameTime);           
            base.Update(gameTime);

            prevMouseState = currMouseState;
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            TileMap.Draw(spriteBatch);

            spriteBatch.DrawString(TileMap.spriteFont, "Camera position: " + Camera.Position.ToString(), new Vector2(5, 0), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
