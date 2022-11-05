using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Penumbra;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Penumbra
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        public bedroomScreen mbedroomScreen;

        public floor3Screen mfloor3Screen;

        public floor2Screen mfloor2Screen;

        public floor1Screen mfloor1Screen;

        public MenuScreen mMenuScreen;

        public GameOverScreen mGameOverScreen;

        public screen mCurrentScreen;

        PenumbraComponent penumbra;
        Light light = new PointLight
        {
            Scale = new Vector2(1500f),
            ShadowType = ShadowType.Illuminated

        };


        Hull hull = new Hull(new Vector2(1.0f), new Vector2(-1.0f, 1.0f), new Vector2(-1.0f), new Vector2(-1.0f, 1.0f))
        {
            Position = new Vector2(400f, 240f),
            Scale = new Vector2(50f)
            
        };

        Song song;
        bool isPlaySong = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges();

            penumbra = new PenumbraComponent(this);
            penumbra.Lights.Add(light);

            if (mCurrentScreen == mfloor3Screen)
            {
                this.song = Content.Load<Song>("floor3sound");
                MediaPlayer.Play(song);
                MediaPlayer.IsRepeating = true;
                MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
            }
            

        }

        protected override void Initialize()
        {
            penumbra.Initialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mfloor3Screen = new floor3Screen(this, new EventHandler(GameplayScreenEvent));
            mfloor2Screen = new floor2Screen(this, new EventHandler(Gameplay2ScreenEvent));
            mfloor1Screen = new floor1Screen(this, new EventHandler(Gameplay3ScreenEvent));
            mbedroomScreen = new bedroomScreen(this, new EventHandler(BedScreenEvent));
            mMenuScreen = new MenuScreen(this, new EventHandler(MenuScreenEvent));
            mGameOverScreen = new GameOverScreen(this, new EventHandler(OverScreenEvent));
            mCurrentScreen = mMenuScreen;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            mCurrentScreen.Update(gameTime);

            
            if (mCurrentScreen == mMenuScreen)
            {
                light.Position = new Vector2(800, 400);
                //light.Color = new Color(96, 96, 96);
                hull.Rotation = MathHelper.WrapAngle(-(float)gameTime.TotalGameTime.TotalSeconds);
            }
            if (mCurrentScreen == mfloor3Screen)
            {
                light.Position = new Vector2(800, 400);
                //light.Color = new Color(204, 0, 0);
                hull.Rotation = MathHelper.WrapAngle(-(float)gameTime.TotalGameTime.TotalSeconds);
            }
            if (mCurrentScreen == mfloor2Screen)
            {
                light.Position = new Vector2(800, 400);
                //light.Color = new Color(204, 0, 0);
                hull.Rotation = MathHelper.WrapAngle(-(float)gameTime.TotalGameTime.TotalSeconds);
            }
            
           /* if (mCurrentScreen == mfloor1Screen)
            {
                light.Position = new Vector2(800, 400);
                //light.Color = new Color(204, 0, 0);
                hull.Rotation = MathHelper.WrapAngle(-(float)gameTime.TotalGameTime.TotalSeconds);

            }*/
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);
            spriteBatch.Begin();
            mCurrentScreen.Draw(spriteBatch);
            spriteBatch.End();

            if (mCurrentScreen == mbedroomScreen)
            {
                penumbra.BeginDraw();
                GraphicsDevice.Clear(Color.Red);
                spriteBatch.Begin();
                mCurrentScreen.Draw(spriteBatch);
                spriteBatch.End();
                penumbra.Draw(gameTime);
            }

            if (mCurrentScreen == mfloor3Screen)
            {
                penumbra.BeginDraw();
                GraphicsDevice.Clear(Color.Red);
                spriteBatch.Begin();
                mCurrentScreen.Draw(spriteBatch);
                spriteBatch.End();
                penumbra.Draw(gameTime);
            }

            if (mCurrentScreen == mfloor2Screen)
            {
                penumbra.BeginDraw();
                GraphicsDevice.Clear(Color.Red);
                spriteBatch.Begin();
                mCurrentScreen.Draw(spriteBatch);
                spriteBatch.End();
                penumbra.Draw(gameTime);
            }
            if (mCurrentScreen == mfloor1Screen)
            {
                penumbra.BeginDraw();
                GraphicsDevice.Clear(Color.Red);
                spriteBatch.Begin();
                mCurrentScreen.Draw(spriteBatch);
                spriteBatch.End();
                penumbra.Draw(gameTime);
            }

            base.Draw(gameTime);
        }
        public void GameplayScreenEvent(object obj, EventArgs e)
        {
            mCurrentScreen = (screen)obj;
        }
        public void Gameplay2ScreenEvent(object obj, EventArgs e)
        {
            mCurrentScreen = (screen)obj;
           
        }
        public void Gameplay3ScreenEvent(object obj, EventArgs e)
        {
            mCurrentScreen = (screen)obj;
        }
        public void MenuScreenEvent(object obj, EventArgs e)
        {
            mCurrentScreen = (screen)obj;
        }
        public void BedScreenEvent(object obj, EventArgs e)
        {
            mCurrentScreen = (screen)obj;
        }
        public void OverScreenEvent(object obj, EventArgs e)
        {
            mCurrentScreen = (screen)obj;
        }

        void MediaPlayer_MediaStateChanged(object sender, System.EventArgs e)
        {
            //0.0f is silent, 1.0f is full volume
            MediaPlayer.Volume -= 0.1f;
            //MediaPlayer.Play(song);
        }

    }
}
