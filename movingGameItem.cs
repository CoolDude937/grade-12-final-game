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
    //class for moving game items
    class movingGameItem : generalGameItem
    {
        //variables for sprite placement
        private Vector2 spriteOrigin;

        //variables for sprite position and rotation
        private Vector2 spritePosition;
        private float rotation;

        //variables for controlling sprite speed
        private Vector2 spriteVelocity;

        //variable for distance
        private Vector2 distance;

        //constructor
        public movingGameItem(Texture2D movingSprite, Rectangle movingRect,
            Color movingColor, Vector2 aSpriteOrigin, Vector2 aSpritePosition,
            float aRotation, Vector2 aSpriteVelocity, Vector2 aDistance)
            : base(movingSprite, movingRect, movingColor)
        {
            //sets the value to be entered by user into these variables
            this.setSpriteOrigin(aSpriteOrigin);
            this.setSpritePosition(aSpritePosition);
            this.setRotation(aRotation);
            this.setSpriteVelocity(aSpriteVelocity);
            this.setDistance(aDistance);
        }

        //getter for sprite origin
        public Vector2 getSpriteOrigin()
        {
            //returns value of sprite origin
            return spriteOrigin;
        }

        //setter for sprite origin
        public void setSpriteOrigin(Vector2 someSpriteOrigin)
        {
            //sets the value of this sprite origin as whatever the user will set it as
            this.spriteOrigin = someSpriteOrigin;
        }

        //getter for sprite position
        public Vector2 getSpritePosition()
        {
            //returns value of sprite position
            return spritePosition;
        }

        //setter for sprite position
        public void setSpritePosition(Vector2 someSpritePosition)
        {
            //sets the value of this sprite position as whatever the user will set it as
            this.spritePosition = someSpritePosition;
        }

        //getter for rotation
        public float getRotation()
        {
            //returns value of rotation 
            return rotation;
        }

        //setter for rotation
        public void setRotation(float someRotation)
        {
            //sets the value of this rotation as whatever the user will set it as
            this.rotation = someRotation;
        }

        //getter for sprite velocity
        public Vector2 getSpriteVelocity()
        {
            //returns value of sprite velocity
            return spriteVelocity;
        }

        //setter for sprite velocity
        public void setSpriteVelocity(Vector2 someSpriteVelocity)
        {
            //sets the value of this sprite velocity as whatever the user will set it as
            this.spriteVelocity = someSpriteVelocity;
        }

        //getter for sprite distance 
        public Vector2 getDistance()
        {
            //returns value of distance
            return distance;
        }

        //setter for sprite distance
        public void setDistance(Vector2 someDistance)
        {
            //sets the value of this distance as whatever the user will set it as
            this.distance = someDistance;
        }
    }
}
