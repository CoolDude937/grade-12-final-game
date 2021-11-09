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
    class gamePlayer : movingGameItem
    {
        //friction variable
        private float friction;

        //constructor
        public gamePlayer(float aFriction, Texture2D playerSprite, Rectangle playerRect,
            Color playerColor, Vector2 playerOrigin, Vector2 playerPosition,
            float playerRotation, Vector2 playerVelocity) : base(playerSprite, playerRect,
                playerColor, playerOrigin, playerPosition, playerRotation, playerVelocity)
        {

        }

        //getter for friction
        public float getFriction()
        {
            //returns value of friction
            return this.friction;
        }

        //setter for friction
        public void setFriction(float someFriction)
        {
            //
        }
    }
}
