using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penumbra
{
    public class screen : Game1
    {

        public Vector2 playerPos(250, 406);
        protected EventHandler ScreenEvent;
        public screen(EventHandler theScreenEvent)
        {
            ScreenEvent = theScreenEvent;
        }
        public virtual void Update(GameTime theTime)
        {

        }
        public virtual void Draw(SpriteBatch thebatch)
        {

        }
    }
}
