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
    //superclass
    class generalGameItem
    {
        //superclass variables
        private Texture2D sprite;
        private Rectangle rect;
        private Color color;

        //constructor
        public generalGameItem(Texture2D aSprite, Rectangle aRect, Color aColor)
        {
            //constructs these 3 variables for use
            this.setSprite(aSprite);
            this.setRect(aRect);
            this.setColor(aColor);
        }

        //getter for the sprite
        public Texture2D getSprite()
        {
            //returns value of the sprite in this class
            return this.sprite;
        }

        //setter for the sprite
        public void setSprite(Texture2D someSprite)
        {
            //assigns the value of the sprite to whatever the user assigns the sprite as
            this.sprite = someSprite;
        }

        //getter for the rectangle
        public Rectangle getRect()
        {
            //returns value of the rectangle in this class
            return this.rect;
        }

        //setter for the rectangle
        public void setRect(Rectangle someRect)
        {
            //assigns the value of the rectangle to whatever the user assigns the rectangle as
            this.rect = someRect;
        }

        //getter for the color
        public Color getColor()
        {
            //returns value of the color in this class
            return this.color;
        }

        //setter for the color
        public void setColor(Color someColor)
        {
            //assigns the value of the color to whatever the user assigns the color as
            this.color = someColor;
        }

        //universal draw method
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //draws a general game item
            spriteBatch.Draw(sprite, rect, color);
        }

        //universal hit test
        public virtual bool hitTest(Rectangle otherRect)
        {
            //if this rectangle intersects with the other rectangle
            if (this.rect.Intersects(otherRect))
            {
                //return true for the hittest
                return true;
            }
            //else it did not intersect it
            else
            {
                //return false for the hittest
                return false;
            }
        }
    }
}
