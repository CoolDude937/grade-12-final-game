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
    //subclass of moving game item
    class gamePlayer : generalGameItem
    {
        //constructor
        public gamePlayer(Rectangle aPlayerRect, Texture2D aPlayerImage, Color aPlayerColor) 
            : base(aPlayerImage, aPlayerRect, aPlayerColor)
        {}

        //move method
        public void movePlayer()
        {
            //if the right arrow key is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                //move the game item right
                rect.X+=2;
            }

            //if the left arrow key is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                //move the game item left
                rect.X-=2;
            }
        }

        //method to keep player rectangle within bounds
        public void outOfBounds()
        {
            //if the player rectangle is trying to go left off screen
            if (rect.X <= 0)
                //keep it within bounds
                rect.X = 0;
            //if the player rectangle is trying to go right off screen
            if (rect.X >= 800-rect.Width)
                //keep it within bounds
                rect.X = 800-rect.Width;
            //if the player rectangle is trying to go up off screen
            if (rect.Y <= 0)
                //keep it within bounds
                rect.Y = 0;
            //if the player rectangle is trying to go down off screen
            if (rect.Y >= 480-rect.Height)
                //keep it within bounds
                rect.Y = 480-rect.Height;
        }
    }
}

//code graveyard
/*
            //if the up arrow key is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                //move the game item up
                rect.Y-=3;
            }

            //if the down arrow key is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                //move the game item down
                rect.Y+=3;
            }
            */
