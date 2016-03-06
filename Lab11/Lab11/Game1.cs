using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ExplodingTeddies;
using System;

namespace Lab11
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public const int WindowWidth = 800;
        public const int WindowHeight = 600;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        TeddyBear bearry;
        Explosion splodie;
        Random r = new Random();
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = WindowWidth;
            graphics.PreferredBackBufferHeight = WindowHeight;
            IsMouseVisible = true;
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

            float f1 = ((float)r.NextDouble() - .5F) * 2;
            float f2 = ((float)r.NextDouble() - .5F) * 2;
            Vector2 vel = new Vector2(f1, f2);

            // TODO: use this.Content to load your game content here
            bearry = new TeddyBear(Content, WindowWidth, WindowHeight, @"graphics/teddybear", WindowWidth / 2, WindowHeight / 2, vel);
            splodie = new Explosion(Content, @"graphics/explosion");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        ///<sumary>
        ///Our own method for spawning a new teddy
        ///Encapsulates Teddy spawn code so we don't have to copy-paste
        ///</sumary>
        public void spawnTeddy()
        {
            int x1 = r.Next(WindowWidth - bearry.DrawRectangle.Width);
            int y1 = r.Next(WindowHeight - bearry.DrawRectangle.Height);
            float v1 = ((float)r.NextDouble() - .5F) * 2;
            float v2 = ((float)r.NextDouble() - .5F) * 2;
            Vector2 vel1 = new Vector2(v1, v2);
            bearry = new TeddyBear(Content, WindowWidth, WindowHeight, @"graphics/teddybear", x1, y1, vel1);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            /*
            MouseState moz = Mouse.GetState();


            
            if (victim.DrawRectangle.Contains(moz.Position) && moz.LeftButton == ButtonState.Pressed)
            {
                victim.Active = false;
                predator.Play(moz.X, moz.Y);
            }
            */

            bool ks = Keyboard.GetState().IsKeyDown(Keys.A);
            bool ks2 = Keyboard.GetState().IsKeyDown(Keys.B);

            if (ks)
            {
                ks = Keyboard.GetState().IsKeyDown(Keys.A);
                if (!ks) spawnTeddy();
            }
            else if (ks2)
            {
                splodie.Play(bearry.DrawRectangle.Center.X, bearry.DrawRectangle.Center.Y);
                spawnTeddy();
            }

            bearry.Update(gameTime);
            splodie.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            bearry.Draw(spriteBatch);
            splodie.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
