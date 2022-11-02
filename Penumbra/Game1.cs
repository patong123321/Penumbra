using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

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

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mfloor3Screen = new floor3Screen(this, new EventHandler(GameplayScreenEvent));
            mfloor2Screen = new floor2Screen(this, new EventHandler(GameplayScreenEvent));
            mfloor1Screen = new floor1Screen(this, new EventHandler(GameplayScreenEvent));
            mbedroomScreen = new bedroomScreen(this, new EventHandler(GameplayScreenEvent));
            mMenuScreen = new MenuScreen(this, new EventHandler(GameplayScreenEvent));
            mGameOverScreen = new GameOverScreen(this, new EventHandler(GameplayScreenEvent));
            mCurrentScreen = mMenuScreen;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            mCurrentScreen.Update(gameTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            mCurrentScreen.Draw(spriteBatch);
            spriteBatch.End();



            base.Draw(gameTime);
        }
        public void GameplayScreenEvent(object obj, EventArgs e)
        {
            mCurrentScreen = (screen)obj;
        }

    }
}
