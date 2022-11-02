using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penumbra
{
    public class GameOverScreen : screen
    {
        Texture2D GameOver_bg;
        Vector2 GameOver_Pos = new Vector2(250, 0);
        Game1 game;
        public GameOverScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {

            GameOver_bg = game.Content.Load<Texture2D>("GameOver");
            this.game = game;
        }
        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) == true)
            {
                ScreenEvent.Invoke(game.mbedroomScreen, new EventArgs());
                return;
            }

            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Draw(GameOver_bg, GameOver_Pos, Color.White);
            base.Draw(spriteBatch);
        }

    }
}
