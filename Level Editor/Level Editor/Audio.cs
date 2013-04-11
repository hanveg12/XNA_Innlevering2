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
    class Audio
    {
        public static KeyboardState prevKeyboardState;
        public static KeyboardState currKeyboardState;

        public static SoundEffect layTile;
        public static SoundEffect toggle;

        public static SoundEffectInstance layTileInstance;
        public static SoundEffectInstance toggleInstance;

        public static bool soundOn;
        public static Song themeA;
        public static Song themeB;
        public static bool themeAPlaying;
        public static MediaState mediaState;
        public static float songVolume;

        public static void Initialize()
        {
            prevKeyboardState = Keyboard.GetState();
            soundOn = true;
            MediaPlayer.IsRepeating = true;
            themeAPlaying = true;
            MediaPlayer.Volume = 0.5f;
            songVolume = MediaPlayer.Volume * 100;
        }

        public static void LoadContent()
        {
            MediaPlayer.Play(Audio.themeA);
        }

        public static void Update(GameTime gameTime)
        {
            currKeyboardState = Keyboard.GetState();

            //Mute musikk
            if (currKeyboardState.IsKeyDown(Keys.F1) && prevKeyboardState.IsKeyUp(Keys.F1))
            {
                if (MediaPlayer.IsMuted == true)
                    MediaPlayer.IsMuted = false;
                else if (MediaPlayer.IsMuted == false)
                    MediaPlayer.IsMuted = true;
                songVolume = MediaPlayer.Volume * 100;
            }

            //Skru musikk-volumet ned
            if (currKeyboardState.IsKeyDown(Keys.F2) && prevKeyboardState.IsKeyUp(Keys.F2))
            {
                MediaPlayer.Volume -= 0.1f;
                songVolume = MediaPlayer.Volume * 100;
            }

            //Skru musikk-volumet opp
            if (currKeyboardState.IsKeyDown(Keys.F3) && prevKeyboardState.IsKeyUp(Keys.F3))
            {
                MediaPlayer.Volume += 0.1f;
                songVolume = MediaPlayer.Volume * 100;
            }

            //Pause/Starte musikk
            if (currKeyboardState.IsKeyDown(Keys.F4) && prevKeyboardState.IsKeyUp(Keys.F4))
                if (mediaState == MediaState.Playing)
                    MediaPlayer.Pause();
                else if (mediaState == MediaState.Paused)
                    MediaPlayer.Resume();
                else if (mediaState == MediaState.Stopped)
                    if (themeAPlaying == true)
                    {
                        MediaPlayer.Play(themeB);
                        themeAPlaying = false;
                    }
                    else if (themeAPlaying == false)
                    {
                        MediaPlayer.Play(themeA);
                        themeAPlaying = true;
                    }

            //Veksle mellom sang A og B
            if (currKeyboardState.IsKeyDown(Keys.F5) && prevKeyboardState.IsKeyUp(Keys.F5))
                if (themeAPlaying == true)
                {
                    MediaPlayer.Play(themeB);
                    themeAPlaying = false;
                }
                else if (themeAPlaying == false)
                {
                    MediaPlayer.Play(themeA);
                    themeAPlaying = true;
                }

            //Stoppe musikken
            if (currKeyboardState.IsKeyDown(Keys.F6) && prevKeyboardState.IsKeyUp(Keys.F6))
            {
                MediaPlayer.Stop();
                themeAPlaying = !themeAPlaying;
            }

            //Mute SFX
            if (currKeyboardState.IsKeyDown(Keys.F7) && prevKeyboardState.IsKeyUp(Keys.F7))
            {
                soundOn = !soundOn;
            }

            mediaState = MediaPlayer.State;
            prevKeyboardState = currKeyboardState;
        }
    }
}
