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
        SpriteFont font;
        SpriteFont font2;
        Game1 game;
        public GameOverScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {

            GameOver_bg = game.Content.Load<Texture2D>("GameOver");
            font = game.Content.Load<SpriteFont>("Over");
            font2 = game.Content.Load<SpriteFont>("spacebar");
            this.game = game;
        }
        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) == true)
            {
                ScreenEvent.Invoke(game.mbedroomScreen, new EventArgs());
                playerPos = new Vector2(250, 406);
                return;
            }

            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Draw(GameOver_bg, GameOver_Pos, Color.White);
            string str;
            str = "GAMEOVER";
            spriteBatch.DrawString(font, str, new Vector2(530, 150), new Color(172, 4, 4));
            string str2;
            str2 = "Press spacebar";
            spriteBatch.DrawString(font2, str2, new Vector2(800, 660), new Color(172, 4, 4));
            base.Draw(spriteBatch);
        }

    }
}
