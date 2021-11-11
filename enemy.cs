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
    class enemy : generalGameItem
    {
        //which way the enemy is moving
        private Vector2 enemyVelocity;

        public enemy(Texture2D enemySprite, Rectangle enemyRect, Color enemyColor, Vector2 aEnemyVelocity)
            :base(enemySprite, enemyRect, enemyColor)
        {
            //set enemy velocity
            this.setEnemyVelocity(aEnemyVelocity);
        }

        //getter for the velocity
        public Vector2 getEnemyVelocity()
        {
            //returns value of the velocity in this class
            return enemyVelocity;
        }

        //setter for the velocity
        public void setEnemyVelocity(Vector2 someEnemyVelocity)
        {
            //assigns the value of the velocity to whatever the user assigns the sprite as
            enemyVelocity = someEnemyVelocity;
        }

        //method to move the enemy back and forth
        public void patrollingEnemy()
        {
            //moves the rectangle to the speed of the velocity
            rect.X = rect.X + (int)enemyVelocity.X;

            //if the rectangle tries to exceed the left of the screen
            if (rect.X <= 0)
                //reverse the direction of the rectangle
                enemyVelocity.X = -enemyVelocity.X;
            //if the rectangle tries to exceed the right sight of the screen
            if (rect.X + rect.Width >= 800)
                //reverse the direction of the rectangle
                enemyVelocity.X = -enemyVelocity.X;
        }

    }
}
