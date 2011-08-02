using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WindowsGame1.Model;

namespace WindowsGame1.Visuals
{
    public class TileGraphicLoader
    {
        private readonly ContentManager contentManager;
        private readonly GraphicsDevice graphicsDevice;

        public TileGraphicLoader(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            this.contentManager = contentManager;
            this.graphicsDevice = graphicsDevice;
        }

        public IDictionary<TileType, Texture2D> GetTileGraphics()
        {
            var tileGraphics = new Dictionary<TileType, Texture2D>();

            var scribbleTexture = contentManager.Load<Texture2D>("Bitmap1");
            var blockTexture = contentManager.Load<Texture2D>("block");
            var bombTexture = contentManager.Load<Texture2D>("bomb");
            var spikesTexture = contentManager.Load<Texture2D>("spikes");
            var blankTexture = new Texture2D(graphicsDevice, blockTexture.Width, blockTexture.Height);

            tileGraphics.Add(TileType.Scribble, scribbleTexture);
            tileGraphics.Add(TileType.block, blockTexture);
            tileGraphics.Add(TileType.bomb, bombTexture);
            tileGraphics.Add(TileType.spikes, spikesTexture);
            tileGraphics.Add(TileType.Blank, blankTexture);

            return tileGraphics;
        }
    }
}