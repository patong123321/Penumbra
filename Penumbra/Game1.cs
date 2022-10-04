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

        Texture2D locker;
        Vector2 lockerPos = new Vector2(580, 406);
        Texture2D locker2;
        Vector2 lockerPos2 = new Vector2(2147, 406);

        Texture2D buttonE;
        Vector2 buttonEPos = new Vector2(580, 270);

        Texture2D senses;
        Vector2 sensesPos = new Vector2(5, -5);

        Texture2D inventory;
        Vector2 inventoyPos = new Vector2(5, 670);

        Vector2 scroll_factor = new Vector2(1.0f, 1);

        Vector2 cameraPos = Vector2.Zero;

        bool personHit = false;
        bool personHit2 = false;
        bool personHit3 = false;

        bool hide;

        bool walk = true;

        KeyboardState ks;
        KeyboardState oldks;

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

            locker = Content.Load<Texture2D>("locker");
            locker2 = Content.Load<Texture2D>("locker");

            buttonE = Content.Load<Texture2D>("button");

            senses = Content.Load<Texture2D>("senses");

            inventory = Content.Load<Texture2D>("inventory");

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
            if (walk == true)
            {
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
                    //player.Play();
                    direction = 1;
                    playerPos -= new Vector2(5, 0);
                    //flip = true;
                }
            }
            else if (walk == false)
            {

            }


            UpdateFrame2((float)gameTime.ElapsedGameTime.TotalSeconds);
            enemyPos.X = enemyPos.X + (3 * direction2);
            if (enemyPos.X < 150 || enemyPos.X + (enemyPos.X) > 3200)
            {
                direction2 *= -1;
            }

            Rectangle personRectangle = new Rectangle((int)playerPos.X, (int)playerPos.X, 130, 260);
            personHit = false;

            Rectangle enemyRectangle = new Rectangle((int)enemyPos.X, (int)enemyPos.X, 155, 300);
            if (personRectangle.Intersects(enemyRectangle) == true)
            {
                personHit = true;
            }

            personHit2 = false;
            personHit3 = false;
            Rectangle lockerRectangle = new Rectangle((int)lockerPos.X, (int)lockerPos.X, 130, 260);
            Rectangle lockerRectangle2 = new Rectangle((int)lockerPos2.X, (int)lockerPos2.X, 130, 260);

            ks = Keyboard.GetState();
            if (personRectangle.Intersects(lockerRectangle) == true)
            {
                personHit2 = true;
                if (ks.IsKeyDown(Keys.E) && oldks.IsKeyUp(Keys.E))
                {
                    hide = true;
                    walk = false;
                    
                }
                else if (ks.IsKeyDown(Keys.Q) && oldks.IsKeyUp(Keys.Q))
                {
                    hide = false;
                    walk = true;

                }
                oldks = ks;

            }

            if (walk == false)
            {
                personHit = false;
            }

            if (personRectangle.Intersects(lockerRectangle2) == true)
            {
                personHit3 = true;
                if (ks.IsKeyDown(Keys.E) && oldks.IsKeyUp(Keys.E))
                {
                    hide = true;
                    walk = false;

                }
                else if (ks.IsKeyDown(Keys.Q) && oldks.IsKeyDown(Keys.Q))
                {
                    hide = false;
                    walk = true;
                }
                oldks = ks;
            }

            if (personHit2 == true)
            {

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (personHit == true)
            {
                spriteBatch.Draw(bg, (bgPos - cameraPos) * scroll_factor, Color.Red);
                spriteBatch.Draw(bg2, (bgPos2 - cameraPos) * scroll_factor + new Vector2(graphics.GraphicsDevice.Viewport.Width, 0), Color.Red);
            }
            else if (personHit == false)
            {
                spriteBatch.Draw(bg, (bgPos - cameraPos) * scroll_factor, Color.White);
                spriteBatch.Draw(bg2, (bgPos2 - cameraPos) * scroll_factor + new Vector2(graphics.GraphicsDevice.Viewport.Width, 0), Color.White);
            }

            if (personHit2 == true)
            {

                spriteBatch.Draw(buttonE, buttonEPos - cameraPos, Color.White);

            }
            else if (personHit2 == false)
            {

            }


            if (personHit3 == true)
            {

                spriteBatch.Draw(buttonE, new Vector2(2147, 270) - cameraPos, Color.White);

            }
            else if (personHit3 == false)
            {

            }

            spriteBatch.Draw(locker, lockerPos - cameraPos, Color.White);
            spriteBatch.Draw(locker, new Vector2(2147, 406) - cameraPos, Color.White);

            spriteBatch.Draw(senses, sensesPos, Color.White);

            spriteBatch.Draw(inventory, inventoyPos, Color.White);
            spriteBatch.Draw(inventory, new Vector2(135, 670), Color.White);
            spriteBatch.Draw(inventory, new Vector2(265, 670), Color.White);

            if (direction2 == -1)
            {
                spriteBatch.Draw(enemy, enemyPos - cameraPos, new Rectangle(260 * frame2, 0, 260, 390), Color.White);
            }
            else
            {
                spriteBatch.Draw(enemy, enemyPos - cameraPos, new Rectangle(260 * frame2, 390, 260, 390), Color.White);
            }

            if (hide == true)
            {

            }
            else if (hide == false)
            {
                spriteBatch.Draw(player, playerPos - cameraPos, new Rectangle(130 * frames, 260 * direction, 130, 260), Color.White);
            }


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
