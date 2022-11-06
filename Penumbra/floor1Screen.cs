using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Penumbra;

namespace Penumbra
{
    public class floor1Screen : screen
    {
        //bg
        Texture2D floor1_bg;
        Vector2 floor1_bgPos = new Vector2(0, 0);
        Texture2D floor1_bg2;
        Vector2 floor1_bgPos2 = new Vector2(0, 0);

        //player
        Texture2D player;
        Vector2 playerPos = new Vector2(250, 406);
        int direction = 0;
        int frame;
        int totalFrame;
        int framePersec;
        float timePerFrame;
        float totalElapsed;
        float elapsed;

        //enemy
        Texture2D enemy;
        Vector2 enemyPos = new Vector2(0, 275);

        Texture2D enemy2;
        Vector2 enemyPos2 = new Vector2(0, 406);

        int direction2 = 1;
        int frame2;
        float totalElapsed2;
        float timePerFrame2;
        int framePerSec2;
        float elapsed2;

        //locker
        Texture2D locker;
        Vector2 lockerPos = new Vector2(580, 406);
        Texture2D locker2;
        Vector2 lockerPos2 = new Vector2(2147, 406);

        //button
        Texture2D buttonE;
        Vector2 buttonEPos = new Vector2(580, 270);
        Texture2D buttonQ;
        Vector2 buttonQPos = new Vector2(580, 270);

        //senses
        Texture2D senses;
        Vector2 sensesPos = new Vector2(5, -5);

        //inventory
        Texture2D inventory;
        Vector2 inventoyPos = new Vector2(5, 670);

        //lift
        Texture2D lift;
        Vector2 lift_Pos = new Vector2(280, 276);

        Texture2D lift2;
        Vector2 lift_Pos2 = new Vector2(2840, 276);

        //camera
        Vector2 scroll_factor = new Vector2(1.0f, 1);
        Vector2 cameraPos = Vector2.Zero;

        

        bool personHit = false;
        bool personHit2 = false;
        bool personHit3 = false;

        bool liftHit = false;

        bool liftHit2 = false;

        bool hide;

        bool walk = true;

        KeyboardState ks;
        KeyboardState oldks;

        Texture2D barTexture;
        int currentHeart;


        Game1 game;
        public floor1Screen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            floor1_bg = game.Content.Load<Texture2D>("floor1_bg_1");
            floor1_bg2 = game.Content.Load<Texture2D>("floor1_bg_2");

            player = game.Content.Load<Texture2D>("player_walk");

            enemy = game.Content.Load<Texture2D>("enemy_1");
            enemy2 = game.Content.Load<Texture2D>("enemy_2");


            locker = game.Content.Load<Texture2D>("locker");
            locker2 = game.Content.Load<Texture2D>("locker");

            buttonE = game.Content.Load<Texture2D>("button");
            buttonQ = game.Content.Load<Texture2D>("Q");

            senses = game.Content.Load<Texture2D>("senses");

            inventory = game.Content.Load<Texture2D>("inventory");

            lift = game.Content.Load<Texture2D>("lift");
            lift2 = game.Content.Load<Texture2D>("Exit");

            frame = 0;
            totalFrame = 8;
            framePersec = 3;
            timePerFrame = (float)1 / framePersec;
            totalElapsed = 0;


            framePerSec2 = 3;
            timePerFrame2 = (float)1 / framePerSec2;
            frame2 = 0;
            totalElapsed2 = 0;

            barTexture = game.Content.Load<Texture2D>("UI_HP");
            currentHeart = barTexture.Width - 5;
            this.game = game;
        }
        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.M) == true)
            {
                ScreenEvent.Invoke(game.mMenuScreen, new EventArgs());
                return;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D2) == true)
            {
                ScreenEvent.Invoke(game.mfloor2Screen, new EventArgs());
                return;
            }
            KeyboardState keyboard = Keyboard.GetState();
            if (walk == true)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.D) && playerPos.X < game.GraphicsDevice.Viewport.Width * 2 - 130)
                {
                    if (playerPos.X - cameraPos.X >= 400 && cameraPos.X < game.GraphicsDevice.Viewport.Width)
                    {
                        cameraPos += new Vector2(4, 0);
                    }
                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);

                    direction = 0;
                    playerPos += new Vector2(4, 0);
                }
                else if (Keyboard.GetState().IsKeyUp(Keys.D) && oldks.IsKeyDown(Keys.D) && playerPos.X < game.GraphicsDevice.Viewport.Width * 2 - 130)
                {

                    frame = 0;
                    totalElapsed = 0;
                }


                if (Keyboard.GetState().IsKeyDown(Keys.A) && playerPos.X > 0)
                {
                    if (playerPos.X - cameraPos.X <= 300 && cameraPos.X > 0)
                    {
                        cameraPos -= new Vector2(4, 0);
                    }
                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);

                    direction = 1;
                    playerPos -= new Vector2(4, 0);

                }

                if (Keyboard.GetState().IsKeyUp(Keys.A) && oldks.IsKeyDown(Keys.A) && playerPos.X > 0)
                {
                    frame = 7;
                    totalElapsed = 0;

                }
                oldks = ks;
            }
            else if (walk == false)
            {

            }
            /*d
            UpdateFrame2((float)gameTime.ElapsedGameTime.TotalSeconds);
            enemyPos.X = enemyPos.X + (3 * direction2);
            if (enemyPos.X < 150 || enemyPos.X + (enemyPos.X) > 3200)
            {
                direction2 *= -1;
            }*/

            
            if (playerPos.X > 300)
            {
                UpdateFrame2((float)gameTime.ElapsedGameTime.TotalSeconds);
                enemyPos2.X = enemyPos2.X + (4.3f * direction2);
                if (enemyPos2.X <= 0 || enemyPos2.X + (enemyPos2.X) > 6200)
                {
                    direction2 *= -1;
                }
            }


            Rectangle personRectangle = new Rectangle((int)playerPos.X, (int)playerPos.X, 130, 260);
            personHit = false;

            Rectangle enemyRectangle = new Rectangle((int)enemyPos2.X, (int)enemyPos2.X, 130, 260);
            if (personRectangle.Intersects(enemyRectangle) == true)
            {
                personHit = true;
            }

            personHit2 = false;
            personHit3 = false;
            Rectangle lockerRectangle = new Rectangle((int)lockerPos.X, (int)lockerPos.X, 130, 260);
            Rectangle lockerRectangle2 = new Rectangle((int)lockerPos2.X, (int)lockerPos2.X, 130, 260);

            liftHit = false;
            Rectangle liftRectangle = new Rectangle((int)lift_Pos2.X, (int)lift_Pos2.X, 390, 390);


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


            if (personHit == true)
            {

                if (currentHeart > 0)
                {
                    currentHeart = currentHeart - 20 % barTexture.Width;
                }
            }
            if (currentHeart <= 0)
            {
                ScreenEvent.Invoke(game.mGameOverScreen, new EventArgs());
                playerPos = new Vector2(250, 406);
                cameraPos = Vector2.Zero;
                currentHeart = barTexture.Width - 5;
                enemyPos2 = new Vector2(0, 406);
                return;
            }

            if (personRectangle.Intersects(liftRectangle) == true)
            {
                ks = Keyboard.GetState();
                liftHit = true;
                if (ks.IsKeyUp(Keys.E) && oldks.IsKeyDown(Keys.E))
                {
                    ScreenEvent.Invoke(game.mEndScreen, new EventArgs());
                    playerPos = new Vector2(250, 406);
                    cameraPos = Vector2.Zero;
                    currentHeart = barTexture.Width - 5;
                    enemyPos2 = new Vector2(0, 406);

                }
                oldks = ks;
            }

                base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (personHit == true)
            {
                spriteBatch.Draw(floor1_bg, (floor1_bgPos - cameraPos) * scroll_factor, Color.Red);
                spriteBatch.Draw(floor1_bg2, (floor1_bgPos2 - cameraPos) * scroll_factor + new Vector2(game.GraphicsDevice.Viewport.Width, 0), Color.Red);
            }
            else if (personHit == false)
            {
                spriteBatch.Draw(floor1_bg, (floor1_bgPos - cameraPos) * scroll_factor, Color.White);
                spriteBatch.Draw(floor1_bg2, (floor1_bgPos2 - cameraPos) * scroll_factor + new Vector2(game.GraphicsDevice.Viewport.Width, 0), Color.White);
            }

            
            spriteBatch.Draw(lift2, lift_Pos2 - cameraPos, Color.White);
            spriteBatch.Draw(lift, lift_Pos - cameraPos, Color.White);
            /*if (personHit2 == true)
            {

                spriteBatch.Draw(buttonE, buttonEPos - cameraPos, Color.White);

            }*/

            if (personHit3 == true)
            {
                if (hide == false)
                {
                    spriteBatch.Draw(buttonE, new Vector2(2147, 270) - cameraPos, Color.White);
                }
                else
                {
                    spriteBatch.Draw(buttonQ, new Vector2(2147, 270) - cameraPos, Color.White);
                }
                

            }

            if (liftHit == true)
            {

                spriteBatch.Draw(buttonE, buttonEPos = new Vector2(2970, 150) - cameraPos, Color.White);

            }


            //  spriteBatch.Draw(locker, lockerPos - cameraPos, Color.White);
            spriteBatch.Draw(locker, new Vector2(2147, 418) - cameraPos, Color.White);

           // spriteBatch.Draw(senses, sensesPos, Color.White);

            //spriteBatch.Draw(inventory, inventoyPos, Color.White);
           // spriteBatch.Draw(inventory, new Vector2(135, 670), Color.White);
           // spriteBatch.Draw(inventory, new Vector2(265, 670), Color.White);


            /*if (direction2 == -1)
            {
                spriteBatch.Draw(enemy, enemyPos - cameraPos, new Rectangle(260 * frame2, 0, 260, 390), Color.White);
            }
            else
            {
                spriteBatch.Draw(enemy, enemyPos - cameraPos, new Rectangle(260 * frame2, 390, 260, 390), Color.White);
            }
            */

            

            if (direction2 == -1)
            {
                    spriteBatch.Draw(enemy2, enemyPos2 - cameraPos, new Rectangle(130 * frame2, 0, 130, 260), Color.White);
            }
            else
            {
                    spriteBatch.Draw(enemy2, enemyPos2 - cameraPos, new Rectangle(130 * frame2, 260, 130, 260), Color.White);
            }

            if (hide == true)
            {

            }
            else if (hide == false)
            {
                spriteBatch.Draw(player, playerPos - cameraPos, new Rectangle(130 * frame, 260 * direction, 130, 260), Color.White);
            }

            spriteBatch.Draw(barTexture, new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - barTexture.Width / 2, 30, barTexture.Width, 44), new Rectangle(0, 0, barTexture.Width - 4, 59), Color.White);
            spriteBatch.Draw(barTexture, new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - barTexture.Width / 2, 30, currentHeart, 42), new Rectangle(0, 58, barTexture.Width - 10, 60), Color.Green);

            base.Draw(spriteBatch);
        }

        void UpdateFrame(float elapsed)
        {
            totalElapsed += elapsed;
            if (totalElapsed > timePerFrame)
            {
                frame = (frame + 1) % totalFrame;
                totalElapsed -= timePerFrame;
            }
        }
        void UpdateFrame2(float elapsed2)
        {
            totalElapsed2 += elapsed2;
            if (totalElapsed2 > timePerFrame2)
            {
                frame2 = (frame2 + 1) % 8;
                totalElapsed2 -= timePerFrame2;
            }
        }
    }
}
