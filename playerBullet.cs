using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace CastleOfPain
{
    //class to draw bullets
    class playerBullet : generalGameItem
    {
        //bullet constructor
        public playerBullet(Texture2D aBulletSprite, Rectangle aBulletRect,
            Color aBulletColor) : base(aBulletSprite, aBulletRect, aBulletColor) { }

        //method to move bullet
        public void moveBullet()
        {
            //moves bullet
            rect.Y -= 7;
        }
    }
}
