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

        //variables for controlling sprite speed
        private Vector2 playerVelocity;

        //player image
        private Texture2D playerSprite;

        private Vector2 playerDistance;

        private Rectangle playerRect;

        private float playerRotation;
        
        //friction variable
        private float playerFriction;

        bool isMouseVisible;
        //constructor
        public gamePlayer(float aPlayerFriction, Texture2D aPlayerSprite, Rectangle aPlayerRect,
            Color aPlayerColor, Vector2 aPlayerOrigin, Vector2 aPlayerPosition,
            float aPlayerRotation, Vector2 aPlayerVelocity, Vector2 aPlayerDistance) : base(aPlayerSprite, aPlayerRect,
                aPlayerColor, aPlayerOrigin, aPlayerPosition, aPlayerRotation, aPlayerVelocity)
        {
            //sets the value of this friction
            this.setFriction(aPlayerFriction);

            this.setDistance(aPlayerDistance);

            this.setPlayerSprite(aPlayerSprite);

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

        //getter for distance
        public Vector2 getDistance()
        {
            //returns value of distance
            return this.playerDistance;
        }

        //setter for distance
        public void setDistance(Vector2 someDistance)
        {
            //sets the value of distance to whatever it is set as by user
            this.playerDistance = someDistance;
        }

        //getter for player sprite
        public Texture2D getPlayerSprite()
        {
            //returns value of player sprite
            return this.playerSprite;
        }

        //setter for player sprite
        public void setPlayerSprite(Texture2D somePlayerSprite)
        {
            //sets the value of player sprite to whatever it is set as by user
            this.playerSprite = somePlayerSprite;
        }

        public void playerUpdate()
        {
            MouseState mouse = Mouse.GetState();
            isMouseVisible = true;

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

        //method to draw in the player
        public void drawPlayer(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerSprite, playerPosition, null, Color.White, playerRotation, playerOrigin, 1f, SpriteEffects.None, 0);
        }
    }
}
