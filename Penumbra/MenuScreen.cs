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
        Game1 game;
        public MenuScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {

            menuTexture = game.Content.Load<Texture2D>("menu");
            start = game.Content.Load<Texture2D>("start");
            
            this.game = game;
        }
        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) == true)
            {
                ScreenEvent.Invoke(game.mbedroomScreen, new EventArgs());
                return;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.P) == true)
            {
                ScreenEvent.Invoke(game.mfloor2Screen, new EventArgs());
                return;
            }

            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Draw(menuTexture, menuPos, Color.White);
            spriteBatch.Draw(start, startPos, Color.White);
            base.Draw(spriteBatch);
        }
    }
}
