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
        Game1 game;
        public EndScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {


            this.game = game;
        }
        public override void Update(GameTime gameTime)
        {


            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);

            base.Draw(spriteBatch);
        }
    }
}