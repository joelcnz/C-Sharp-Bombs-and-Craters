//#maybe the more vorbose way is better
//#magic numbers
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

            //#maybe the more vorbose way is better
            var names = new string[] {"Bitmap1", "block", "bomb", "spikes"};
            var type = new TileType[] { TileType.Scribble, TileType.block, TileType.bomb, TileType.spikes };
            int i = 0;
            foreach (var name in names)
            {
                tileGraphics.Add(type[i], contentManager.Load<Texture2D>(name));
                i++;
            }
            tileGraphics.Add(TileType.Blank, new Texture2D(graphicsDevice, 64, 64)); //#magic numbers

            return tileGraphics;
        }
    }
}