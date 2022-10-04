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

        Texture2D enemy;
        Vector2 enemyPos = new Vector2(1600, 275);

        int direction = 0;
        int frames;
        int totalFrames;
        int framePersec;
        float timePerFrames;
        float totalElapesd;

        int direction2 = 1;
        int frame2;
        float totalElapsed2;
        float timePerFrame2;
        int framePerSec2;

        Texture2D senses;
        Vector2 sensesPos = new Vector2(5, -5);

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

            enemy = Content.Load<Texture2D>("enemy_1");

            senses = Content.Load<Texture2D>("senses");

            frames = 0;
            totalFrames = 8;
            framePersec = 3;
            timePerFrames = (float)1 / framePersec;
            totalElapesd = 0;


            framePerSec2 = 3;
            timePerFrame2 = (float)1 / framePerSec2;
            frame2 = 0;
            totalElapsed2 = 0;

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

            UpdateFrame2((float)gameTime.ElapsedGameTime.TotalSeconds);
            enemyPos.X = enemyPos.X + (3 * direction2);
            if (enemyPos.X < 150 || enemyPos.X + (enemyPos.X) > 3200)
            {
                direction2 *= -1;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(bg, (bgPos - cameraPos) * scroll_factor, Color.White);
            spriteBatch.Draw(bg2, (bgPos2 - cameraPos) * scroll_factor + new Vector2(graphics.GraphicsDevice.Viewport.Width, 0), Color.White);

            if (direction2 == -1)
            {
                spriteBatch.Draw(enemy, enemyPos - cameraPos, new Rectangle(260 * frame2, 0, 260, 390), Color.White);
            }
            else
            {
                spriteBatch.Draw(enemy, enemyPos - cameraPos, new Rectangle(260 * frame2, 390, 260, 390), Color.White);
            }
            spriteBatch.Draw(player, playerPos - cameraPos, new Rectangle(130 * frames, 260 * direction, 130, 260), Color.White);

            spriteBatch.Draw(senses, sensesPos, Color.White);


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

        void UpdateFrame2(float elapsed2)
        {
            totalElapsed2 += elapsed2;
            if (totalElapsed2 > timePerFrame2)
            {
                frame2 = (frame2 + 1) % 5;
                totalElapsed2 -= timePerFrame2;
            }
        }
    }
}
