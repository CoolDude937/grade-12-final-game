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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //player stuff
        gamePlayer player;

        //player bullet stuff
        //list of bullets
        List<playerBullet> bullets = new List<playerBullet>();
        //bullet sprite
        Texture2D bulletSprite;
        //bullet delay 
        int shootCounter = 0;

        //mouse stuff
        //mouse state variable
        MouseState mouse;
        //mouse past state variable
        MouseState oldMouse;

        //enemy stuff
        List<enemy> listOfEnemies = new List<enemy>();
        Texture2D enemySprite;

        //sets puzzle light to puzzle room
        puzzleRoom puzzleLight;

        //sets puzzle room background variable
        generalGameItem backGroundImage;

        //timer for the game timer
        int gameTimer;

        //bool for game victory
        bool isGameWon;

        //font variable for the end message
        SpriteFont ggFont;

        //font variable for the instructins
        SpriteFont instructionFont;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
      
            //sets up player
            player = new gamePlayer(new Rectangle(300, 430, 50, 50), Content.Load<Texture2D>("testcharacter"), Color.White);

            //sets up bg image
            backGroundImage = new generalGameItem(Content.Load<Texture2D>("dungeon"), new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //loads in bullet sprite
            bulletSprite = Content.Load<Texture2D>("bullet");

            //loads in enemy sprite
            enemySprite = Content.Load<Texture2D>("waddledee");

            //loads in light ball sprite
            puzzleLight = new puzzleRoom(Color.Black, new Rectangle(225, 300, 50, 50), new Rectangle(325, 300, 50, 50), new Rectangle(425, 300, 50, 50), new Rectangle(525, 300, 50, 50), Content.Load<Texture2D>("lightBall"));

            //loads in the end of game font into the font variable 
            ggFont = Content.Load<SpriteFont>("ggFont");

            //loads in the instruction font into the font variable
            instructionFont = Content.Load<SpriteFont>("instructionFont");

            //adds three enemies to a list of enemies
            //slow enemy
            listOfEnemies.Add(new enemy(enemySprite, new Rectangle(740, 200, 50, 50), Color.White, new Vector2(10f, 0)));
            //faster enemy
            listOfEnemies.Add(new enemy(enemySprite, new Rectangle(300, 100, 50, 50), Color.White, new Vector2(18f, 0)));
            //fastest enemy
            listOfEnemies.Add(new enemy(enemySprite, new Rectangle(0, 0, 50, 50), Color.White, new Vector2(23f, 0)));

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //ticks the timer
            gameTimer++;

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //assigns state of mouse to mousestate variable
            mouse = Mouse.GetState();

            //moves player
            player.movePlayer();
     
            //for loop to move bullets
            for (int i = 0; i < bullets.Count; i++)
            {
                //moves each bullet up 
                bullets[i].moveBullet();           
            }

            //BULLET LAG
            //if the timer has reached the limit
            if (gameTimer < 800)
            {
                //if the bullet timer has reached the limit
                if (shootCounter >= 10)
                {
                    //handles bullets
                    handleBullets();

                    //reset bullet counter
                    shootCounter = 0;
                }
                //else there is still time to wait til the next shot
                else
                {
                    //keep counting the counter
                    shootCounter++;
                }
            }
//-------------

            //for loop to move the enemies back and forth
            for (int i = 0; i < listOfEnemies.Count; i++)
            {
                //moves enemy back and forth
                listOfEnemies[i].patrollingEnemy();
            }

            //keeps player in the screen
            player.outOfBounds();


            //bullet hit test with enemies
            //for loop to run through the bullet list
            for (int i = 0; i < bullets.Count; i++)
            {
                //for loop to run throught the enemy list
                for (int j = 0; j < listOfEnemies.Count; j++)
                { 
                    //if a bullet strikes an enemy
                    if (bullets[i].getRect().Intersects(listOfEnemies[j].getRect()))
                    {                    
                            //remove the bullet from the list
                            bullets.Remove(bullets[i]);
                            //remove the enemy from the list
                            listOfEnemies.Remove(listOfEnemies[j]);
                       
                            //get out since the bullet has been removed, to avoid runtime error
                            break;                  
                    }               
                }
            }

            //if the timer has reached the limit (800 ticks) and the player has defeated all 3 enemies
            if (gameTimer >= 800  && listOfEnemies.Count==0)
            {
                //set the bool for a victory to true
                isGameWon = true;
            }
            //if the timer reached the limit and the player has not defeated all 3 enemies
            if (gameTimer >= 800 && listOfEnemies.Count!=0)
            {
                //set the bool for a victory to false
                isGameWon = false;
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        //method to add bullets
        public void handleBullets()
        {
            //if the m1 button is clicked
            if (mouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released)
            {
                //creates new bullet
                playerBullet newBullet = new playerBullet(bulletSprite, new Rectangle(player.getRect().X+player.getRect().Width/2-8, player.getRect().Y, 15, 15), Color.White);

                //puts new bullet into list
                bullets.Add(newBullet);
            }

            //edge detection
            oldMouse = mouse;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here

            //begin spritebatch drawing
            spriteBatch.Begin();
           
            //draws in background
            backGroundImage.Draw(spriteBatch);

            //display instructions
            spriteBatch.DrawString(instructionFont, "Shoot all of the enemies before all the lights turn on. GL HF!", new Vector2(55, 400), Color.White);

            //draws in player
            player.Draw(spriteBatch);

            //for loop to draw bullets
            for (int i = 0; i < bullets.Count; i++)
            {
                //moves each bullet up 
                bullets[i].Draw(spriteBatch);
            }
            
            //for loop to draw enemies
            for (int i = 0; i < listOfEnemies.Count; i++)
            {
                listOfEnemies[i].Draw(spriteBatch);
            }
            
            //draws puzzle lights
            puzzleLight.DrawLight(spriteBatch);

            //draws the first flash sequence
            puzzleLight.flash1(spriteBatch);

            //if the bool for game won is true and the timer has reached the limit
            if (gameTimer>=800 && isGameWon == true)
            {
                //display a victory message
                spriteBatch.DrawString(ggFont, "gg ez", new Vector2(0, 100), Color.White);
            }

            //if the bool for game won is false and the timer has reached the limit
            if (gameTimer>=800 && isGameWon == false)
            {
                //display a loss message
                spriteBatch.DrawString(ggFont, "lol bad", new Vector2(0, 100), Color.White);
            }

            //end spritebatch drawing
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
//code graveyard
/*
                 //if the bullet goes off screen
                if (bullets[i].getRect().Y < 0)
                {
                    //remove that bullet from the list
                    bullets.Remove(bullets[i]);
                }
*/
