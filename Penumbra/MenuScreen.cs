using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penumbra
{
    public class MenuScreen : screen
    {
        Texture2D menuTexture;
        Vector2 menuPos = new Vector2(250,0);
        Texture2D start;
        Vector2 startPos = new Vector2(850, 400);
        SpriteFont font;
        KeyboardState ks;
        KeyboardState oldks;

        Game1 game;
        public MenuScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {

            menuTexture = game.Content.Load<Texture2D>("menu");
            start = game.Content.Load<Texture2D>("start");
            font = game.Content.Load<SpriteFont>("spacebar");


            this.game = game;
        }
        public override void Update(GameTime gameTime)
        {
            ks = Keyboard.GetState();
            if (ks.IsKeyUp(Keys.Space) && oldks.IsKeyDown(Keys.Space))
            {
                ScreenEvent.Invoke(game.mRuleScreen, new EventArgs());
                return;
            }
            oldks = ks;

            
            if (Keyboard.GetState().IsKeyDown(Keys.P) == true)
            {
                ScreenEvent.Invoke(game.mfloor2Screen, new EventArgs());
                return;
            }
            oldks = Keyboard.GetState();
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Draw(menuTexture, menuPos, Color.White);
            //spriteBatch.Draw(start, startPos, Color.White);
            string str;
            str = "Press spacebar";
            spriteBatch.DrawString(font, str, new Vector2(800, 660), new Color(172, 4, 4));
            base.Draw(spriteBatch);
        }
    }
}
