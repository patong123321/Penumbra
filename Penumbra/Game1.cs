using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Penumbra
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        Texture2D bg;
        Vector2 bgPos = new Vector2(0, 0);
        Texture2D bg2;
        Vector2 bgPos2 = new Vector2(0, 0);

        Vector2 scroll_factor = new Vector2(1.0f, 1);

        Vector2 cameraPos = Vector2.Zero;

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


            bg = Content.Load<Texture2D>("background_1");
            bg2 = Content.Load<Texture2D>("background_2");


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(bg, (bgPos - cameraPos) * scroll_factor, Color.White);
            spriteBatch.Draw(bg2, (bgPos2 - cameraPos) * scroll_factor + new Vector2(graphics.GraphicsDevice.Viewport.Width, 0), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
