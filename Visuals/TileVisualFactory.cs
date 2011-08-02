//#what's this 'readonly' thing?
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using WindowsGame1.Model;

namespace WindowsGame1.Visuals
{
    public class TileVisualFactory
    {
        public IDictionary<TileType, Texture2D> TileTypeToVisualLookup { get; set; }
        private readonly IDictionary<TileType, Texture2D> tileTypeToVisualLookup; //#what's this 'readonly' thing?

        public TileVisualFactory(IDictionary<TileType, Texture2D> tileTypeToVisualLookup)
        {
            TileTypeToVisualLookup = tileTypeToVisualLookup;
            this.tileTypeToVisualLookup = tileTypeToVisualLookup;
        }

        public TileVisual CreateTileVisual(Tile tile)
        {
            return new TileVisual(tileTypeToVisualLookup[tile.TileType]);
        }
    }
}