﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penumbra
{
    public class bedroomScreen : screen
    {
        //bg
        Texture2D bedroom_bg;
        Vector2 bedroom_bgPos = new Vector2(250,0);

        //door
        Texture2D door;
        Vector2 door_Pos = new Vector2(1025,365);

        //player
        Texture2D player;
        public Vector2 playerPos = new Vector2(250, 406);
        int direction = 0;
        int frame;
        int totalFrame;
        int framePersec;
        float timePerFrame;
        float totalElapsed;
        float elapsed;

        //button
        Texture2D button;
        Vector2 button_Pos = new Vector2(1025,200);


        KeyboardState ks;
        KeyboardState oldks;

        bool doorHit = false;
        bool walk = true;

        SpriteFont font;


        Game1 game;
        public bedroomScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            bedroom_bg = game.Content.Load<Texture2D>("Bedroom");
            door = game.Content.Load<Texture2D>("door");
            button = game.Content.Load<Texture2D>("button");

            player = game.Content.Load<Texture2D>("player_walk");

            frame = 0;
            totalFrame = 8;
            framePersec = 3;
            timePerFrame = (float)1 / framePersec;
            totalElapsed = 0;

            font = game.Content.Load<SpriteFont>("Rule");

            this.game = game;
        }
        public override void Update(GameTime gameTime)
        {
            
            if (Keyboard.GetState().IsKeyDown(Keys.M) == true)
            {
                ScreenEvent.Invoke(game.mMenuScreen, new EventArgs());
                return;
            }

            KeyboardState keyboard = Keyboard.GetState();
            if (walk == true)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.D) && playerPos.X < 1195)
                {
                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);

                    direction = 0;
                    playerPos += new Vector2(4, 0);
                }
                else if (Keyboard.GetState().IsKeyUp(Keys.D) && oldks.IsKeyDown(Keys.D) && playerPos.X < 1195)
                {
                    frame = 0;
                    totalElapsed = 0;
                }
                
                if (Keyboard.GetState().IsKeyDown(Keys.A) && playerPos.X > 0)
                {
                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                    direction = 1;
                    playerPos -= new Vector2(4, 0);
                }
                else if (Keyboard.GetState().IsKeyUp(Keys.A) && oldks.IsKeyDown(Keys.A) && playerPos.X > 0)
                {
                    frame = 7;
                    totalElapsed = 0;
                }
                oldks = ks;

            }
            else if (walk == false)
            {

            }

            doorHit = false;
            Rectangle personRectangle = new Rectangle((int)playerPos.X, (int)playerPos.X, 130, 260);
            Rectangle doorRectangle = new Rectangle((int)door_Pos.X, (int)door_Pos.X, 130, 325);
            
            if (personRectangle.Intersects(doorRectangle) == true)
            {
                doorHit = true;
            }

            if(doorHit == true)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.E) == true)
                {
                    ScreenEvent.Invoke(game.mfloor3Screen, new EventArgs());
                    return;
                }
            }
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);

            
            spriteBatch.Draw(bedroom_bg, bedroom_bgPos, Color.White);
            spriteBatch.Draw(door, door_Pos, Color.White);
            string str;
            str = "A and D to walk";
            if (playerPos.X <= 600)
            {
                spriteBatch.DrawString(font, str, new Vector2(300, 150), new Color(172, 4, 4));
            }
            else
            {

            }
            
            if (doorHit == true)
            {
                spriteBatch.Draw(button, button_Pos, Color.White);
            }
            else
            {

            }
            spriteBatch.Draw(player, playerPos, new Rectangle(130 * frame, 260 * direction, 130, 260), Color.White);
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
    }
}
