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

namespace SuperGenius
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D roadRunner;
        Rectangle coyoteRectangle;

        Texture2D coyote;
        Rectangle runnerRectangle;

        int xLocMouse = 100;
        int yLocMouse = 100;
        int xLocRunner = 300;
        int yLocRunner = 300;
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
            runnerRectangle = new Rectangle(xLocRunner, yLocRunner, 125, 125);
            coyoteRectangle = new Rectangle(xLocMouse, yLocMouse, 92, 79);
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
            roadRunner = this.Content.Load<Texture2D>("Roadrunner");
            coyote = this.Content.Load<Texture2D>("Wile E Coyote");
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

            // TODO: Add your update logic here
            KeyboardState kb = Keyboard.GetState();
            if (kb.IsKeyDown(Keys.W))
            {
                yLocRunner -= 2;
            }
            if (kb.IsKeyDown(Keys.S))
            {
                yLocRunner += 2;
            }
            if (kb.IsKeyDown(Keys.A))
            {
                xLocRunner -= 2;
            }
            if (kb.IsKeyDown(Keys.D))
            {
                xLocRunner += 2;
            }
            if (kb.IsKeyDown(Keys.Left))
            {
                xLocMouse -= 3;
            }
            if (kb.IsKeyDown(Keys.Right))
            {
                xLocMouse += 3;
            }
            if (kb.IsKeyDown(Keys.Up))
            {
                yLocMouse -= 3;
            }
            if (kb.IsKeyDown(Keys.Down))
            {
                yLocMouse += 3;
            }
            runnerRectangle = new Rectangle(xLocMouse, yLocMouse, 92, 79);
            coyoteRectangle = new Rectangle(xLocRunner, yLocRunner, 125, 125);
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
            spriteBatch.Draw(roadRunner, runnerRectangle, Color.White);
            spriteBatch.Draw(coyote, coyoteRectangle, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
