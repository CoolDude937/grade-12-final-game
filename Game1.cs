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
        //list of bullets
        List<playerBullet> bullets = new List<playerBullet>();
        //bullet sprite
        Texture2D bulletSprite;
        //mouse state variable
        MouseState mouse;
        //mouse past state variable
        MouseState oldMouse;
        
        //sets puzzle light to puzzle room
        puzzleRoom puzzleLight;
        
        //sets puzzle halway as a general game room
        generalGameItem puzzleHallway;
        
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
            player = new gamePlayer(new Rectangle(300, 330, 50, 50), Content.Load<Texture2D>("testcharacter"), Color.White)
            
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
            // TODO: use this.Content to load your game content here
            
            //loads the puzzle light and all of the other constructor variables with it
            puzzleLight = new puzzleRoom(Color.Black, new Rectangle(200, 250, 50, 50), new Rectangle(300, 250, 50, 50), new Rectangle(400, 250, 50, 50), new Rectangle(500, 250, 50, 50), Content.Load<Texture2D>("lightBall"));

            //loads puzzle hallway image
            puzzleHallway = new generalGameItem(Content.Load<Texture2D>("puzzleHallway"), new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White) 

            //bullet image
            bulletSprite = Content.Load<Texture2D>("bullet");

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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //assigns state of mouse to mousestate variable
            mouse = Mouse.GetState();

            //moves player
            player.movePlayer();
     
            //for loop to draw bullets
            for (int i = 0; i < bullets.Count; i++)
            {
                //moves each bullet up 
                bullets[i].moveBullet();           
            }

            //handles bullets
            handleBullets();

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
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            
            //starts the sprite batch
            spriteBatch.Begin();

            //draws player
            player.Draw(spriteBatch);

            //for loop to draw bullets
            for (int i = 0; i < bullets.Count; i++)
            {
                //moves each bullet up 
                bullets[i].Draw(spriteBatch);
            }
            
            //draws the puzzle hallway
            puzzleHallway.Draw(spriteBatch);

            //draws puzzle hallway
            puzzleLight.DrawLight(spriteBatch);

            //draws the first flash sequence
            puzzleLight.flash1(spriteBatch);

            //ends the sprite batch
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
