using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penumbra
{
    public class RuleScreen : screen
    {
        SpriteFont font;
        SpriteFont font2;
        SpriteFont font3;

        Game1 game;
        public RuleScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            font = game.Content.Load<SpriteFont>("Rule");
            font2 = game.Content.Load<SpriteFont>("Rule2");
            font3 = game.Content.Load<SpriteFont>("spacebar");
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
            
            string str;
            str = "A  D Walk     Q E Hide";
            spriteBatch.DrawString(font, str, new Vector2(430, 150), new Color(172, 4, 4));
            string str2;
            str2 = "Find a way out  find a way to survive.";
            spriteBatch.DrawString(font2, str2, new Vector2(150, 300), new Color(172, 4, 4));

            string str3;
            str3 = "Press spacebar";
            spriteBatch.DrawString(font, str3, new Vector2(1000, 660), new Color(172, 4, 4));
            base.Draw(spriteBatch);
        }
    }
}
