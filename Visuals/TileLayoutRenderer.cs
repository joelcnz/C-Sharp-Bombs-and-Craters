//#magic number alert!
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WindowsGame1.Model;

namespace WindowsGame1.Visuals
{
    public class TileLayoutRenderer
    {
        private readonly SpriteBatch spriteBatch;
        private readonly TileVisualFactory tileVisualFactory;

        public TileLayoutRenderer(SpriteBatch spriteBatch, TileVisualFactory tileVisualFactory)
        {
            this.spriteBatch = spriteBatch;
            this.tileVisualFactory = tileVisualFactory;
        }

        public void Render(TileLayout tileLayout)
        {
            spriteBatch.Begin();

            var top = 0;

            foreach (var tileRow in tileLayout.GetTileMatrix())
            {
                var tileVisualRow = tileRow.Select(tile => tileVisualFactory.CreateTileVisual(tile)); // turn all the Tile's into TileVisual's
                var left = 0;

                foreach (var tile in tileVisualRow)
                {
                    var rectangle = new Rectangle(left, top, tile.Width, tile.Height);

                    spriteBatch.Draw(tile.Visual, rectangle, Color.White);

                    //#magic number alert!
                    left += 64; // tile.Width; // not all widths are the same
                }
                top += tileVisualRow.Max(r => r.Height);
            }

            spriteBatch.End();
        }
    }
}