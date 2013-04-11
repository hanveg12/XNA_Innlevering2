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
    public class Animation
    {
        private int _frameHeight;
        private int _frameWidth;

        private int totalFrames;
        private int currentFrame = 0;

        private float _frameTime;
        private float _timer;
        private bool isRunning;

        private bool runningBackwards = false;

        private Rectangle _clipRect;

        private Texture2D _graphic;

        public Animation(Texture2D spriteSheet, int frameHeight, int frameWidth, float frameTime, int totalFrames, bool runBackwards)
        {
            _frameHeight = frameHeight;
            _frameWidth = frameWidth;
            _frameTime = frameTime;
            this.totalFrames = totalFrames;

            runningBackwards = runBackwards;

            //Start animasjonen bakfra
            if (runBackwards) currentFrame = totalFrames - 1;

            _graphic = spriteSheet;

            _clipRect = new Rectangle(0, 0, _frameHeight, _frameWidth);
        }

        public Rectangle Clip
        {
            get
            {
                return _clipRect;
            }
        }

        public Texture2D Graphic
        {
            get
            {
                return _graphic;
            }
        }

        public bool IsRunning
        {
            get
            {
                return isRunning;
            }

            set
            {
                isRunning = value;
            }
        }

        public void Update(GameTime gt)
        {
            _timer += gt.ElapsedGameTime.Milliseconds;

            if (isRunning)
            {
                if (_timer > _frameTime)
                {
                    _timer -= _frameTime;

                    if (!runningBackwards)
                    {
                        currentFrame++;
                        if (currentFrame >= totalFrames)
                        {
                            currentFrame = 0;
                        }
                    }

                    else
                    {
                        currentFrame--;
                        if (currentFrame < 0)
                        {
                            currentFrame = totalFrames - 1;
                        }
                    }
                }
            }

            _clipRect = new Rectangle(currentFrame * _frameWidth, 0, _frameWidth, _frameHeight);
        }
    }
}
