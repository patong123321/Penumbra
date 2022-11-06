using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penumbra
{
    public class EndScreen : screen
    {
        SpriteFont font;
        SpriteFont font2;
        SpriteFont font3;
        KeyboardState ks;
        KeyboardState oldks;
        Game1 game;
        public EndScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            font = game.Content.Load<SpriteFont>("Rule");
            font2 = game.Content.Load<SpriteFont>("Rule");
            font3 = game.Content.Load<SpriteFont>("spacebar");

            this.game = game;
        }
        public override void Update(GameTime gameTime)
        {
            ks = Keyboard.GetState();
            if (ks.IsKeyUp(Keys.Space) && oldks.IsKeyDown(Keys.Space))
            {
                ScreenEvent.Invoke(game.mMenuScreen, new EventArgs());
                return;
            }
            oldks = ks;

            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            string str;
            str = "Finally you found a Exit";
            spriteBatch.DrawString(font, str, new Vector2(380, 130), new Color(172, 4, 4));
            string str2;
            str2 = "But don't forget, you're just a Penumbra";
            spriteBatch.DrawString(font2, str2, new Vector2(120, 300), new Color(172, 4, 4));
            string str3;
            str3 = "RIP";
            spriteBatch.DrawString(font3, str3, new Vector2(1400, 660), new Color(172, 4, 4));

            base.Draw(spriteBatch);
        }
    }
}