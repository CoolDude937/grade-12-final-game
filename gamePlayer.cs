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
        //variables for sprite placement
        private Vector2 playerOrigin;

        //variables for sprite position and rotation
        private Vector2 playerPosition;
        private float playerRotation;

        //variables for controlling sprite speed
        private Vector2 playerVelocity;

        //variable for distance
        private Vector2 playerDistance;

        //friction variable
        private float playerFriction;

        //player rectangle
        private Rectangle playerRect;

        //player image
        private Texture2D playerSprite;

        bool isMouseVisible;
        //constructor
        public gamePlayer(float aPlayerFriction, Texture2D aPlayerSprite, Rectangle aPlayerRect,
            Color playerColor, Vector2 playerOrigin, Vector2 playerPosition,
            float playerRotation, Vector2 playerVelocity, Vector2 playerDistance) : base(aPlayerSprite, aPlayerRect,
                playerColor, playerOrigin, playerPosition, playerRotation, playerVelocity, playerDistance)
        {
            //sets the value of this friction
            this.setFriction(aPlayerFriction);

            isMouseVisible = true;
            this.playerFriction = 0.1f;
        }

        //getter for friction
        public float getFriction()
        {
            //returns value of friction
            return this.playerFriction;
        }

        //setter for friction
        public void setFriction(float someFriction)
        {
            //sets the value of friction to whatever it is set as by user
            this.playerFriction = someFriction;
        }

        public void playerUpdate()
        {
            MouseState mouse = Mouse.GetState();

            playerDistance.X = mouse.X - playerPosition.X;
            playerDistance.Y = mouse.Y - playerPosition.Y;

            playerRotation = (float)Math.Atan2(playerDistance.Y, playerDistance.X);

            playerRect = new Rectangle((int)playerPosition.X, (int)playerPosition.Y,
                playerSprite.Width, playerSprite.Height);

            playerPosition = playerVelocity + playerPosition;
            playerOrigin = new Vector2(playerRect.Width / 2, playerRect.Height / 2);

            if(Keyboard.GetState().IsKeyDown(Keys.D))
            {
                playerVelocity.X++;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                //move the game item left
                playerVelocity.X--;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                //move the game item up
                playerVelocity.Y--;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                //move the game item down
                playerVelocity.Y++;
            }   

            else if(playerVelocity != Vector2.Zero)
            {
                float i = playerVelocity.X;
                float j = playerVelocity.Y;

                playerVelocity.X = i -= playerFriction * i;
                playerVelocity.Y = j -= playerFriction * j;
            }
        }
    }
}