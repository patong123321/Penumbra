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

        Texture2D player;
        Vector2 playerPos = new Vector2(0, 406);

        int direction = 0;
        int frames;
        int totalFrames;
        int framePersec;
        float timePerFrames;
        float totalElapesd;

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

            player = Content.Load<Texture2D>("player");

            frames = 0;
            totalFrames = 8;
            framePersec = 3;
            timePerFrames = (float)1 / framePersec;
            totalElapesd = 0;


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState keyboard = Keyboard.GetState();
            if (Keyboard.GetState().IsKeyDown(Keys.D) && playerPos.X < graphics.GraphicsDevice.Viewport.Width * 2 - 130)
            {
                if (playerPos.X - cameraPos.X >= 400 && cameraPos.X < graphics.GraphicsDevice.Viewport.Width)
                {
                    cameraPos += new Vector2(5, 0);
                }
                UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);

                direction = 0;
                playerPos += new Vector2(5, 0);

            }

            else if (Keyboard.GetState().IsKeyDown(Keys.A) && playerPos.X > 0)
            {
                if (playerPos.X - cameraPos.X <= 300 && cameraPos.X > 0)
                {
                    cameraPos -= new Vector2(5, 0);
                }
                UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                direction = 1;
                playerPos -= new Vector2(5, 0);
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(bg, (bgPos - cameraPos) * scroll_factor, Color.White);
            spriteBatch.Draw(bg2, (bgPos2 - cameraPos) * scroll_factor + new Vector2(graphics.GraphicsDevice.Viewport.Width, 0), Color.White);
            spriteBatch.Draw(player, playerPos - cameraPos, new Rectangle(130 * frames, 260 * direction, 130, 260), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        void UpdateFrame(float elapsed)
        {
            totalElapesd += elapsed;
            if (totalElapesd > timePerFrames)
            {
                frames = (frames + 1) % totalFrames;
                totalElapesd -= timePerFrames;
            }
        }
    }
}
