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
    
    class playerBullets : movingGameItem
    {
        private Texture2D bulletTexture;
        private Rectangle bulletRect;
        private Color bulletColor;
        private float bulletRotation;

        private Vector2 bulletPosition;
        private Vector2 bulletVelocity;
        private Vector2 bulletOrigin;

        MouseState pastKey;

        List<playerBullets> someListOfBullets = new List<playerBullets>();

        private bool isVisible;

        public playerBullets(Texture2D newTexture, Rectangle aBulletRect,
            Color aBulletColor, Vector2 aBulletOrigin, Vector2 aBulletPosition,
            float aBulletRotation, Vector2 aBulletVelocity) : base(newTexture, aBulletRect,
             aBulletColor,  aBulletOrigin,  aBulletPosition,
             aBulletRotation,  aBulletVelocity)
        {
            bulletTexture = newTexture;
            isVisible = false;

            this.setBulletPosition(aBulletPosition);
            this.setBulletVelocity(aBulletVelocity);
            this.setBulletOrigin(aBulletOrigin);
        }

        //getter for the bullet position
        public Vector2 getBulletPosition()
        {
            //returns value of the bullet position in this class
            return this.bulletPosition;
        }

        //setter for the bullet position
        public void setBulletPosition(Vector2 someBulletPosition)
        {
            //assigns the value of the bullet position to whatever the user assigns the it as
            this.bulletPosition = someBulletPosition;
        }

        //getter for the bullet velocity
        public Vector2 getBulletVelocity()
        {
            //returns value of the bullet velocity in this class
            return this.bulletVelocity;
        }

        //setter for the bullet velocity
        public void setBulletVelocity(Vector2 someBulletVelocity)
        {
            //assigns the value of the bullet velocity to whatever the user assigns the it as
            this.bulletPosition = someBulletVelocity;
        }

        //getter for the bullet origin
        public Vector2 getBulletOrigin()
        {
            //returns value of the bullet origin in this class
            return this.bulletOrigin;
        }

        //setter for the bullet origin
        public void setBulletOrigin(Vector2 someBulletOrigin)
        {
            //assigns the value of the bullet origin to whatever the user assigns the it as
            this.bulletOrigin = someBulletOrigin;
        }

        public void UpdateBullets()
        {
            foreach (playerBullets bullet in someListOfBullets)
            {
                bullet.bulletPosition += bullet.bulletVelocity;
                if (Vector2.Distance(bullet.bulletPosition, spritePosition) > 500)
                    bullet.isVisible = false;
            }
        }

        public void Shoot()
        {
            playerBullets newBullet = new playerBullets(bulletTexture, bulletRect, bulletColor,
                bulletOrigin, bulletPosition, bulletRotation, bulletVelocity);
            newBullet.bulletVelocity = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation)) * 5f + bulletVelocity;
            newBullet.bulletPosition = spritePosition + newBullet.bulletVelocity * 5;
            newBullet.isVisible = true;

            if (someListOfBullets.Count() >= 0)
                someListOfBullets.Add(newBullet);
        }

        public void shootBullet()
        {
            if (Mouse.GetState().LeftButton==ButtonState.Pressed && pastKey.LeftButton==ButtonState.Released)
            {
                Shoot();

            }

            pastKey = Mouse.GetState();
            UpdateBullets();
        }
    }
    
}
