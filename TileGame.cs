//#bad
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using WindowsGame1.Model;
using WindowsGame1.Visuals;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class TileGame : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private TileLayout tileLayout;
        private IDictionary<TileType, Texture2D> tileGraphicsLookup;

        public TileGame()
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
            // Model
            tileLayout = new TileLayoutBuilder()
                .GetInitialLayout();

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

            // Mapping from Model to View
            tileGraphicsLookup = new TileGraphicLoader(Content, GraphicsDevice)
                .GetTileGraphics();

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
            var key = Keyboard.GetState(PlayerIndex.One);
            // Allows the game to exit, using the ESC key
            if (key.IsKeyDown(Keys.Escape))
                this.Exit();

            if (key.IsKeyDown(Keys.Tab))
            {
                ToggleTiles();
                //while (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Tab)) { } //#bad
            }

            base.Update(gameTime);
        }

        private void ToggleTiles()
        {
            // Manipulating the model
            foreach (var row in tileLayout.GetTileMatrix())
            {
                foreach (var tile in row)
                {
                    tile.TileType =
                            tile.TileType == TileType.Blank ?
                            TileType.Scribble :
                                tile.TileType == TileType.Scribble ? 
                                    TileType.Blank :  tile.TileType;
                }
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.Clear(Color.Black);

            // Rendering the View from the Model
            new TileLayoutRenderer(spriteBatch, new TileVisualFactory(tileGraphicsLookup))
                .Render(tileLayout);

            base.Draw(gameTime);
        }
    }
}
